using System;
using System.Windows.Forms;
using System.IO;

namespace FileManager2._0
{
    public partial class RenameForm : Form
    {
        private string _FileName;
        public RenameForm(string fileName)
        {
            InitializeComponent();
            _FileName = fileName;
            ToolTip t = new ToolTip();
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            t.SetToolTip(newName, "Укажите новое имя с типом расширения, без указания полного пути");
        }

        private void Rename_Click(object sender, EventArgs e)
        {
            if (File.Exists(_FileName))
            {
                var file = new FileModel(_FileName);
                string errorMsg = null;

                file.Rename(newName.Text, ref errorMsg);

                if (errorMsg is null)
                {
                    MessageBox.Show($"Файл успешно переименован", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }

                else
                {
                    MessageBox.Show(errorMsg, "Произошла ошибка при переименовывании файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (Directory.Exists(_FileName))
            {
                var dir = new DirectoryModel(_FileName);
                string errorMsg = null;

                dir.Rename(newName.Text, ref errorMsg);

                if (errorMsg is null)
                {
                    MessageBox.Show($"Директория успешно переименована", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }

                else
                {
                    MessageBox.Show(errorMsg, "Произошла ошибка при переименовывании директории", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show($"Файл или директория {_FileName} не существует.", "Произошла ошибка при переименовывании файла", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }
    }
}
