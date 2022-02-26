﻿using System;
using System.Windows.Forms;
using System.IO;

namespace FileManager2._0
{
    public partial class CopyForm : Form
    {
        private string _FileName;
        public CopyForm(string fileName)
        {
            InitializeComponent();
            _FileName = fileName;
            SourceFile.Text = _FileName;
            ToolTip t = new ToolTip();
            t.SetToolTip(DestFile, "Укажите полный путь к файлу (вместе с его новым именем и расширением)");
        }

        private void DestFile_MouseClick(object sender, MouseEventArgs e)
        {
            DestFile.Text = null;
        }

        private void btCopy_Click(object sender, EventArgs e)
        {
            var destName = DestFile.Text.Trim();

            if (File.Exists(_FileName))
            {
                string errorMsg = null;
                var file = new FileModel(_FileName);
                file.Copy(destName, out errorMsg);

                if (errorMsg is null)
                {
                    MessageBox.Show($"Копирование прошло успешно! {Environment.NewLine}Путь к новому файлу: {destName}",
                        "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }

                MessageBox.Show(errorMsg, "Произошла ошибка при копировании файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (Directory.Exists(_FileName))
            {
                string errorMsg = null;
                var dir = new DirectoryModel(_FileName);
                dir.Copy(destName, ref errorMsg);

                if (errorMsg is null)
                {
                    MessageBox.Show($"Копирование прошло успешно! {Environment.NewLine}Путь к новому файлу: {destName}",
                        "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(errorMsg, "Произошли ошибки при копировании директории", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show($"Файл или директория {_FileName} не существует.", "Произошла ошибка при копировании файла", MessageBoxButtons.OK, MessageBoxIcon.Error); ;

            }
        }
    }
}

