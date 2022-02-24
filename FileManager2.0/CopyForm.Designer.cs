
namespace FileManager2._0
{
    partial class CopyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btCopy = new System.Windows.Forms.Button();
            this.SourceFile = new System.Windows.Forms.TextBox();
            this.NameFilePath = new System.Windows.Forms.TextBox();
            this.DestFile = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Файл для копирования:";
            // 
            // btCopy
            // 
            this.btCopy.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btCopy.Location = new System.Drawing.Point(373, 143);
            this.btCopy.Name = "btCopy";
            this.btCopy.Size = new System.Drawing.Size(125, 34);
            this.btCopy.TabIndex = 2;
            this.btCopy.Text = "Копировать";
            this.btCopy.UseVisualStyleBackColor = false;
            this.btCopy.Click += new System.EventHandler(this.btCopy_Click);
            // 
            // SourceFile
            // 
            this.SourceFile.Location = new System.Drawing.Point(240, 30);
            this.SourceFile.Name = "SourceFile";
            this.SourceFile.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.SourceFile.Size = new System.Drawing.Size(638, 31);
            this.SourceFile.TabIndex = 3;
            // 
            // NameFilePath
            // 
            this.NameFilePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameFilePath.Location = new System.Drawing.Point(20, 70);
            this.NameFilePath.Multiline = true;
            this.NameFilePath.Name = "NameFilePath";
            this.NameFilePath.ReadOnly = true;
            this.NameFilePath.Size = new System.Drawing.Size(214, 58);
            this.NameFilePath.TabIndex = 4;
            this.NameFilePath.Text = "Путь для расположения копии файла:";
            // 
            // DestFile
            // 
            this.DestFile.Location = new System.Drawing.Point(240, 83);
            this.DestFile.Name = "DestFile";
            this.DestFile.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.DestFile.Size = new System.Drawing.Size(638, 31);
            this.DestFile.TabIndex = 5;
            this.DestFile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DestFile_MouseClick);
            // 
            // CopyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 199);
            this.Controls.Add(this.DestFile);
            this.Controls.Add(this.NameFilePath);
            this.Controls.Add(this.SourceFile);
            this.Controls.Add(this.btCopy);
            this.Controls.Add(this.label1);
            this.Name = "CopyForm";
            this.Text = "Копирование";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btCopy;
        private System.Windows.Forms.TextBox SourceFile;
        private System.Windows.Forms.TextBox NameFilePath;
        private System.Windows.Forms.TextBox DestFile;
    }
}