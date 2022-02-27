
namespace FileManager2._0
{
    partial class CreateDirForm
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
            this.CreateDir = new System.Windows.Forms.Button();
            this.newDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CreateDir
            // 
            this.CreateDir.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CreateDir.Location = new System.Drawing.Point(116, 64);
            this.CreateDir.Name = "CreateDir";
            this.CreateDir.Size = new System.Drawing.Size(163, 34);
            this.CreateDir.TabIndex = 5;
            this.CreateDir.Text = "Создать";
            this.CreateDir.UseVisualStyleBackColor = false;
            this.CreateDir.Click += new System.EventHandler(this.CreateDir_Click);
            // 
            // newDir
            // 
            this.newDir.Location = new System.Drawing.Point(219, 18);
            this.newDir.Name = "newDir";
            this.newDir.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.newDir.Size = new System.Drawing.Size(218, 31);
            this.newDir.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введите имя директории:";
            // 
            // CreateDirForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 114);
            this.Controls.Add(this.CreateDir);
            this.Controls.Add(this.newDir);
            this.Controls.Add(this.label1);
            this.Name = "CreateDirForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание директории";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateDir;
        private System.Windows.Forms.TextBox newDir;
        private System.Windows.Forms.Label label1;
    }
}