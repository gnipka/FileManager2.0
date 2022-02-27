
namespace FileManager2._0
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Mask = new System.Windows.Forms.TextBox();
            this.FilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.InfoDir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.InfoFile = new System.Windows.Forms.TextBox();
            this.GetDir = new System.Windows.Forms.Button();
            this.DirsTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonDown = new System.Windows.Forms.Button();
            this.SearchMask = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddDir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DirsTable)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Mask
            // 
            this.Mask.Location = new System.Drawing.Point(-1, 5);
            this.Mask.Name = "Mask";
            this.Mask.Size = new System.Drawing.Size(924, 31);
            this.Mask.TabIndex = 1;
            this.Mask.Text = "Маска для поиска";
            this.Mask.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mask_MouseClick);
            // 
            // FilePath
            // 
            this.FilePath.Location = new System.Drawing.Point(-1, 41);
            this.FilePath.Name = "FilePath";
            this.FilePath.Size = new System.Drawing.Size(924, 31);
            this.FilePath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(645, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Информация о директории";
            // 
            // InfoDir
            // 
            this.InfoDir.Location = new System.Drawing.Point(645, 136);
            this.InfoDir.Multiline = true;
            this.InfoDir.Name = "InfoDir";
            this.InfoDir.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InfoDir.Size = new System.Drawing.Size(277, 187);
            this.InfoDir.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(645, 329);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Информация о файле";
            // 
            // InfoFile
            // 
            this.InfoFile.Location = new System.Drawing.Point(645, 358);
            this.InfoFile.Multiline = true;
            this.InfoFile.Name = "InfoFile";
            this.InfoFile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InfoFile.Size = new System.Drawing.Size(277, 187);
            this.InfoFile.TabIndex = 6;
            // 
            // GetDir
            // 
            this.GetDir.Location = new System.Drawing.Point(811, 41);
            this.GetDir.Name = "GetDir";
            this.GetDir.Size = new System.Drawing.Size(112, 31);
            this.GetDir.TabIndex = 7;
            this.GetDir.Text = "Перейти";
            this.GetDir.UseVisualStyleBackColor = true;
            this.GetDir.Click += new System.EventHandler(this.GetDir_Click);
            // 
            // DirsTable
            // 
            this.DirsTable.AllowUserToAddRows = false;
            this.DirsTable.AllowUserToDeleteRows = false;
            this.DirsTable.AllowUserToResizeColumns = false;
            this.DirsTable.AllowUserToResizeRows = false;
            this.DirsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DirsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DirsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DirsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.DirsTable.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.DirsTable.Location = new System.Drawing.Point(-1, 112);
            this.DirsTable.Name = "DirsTable";
            this.DirsTable.ReadOnly = true;
            this.DirsTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DirsTable.RowHeadersVisible = false;
            this.DirsTable.RowHeadersWidth = 62;
            this.DirsTable.RowTemplate.Height = 33;
            this.DirsTable.Size = new System.Drawing.Size(640, 438);
            this.DirsTable.TabIndex = 0;
            this.DirsTable.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DirsTable_CellMouseClick);
            this.DirsTable.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DirsTable_CellMouseDoubleClick);
            this.DirsTable.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DirsTable_CellMouseDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // buttonDown
            // 
            this.buttonDown.BackgroundImage = global::FileManager2._0.Properties.Resources.arrowleft_icon_icons_com_61207;
            this.buttonDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonDown.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonDown.Location = new System.Drawing.Point(1, 78);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(34, 34);
            this.buttonDown.TabIndex = 8;
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // SearchMask
            // 
            this.SearchMask.Location = new System.Drawing.Point(811, 5);
            this.SearchMask.Name = "SearchMask";
            this.SearchMask.Size = new System.Drawing.Size(112, 31);
            this.SearchMask.TabIndex = 9;
            this.SearchMask.Text = "Поиск";
            this.SearchMask.UseVisualStyleBackColor = true;
            this.SearchMask.Click += new System.EventHandler(this.SearchMask_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RenameToolStripMenuItem,
            this.CopyToolStripMenuItem,
            this.MoveToolStripMenuItem,
            this.RemoveToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(215, 132);
            // 
            // RenameToolStripMenuItem
            // 
            this.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem";
            this.RenameToolStripMenuItem.Size = new System.Drawing.Size(214, 32);
            this.RenameToolStripMenuItem.Text = "Переименовать";
            this.RenameToolStripMenuItem.Click += new System.EventHandler(this.RenameToolStripMenuItem_Click);
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(214, 32);
            this.CopyToolStripMenuItem.Text = "Копировать";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // MoveToolStripMenuItem
            // 
            this.MoveToolStripMenuItem.Name = "MoveToolStripMenuItem";
            this.MoveToolStripMenuItem.Size = new System.Drawing.Size(214, 32);
            this.MoveToolStripMenuItem.Text = "Переместить";
            this.MoveToolStripMenuItem.Click += new System.EventHandler(this.MoveToolStripMenuItem_Click);
            // 
            // RemoveToolStripMenuItem
            // 
            this.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem";
            this.RemoveToolStripMenuItem.Size = new System.Drawing.Size(214, 32);
            this.RemoveToolStripMenuItem.Text = "Удалить";
            this.RemoveToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // AddDir
            // 
            this.AddDir.BackgroundImage = global::FileManager2._0.Properties.Resources.plus_icon_icons_com_61187;
            this.AddDir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AddDir.ForeColor = System.Drawing.SystemColors.Control;
            this.AddDir.Location = new System.Drawing.Point(41, 78);
            this.AddDir.Name = "AddDir";
            this.AddDir.Size = new System.Drawing.Size(34, 34);
            this.AddDir.TabIndex = 10;
            this.AddDir.UseVisualStyleBackColor = true;
            this.AddDir.Click += new System.EventHandler(this.AddDir_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 611);
            this.Controls.Add(this.AddDir);
            this.Controls.Add(this.SearchMask);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.GetDir);
            this.Controls.Add(this.InfoFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InfoDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FilePath);
            this.Controls.Add(this.Mask);
            this.Controls.Add(this.DirsTable);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DirsTable)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Mask;
        private System.Windows.Forms.TextBox FilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InfoDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox InfoFile;
        private System.Windows.Forms.Button GetDir;
        private System.Windows.Forms.DataGridView DirsTable;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button SearchMask;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem RenameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyToolStripMenuItem;
        private System.Windows.Forms.Button AddDir;
    }
}

