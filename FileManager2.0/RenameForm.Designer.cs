
namespace FileManager2._0
{
    partial class RenameForm
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
            this.newName = new System.Windows.Forms.TextBox();
            this.Rename = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите новое имя:";
            // 
            // newName
            // 
            this.newName.Location = new System.Drawing.Point(194, 21);
            this.newName.Name = "newName";
            this.newName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.newName.Size = new System.Drawing.Size(218, 31);
            this.newName.TabIndex = 1;
            // 
            // Rename
            // 
            this.Rename.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Rename.Location = new System.Drawing.Point(114, 68);
            this.Rename.Name = "Rename";
            this.Rename.Size = new System.Drawing.Size(163, 34);
            this.Rename.TabIndex = 2;
            this.Rename.Text = "Переименовать";
            this.Rename.UseVisualStyleBackColor = false;
            this.Rename.Click += new System.EventHandler(this.Rename_Click);
            // 
            // RenameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 114);
            this.Controls.Add(this.Rename);
            this.Controls.Add(this.newName);
            this.Controls.Add(this.label1);
            this.Name = "RenameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Переименовать";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newName;
        private System.Windows.Forms.Button Rename;
    }
}