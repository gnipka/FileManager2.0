
namespace FileManager2._0
{
    partial class MoveForm
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
            this.MoveTo = new System.Windows.Forms.Button();
            this.newPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MoveTo
            // 
            this.MoveTo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MoveTo.Location = new System.Drawing.Point(112, 65);
            this.MoveTo.Name = "MoveTo";
            this.MoveTo.Size = new System.Drawing.Size(163, 34);
            this.MoveTo.TabIndex = 5;
            this.MoveTo.Text = "Переместить";
            this.MoveTo.UseVisualStyleBackColor = false;
            this.MoveTo.Click += new System.EventHandler(this.MoveTo_Click);
            // 
            // newPath
            // 
            this.newPath.Location = new System.Drawing.Point(203, 18);
            this.newPath.Name = "newPath";
            this.newPath.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.newPath.Size = new System.Drawing.Size(218, 31);
            this.newPath.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введите полный путь:";
            // 
            // MoveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 114);
            this.Controls.Add(this.MoveTo);
            this.Controls.Add(this.newPath);
            this.Controls.Add(this.label1);
            this.Name = "MoveForm";
            this.Text = "Перемещение";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MoveTo;
        private System.Windows.Forms.TextBox newPath;
        private System.Windows.Forms.Label label1;
    }
}