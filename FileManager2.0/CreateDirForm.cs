using System;
using System.IO;
using System.Windows.Forms;

namespace FileManager2._0
{
    public partial class CreateDirForm : Form
    {
        private string _FileName;
        public CreateDirForm(string fileName)
        {
            InitializeComponent();
            _FileName = fileName;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void CreateDir_Click(object sender, EventArgs e)
        {
            var pathNewDir = newDir.Text.Trim();

            if (Directory.Exists(pathNewDir))
            {
                MessageBox.Show("Директория с таким именем уже существует", "Произошла ошибка при создании директории", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if(pathNewDir is null)
            {
                MessageBox.Show("Директория с таким именем уже существует", "Произошла ошибка при создании директории", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else
            {
                var dir = new DirectoryModel(_FileName);
                string errorMsg = null;

                dir.CreateDir(pathNewDir, ref errorMsg);

                if(errorMsg is null)
                {
                    MessageBox.Show($"Директория создана", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }

                else
                {
                    MessageBox.Show(errorMsg, "Произошла ошибка при создании директории", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
