using System;
using System.IO;
using System.Windows.Forms;

namespace FileManager2._0
{
    public partial class MoveForm : Form
    {
        private string _FileName;
        public MoveForm(string fileName)
        {
            InitializeComponent();
            _FileName = fileName;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void MoveTo_Click(object sender, EventArgs e)
        {
            if (File.Exists(_FileName))
            {
                var file = new FileModel(_FileName);
                string errorMsg = null;

                file.MoveTo(newPath.Text, ref errorMsg);

                if (errorMsg is null)
                {
                    MessageBox.Show($"Файл успешно перемещен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }

                else
                {
                    MessageBox.Show(errorMsg, "Произошла ошибка при перемещении файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (Directory.Exists(_FileName))
            {
                var dir = new DirectoryModel(_FileName);
                string errorMsg = null;

                dir.MoveTo(newPath.Text, ref errorMsg);

                if (errorMsg is null)
                {
                    MessageBox.Show($"Директория успешно перемещен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }

                else
                {
                    MessageBox.Show(errorMsg, "Произошла ошибка при перемещении директории", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show($"Файл или директория {_FileName} не существует.", "Произошла ошибка при перемещении файла", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }
    }
}
