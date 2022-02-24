﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FileManager2._0
{
    //Фасадный шаблон проектирования
    class FileOperations
    {
    }
    internal abstract class FileSystemItemModel
    {
        /// <summary>
        /// Функция копирования
        /// </summary>
        /// <param name="destFile"></param>
        public abstract void Copy(string destFile);
    }
    internal class FileModel : FileSystemItemModel
    {
        private readonly FileInfo _File;
        public string Name => _File.Name;
        public long Size => _File.Length;
        public DateTime CreationTime => _File.CreationTime;
        public string FullName => _File.FullName;
        public string Extension => _File.Extension;
        public bool Exist => _File.Exists;


        public FileModel(string FilePath) : this(new FileInfo(FilePath)) { }

        public override void Copy(string destFileName)
        {
            File.Copy(_File.FullName, destFileName);
        }

        public FileModel(FileInfo File) => _File = File;
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
            return File.ReadAllText(_File.FullName).
                Split(" ,.!?';:\"\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).
                Where(x => !x.Any(Char.IsDigit)).Count();
        }
        /// <summary>
        /// Возвращает количество строк
        /// </summary>
        /// <returns></returns>
        public long GetCountString()
        {
            return File.ReadAllLines(_File.FullName).Length;
        }
        /// <summary>
        /// Возвращает количество абзацев
        /// </summary>
        /// <returns></returns>
        public long GetCountParagraph()
        {
            return Regex.Matches(File.ReadAllText(_File.FullName), @"\r?\n\s*\r?\n\s*?\S+").Count + 1;
        }
        /// <summary>
        /// Возвращает количество сиволов с пробелом
        /// </summary>
        /// <returns></returns>
        public long GetCountSymbols()
        {
            return File.ReadAllText(_File.FullName).Count();
        }
        /// <summary>
        /// Возвращает количество символов без пробела
        /// </summary>
        /// <returns></returns>
        public long GetCountSymbolsWithoutGap()
        {
            return File.ReadAllText(_File.FullName).Count() - File.ReadAllText(_File.FullName).Count(c => c == ' ');
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

        public override void Copy(string targetPath)
        {
            Directory.CreateDirectory(targetPath);
            //File.Copy(sourceFile, destFile, true);
        }
    }
}

