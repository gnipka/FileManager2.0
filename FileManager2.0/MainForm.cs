using FileManager2._0.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager2._0
{
    public partial class MainForm : Form
    {
        private DirectoryModel _Directory;
        /// <summary>
        /// Стандартный путь при открытии
        /// </summary>
        private string _Path => Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        /// <summary>
        /// Словарь с ключом - путь к файлу, и значением исконкой этого файла
        /// </summary>
        private Dictionary<string, Icon> _IconsFile;
        /// <summary>
        /// Словарь с ключом - путь к директории, и значением иконка папки(из ресурсов)
        /// </summary>
        private Dictionary<string, Image> _IconsDir;
        DataGridViewCell clickedCell;

        public MainForm()
        {
            InitializeComponent();
            DirsTable.CellBorderStyle = DataGridViewCellBorderStyle.None;
            _Directory = new DirectoryModel(_Path);
            buttonDown.FlatAppearance.BorderSize = 0;
            buttonDown.FlatStyle = FlatStyle.Flat;
            UpdateInfo();
        }

        public void ChangeDataGrid(string Mask = null)
        {
            DirsTable.Rows.Clear();
            _IconsFile = new Dictionary<string, Icon>();
            _IconsDir = new Dictionary<string, Image>();
            var files = _Directory.EnumerateFiles(Mask);
            var dirs = _Directory.EnumerateDirectories(Mask);
            foreach (var dir in dirs)
            {
                _IconsDir.Add(dir.Name, Resources.folder);
            }

            foreach (var file in files)
            {
                Icon iconForFile = SystemIcons.WinLogo;
                iconForFile = Icon.ExtractAssociatedIcon(file.FullName);
                _IconsFile.Add(file.Name, iconForFile);
            }

            foreach (var item in _IconsDir)
            {
                DirsTable.Rows.Add(item.Value, item.Key);
            }

            foreach (var item in _IconsFile)
            {
                DirsTable.Rows.Add(item.Value.ToBitmap(), item.Key);
            }

            DirsTable.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DirsTable.Columns[0].Width = 50;
            DirsTable.Update();
        }
        public void ChangeInfoAboutDir()
        {
            var text = $"Расположение: {_Directory.FullName} {Environment.NewLine} Размер папки: {_Directory.Size / (1024 * 1024)} Мб" +
                $"{Environment.NewLine} Время создания: {_Directory.CreationTime:d} {Environment.NewLine} Количество папок: {_Directory.CountDir} " +
                $"{Environment.NewLine} Количество файлов: {_Directory.CountFile}";
            InfoDir.Text = text;
        }
        public void UpdateInfo()
        {
            FilePath.Text = _Directory.FullName;
            ChangeDataGrid();
            ChangeInfoAboutDir();
        }
        private void DirsTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var filePath = DirsTable[1, e.RowIndex].Value.ToString();

                _Directory = new DirectoryModel(_Directory.FullName + "\\" + filePath);
                UpdateInfo();
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            try
            {
                _Directory = new DirectoryModel(_Directory.DirectoryName);
                UpdateInfo();
            }
            catch
            {

            }
        }

        private void DirsTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var filePath = DirsTable[1, e.RowIndex].Value.ToString();
                var file = new FileModel(_Directory.FullName + "\\" + filePath);

                if (file.Exist)
                {
                    var text = $"Расположение файла: {file.FullName} {Environment.NewLine} Размер файла: {file.Size} Кб " +
                        $"{Environment.NewLine} Время создания: {file.CreationTime:d} {Environment.NewLine}";
                    if (file.IsValidTextFile())
                    {
                        text += $"Количество слов: {file.GetCountWord()} {Environment.NewLine} Количество строк: {file.GetCountString()}" +
                            $"{Environment.NewLine} Количество абзацев: {file.GetCountParagraph()} {Environment.NewLine}" +
                            $"Количество символов: {file.GetCountSymbols()} {Environment.NewLine}" +
                            $"Количество символов(без пробела) {file.GetCountSymbolsWithoutGap()}";
                    }
                    InfoFile.Text = text;
                }
            }
        }

        private void GetDir_Click(object sender, EventArgs e)
        {
            var dir = new DirectoryModel(FilePath.Text);
            if (dir.Exist)
            {
                _Directory = dir;
                UpdateInfo();
            }
        }

        private void Mask_MouseClick(object sender, MouseEventArgs e)
        {
            Mask.Text = String.Empty;
        }

        private void SearchMask_Click(object sender, EventArgs e)
        {
            ChangeDataGrid(Mask.Text.Trim());
        }

        private void DirsTable_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void DirsTable_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Ignore if a column or row header is clicked
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    clickedCell = (sender as DataGridView).Rows[e.RowIndex].Cells[1];

                    // Here you can do whatever you want with the cell
                    this.DirsTable.CurrentCell = clickedCell;  // Select the clicked cell, for instance

                    // Get mouse position relative to the vehicles grid
                    var relativeMousePosition = DirsTable.PointToClient(Cursor.Position);

                    // Show the context menu
                    this.contextMenuStrip1.Show(DirsTable, relativeMousePosition);
                }
            }
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileName = Path.Combine(_Directory.FullName, clickedCell.Value.ToString());

            CopyForm copyForm = new CopyForm(fileName);
            copyForm.Show();
        }
    }
}
