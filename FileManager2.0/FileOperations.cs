using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace FileManager2._0
{
    //Фасадный шаблон проектирования
    class FileOperations
    {
    }
    internal abstract class FileSystemItemModel
    {
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="errorMsg">Сообщение об ошибке</param>
        public abstract void Remove(ref string errorMsg);

        /// <summary>
        /// Переименование
        /// </summary>
        /// <param name="newName">Новое имя файла</param>
        public abstract void Rename(string newName, ref string errorMsg);

        /// <summary>
        /// Перемещение
        /// </summary>
        /// <param name="newPath">Новый путь к файлу</param>
        /// <param name="errorMsg">Сообщение с ошибкой</param>
        public abstract void MoveTo(string newPath, ref string errorMsg);
    }
    internal class FileModel : FileSystemItemModel
    {
        private readonly FileInfo _File;
        public string Name => _File.Name;
        public long Size => _File.Length;
        public DateTime CreationTime => _File.CreationTime;
        public string DirectoryName => Path.GetDirectoryName(FullName);
        public string FullName => _File.FullName;
        public string Extension => _File.Extension;
        public bool Exist => _File.Exists;


        public FileModel(string FilePath) : this(new FileInfo(FilePath)) { }
        public FileModel(FileInfo File) => _File = File;

        /// <summary>
        /// Копирование файла
        /// </summary>
        /// <param name="destFileName">Место, куда копируется файл</param>
        /// <param name="errorMsg">Сообщение об ошибке</param>
        public void Copy(string destFileName, out string errorMsg)
        {
            try
            {
                File.Copy(FullName, destFileName);
                errorMsg = null;
            }
            catch(UnauthorizedAccessException)
            {
                errorMsg = "Нет доступа к директории для записи файла";
            }
            catch (ArgumentException)
            {
                errorMsg = "Все поля должны быть заполнены";
            }
            catch (DirectoryNotFoundException)
            {
                errorMsg = "Указан недопустимый путь";
            }
            catch(FileNotFoundException)
            {
                errorMsg = "Не удалось найти " + FullName;
            }
            catch(IOException)
            {
                errorMsg = destFileName + " существует";
            }
            catch (NotSupportedException)
            {
                errorMsg = "Заданные параметры имеют недопустимый формат";
            }
        }

        public override void Remove(ref string errorMsg)
        {
            try
            {
                File.Delete(FullName);
            }
            catch (ArgumentException)
            {
                errorMsg = $"Путь к файлу {FullName} указан некорректно";
            }
            catch (IOException)
            {
                errorMsg = $"Файл {FullName} используется системой";
            }
            catch (UnauthorizedAccessException)
            {
                errorMsg = $"Нет доступа к файлу {FullName}";
            }
        }

        public override void Rename(string newName, ref string errorMsg)
        {
            try
            {
                _File.MoveTo(DirectoryName + "\\" + newName);
            }
            catch (IOException)
            {
                errorMsg = $"Директория {newName} уже существует";
            }
            catch (ArgumentException)
            {
                errorMsg = $"Путь к директории {newName} содержит недопустимые символы";
            }
            catch (UnauthorizedAccessException)
            {
                errorMsg = $"Нет доступа к директории {FullName}";
            }
        }

        public override void MoveTo(string newPath, ref string errorMsg)
        {
            try
            {
                _File.MoveTo(newPath + "\\" + Name);
            }
            catch (IOException)
            {
                errorMsg = $"Директория {newPath} уже существует";
            }
            catch (ArgumentException)
            {
                errorMsg = $"Путь к директории {newPath} содержит недопустимые символы";
            }
            catch (UnauthorizedAccessException)
            {
                errorMsg = $"Нет доступа к директории {FullName}";
            }
        }

        /// <summary>
        /// Проверка текстовый ли файл
        /// </summary>
        /// <returns></returns>
        public bool IsValidTextFile()
        {
            using (var stream = System.IO.File.Open(FullName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read))
            using (var reader = new System.IO.StreamReader(stream, System.Text.Encoding.UTF8))
            {
                var bytesRead = reader.ReadToEnd();
                reader.Close();
                return bytesRead.All(c =>
                    c == (char)10
                    || c == (char)13
                    || c == (char)11
                    || !char.IsControl(c)
                    );
            }
        }

        /// <summary>
        /// Возвращает количество слов
        /// </summary>
        /// <returns></returns>
        public long GetCountWord()
        {
            return File.ReadAllText(FullName).
                Split(" ,.!?';:\"\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).
                Where(x => !x.Any(Char.IsDigit)).Count();
        }

        /// <summary>
        /// Возвращает количество строк
        /// </summary>
        /// <returns></returns>
        public long GetCountString()
        {
            return File.ReadAllLines(FullName).Length;
        }

        /// <summary>
        /// Возвращает количество абзацев
        /// </summary>
        /// <returns></returns>
        public long GetCountParagraph()
        {
            return Regex.Matches(File.ReadAllText(FullName), @"\r?\n\s*\r?\n\s*?\S+").Count + 1;
        }

        /// <summary>
        /// Возвращает количество сиволов с пробелом
        /// </summary>
        /// <returns></returns>
        public long GetCountSymbols()
        {
            return File.ReadAllText(FullName).Count();
        }

        /// <summary>
        /// Возвращает количество символов без пробела
        /// </summary>
        /// <returns></returns>
        public long GetCountSymbolsWithoutGap()
        {
            return File.ReadAllText(FullName).Count() - File.ReadAllText(FullName).Count(c => c == ' ');
        }
    }
    internal class DirectoryModel : FileSystemItemModel
    {
        private readonly DirectoryInfo _Directory;
        public string Name
        {
            get
            {
                return _Directory.Name;
            }
            private set { }
        }
        public string FullName
        {
            get
            {
                return _Directory.FullName;
            }
            private set { }
        }
        public long Size => _Directory.EnumerateFiles().Sum(file => file.Length);
        public string DirectoryName => Path.GetDirectoryName(FullName);
        public DateTime CreationTime => _Directory.CreationTime;
        public int CountDir => _Directory.GetDirectories().Length;
        public int CountFile => _Directory.GetFiles().Length;
        public string Extension => _Directory.Extension;
        public bool Exist => _Directory.Exists;
        public long TotalLehght => _Directory.EnumerateFiles().Sum(f => f.Length);

        public DirectoryModel(string DirectoryPath) : this(new DirectoryInfo(DirectoryPath)) { }

        public DirectoryModel(DirectoryInfo Directory) => _Directory = Directory;

        public DirectoryInfo[] GetDirectories(string Mask = null)
        {
            if (Mask is null)
                return _Directory.GetDirectories();

            return _Directory.GetDirectories(Mask);
        }

        public FileInfo[] GetFiles(string Mask = null)
        {
            if (Mask is null)
                return _Directory.GetFiles();

            return _Directory.GetFiles(Mask);
        }
        public IEnumerable<DirectoryModel> EnumerateDirectories(string Mask = null)
        {
            var files = Mask is null
            ? _Directory.EnumerateDirectories()
            : _Directory.EnumerateDirectories(Mask);

            foreach (var directory in files)
                yield return new DirectoryModel(directory);
        }

        public IEnumerable<FileModel> EnumerateFiles(string Mask = null)
        {
            var files = Mask is null
            ? _Directory.EnumerateFiles()
            : _Directory.EnumerateFiles(Mask);

            foreach (var file in files)
                yield return new FileModel(file);
        }

        public IEnumerable<FileSystemItemModel> EnumerateContent(string Mask = null)
        {
            var items = Mask is null
            ? _Directory.EnumerateFileSystemInfos()
            : _Directory.EnumerateFileSystemInfos(Mask);

            foreach (var item in items)
                switch (item)
                {
                    case FileInfo file:
                        yield return new FileModel(file);
                        break;
                    case DirectoryInfo dir:
                        yield return new DirectoryModel(dir);
                        break;
                    default:
                        throw new InvalidOperationException("Неподдерживаемый тип данных " + item.GetType());
                }
        }
        /// <summary>
        /// Копирование директории
        /// </summary>
        /// <param name="destPath">Место, куда копируется директория</param>
        /// <param name="errorMsg">Сообщение об ошибке</param>
        /// <param name="sourceDir">Директории, откуда происходит копирование</param>
        public void Copy(string destPath, ref StringBuilder builder, string sourceDir= null)
        {
            if (sourceDir is null)
            {
                sourceDir = FullName;
            }
            Directory.CreateDirectory(destPath);
            foreach (string s1 in Directory.GetFiles(sourceDir))
            {
                string s2 = destPath + "\\" + Path.GetFileName(s1);
                try
                {
                    File.Copy(s1, s2);
                }
                catch (UnauthorizedAccessException)
                {
                    builder.Append($"Нет доступа к директории для записи файла {s2}");
                }
                catch (ArgumentException)
                {
                    builder.Append("Все поля должны быть заполнены");
                }
                catch (DirectoryNotFoundException)
                {
                    builder.Append("Указан недопустимый путь");
                }
                catch (FileNotFoundException)
                {
                    builder.Append("Не удалось найти " + FullName);
                }
                catch (IOException)
                {
                    builder.Append(s2 + " существует");
                }
                catch (NotSupportedException)
                {
                    builder.Append("Заданные параметры имеют недопустимый формат");
                }
            }
            foreach (string s in Directory.GetDirectories(sourceDir))
            {
                Copy(s, ref builder, destPath + "\\" + Path.GetFileName(s));
            }
        }
        public override void Remove(ref string errorMsg)
        {
            try
            {
                Directory.Delete(FullName, true);
            }
            catch (ArgumentException)
            {
                errorMsg = $"Путь к файлу {FullName} указан некорректно";
            }
            catch (IOException)
            {
                errorMsg = $"Директория {FullName} используется системой";
            }
            catch (UnauthorizedAccessException)
            {
                errorMsg = $"Нет доступа к директории {FullName}";
            }
        }

        public override void Rename(string newName, ref string errorMsg)
        {
            try
            {
                _Directory.MoveTo(DirectoryName + "\\" + newName);
            }
            catch (IOException)
            {
                errorMsg = $"Директория {newName} уже существует";
            }
            catch (ArgumentException)
            {
                errorMsg = $"Путь к директории {newName} содержит недопустимые символы";
            }
            catch (UnauthorizedAccessException)
            {
                errorMsg = $"Нет доступа к директории {FullName}";
            }
        }

        public override void MoveTo(string newPath, ref string errorMsg)
        {
            try
            {
                _Directory.MoveTo(newPath + "\\" + Name);
            }
            catch (IOException)
            {
                errorMsg = $"Директория {newPath} уже существует";
            }
            catch (ArgumentException)
            {
                errorMsg = $"Путь к директории {newPath} содержит недопустимые символы";
            }
            catch (UnauthorizedAccessException)
            {
                errorMsg = $"Нет доступа к директории {FullName}";
            }
        }

        public void CreateDir(string newDir, ref string errorMsg)
        {
            string pathNewDir = FullName + "\\" + newDir;
            try
            {
                Directory.CreateDirectory(pathNewDir);
            }
            catch (IOException)
            {
                errorMsg = $"Директория {pathNewDir} уже существует или указан недопустимый путь";
            }
            catch (ArgumentException)
            {
                errorMsg = $"Путь к директории {pathNewDir} содержит недопустимые символы";
            }
            catch (UnauthorizedAccessException)
            {
                errorMsg = $"Нет доступа к директории {FullName}";
            }
        }
    }
}


