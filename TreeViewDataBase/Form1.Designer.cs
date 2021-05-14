
namespace TreeViewDataBase
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.деревоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьДанныеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьДанныеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.добавитьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.удалитьДанныеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 24);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(800, 426);
            this.treeView.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.деревоToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // деревоToolStripMenuItem
            // 
            this.деревоToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обновитьДанныеToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.добавитьДанныеToolStripMenuItem,
            this.изменитьДанныеToolStripMenuItem1,
            this.toolStripMenuItem2,
            this.удалитьДанныеToolStripMenuItem1});
            this.деревоToolStripMenuItem.Name = "деревоToolStripMenuItem";
            this.деревоToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.деревоToolStripMenuItem.Text = "Дерево";
            // 
            // обновитьДанныеToolStripMenuItem1
            // 
            this.обновитьДанныеToolStripMenuItem1.Name = "обновитьДанныеToolStripMenuItem1";
            this.обновитьДанныеToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.обновитьДанныеToolStripMenuItem1.Text = "Обновить данные";
            this.обновитьДанныеToolStripMenuItem1.Click += new System.EventHandler(this.обновитьДанныеToolStripMenuItem1_Click);
            // 
            // изменитьДанныеToolStripMenuItem1
            // 
            this.изменитьДанныеToolStripMenuItem1.Name = "изменитьДанныеToolStripMenuItem1";
            this.изменитьДанныеToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.изменитьДанныеToolStripMenuItem1.Text = "Изменить данные";
            this.изменитьДанныеToolStripMenuItem1.Click += new System.EventHandler(this.изменитьДанныеToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // добавитьДанныеToolStripMenuItem
            // 
            this.добавитьДанныеToolStripMenuItem.Name = "добавитьДанныеToolStripMenuItem";
            this.добавитьДанныеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.добавитьДанныеToolStripMenuItem.Text = "Добавить данные";
            this.добавитьДанныеToolStripMenuItem.Click += new System.EventHandler(this.добавитьДанныеToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // удалитьДанныеToolStripMenuItem1
            // 
            this.удалитьДанныеToolStripMenuItem1.Name = "удалитьДанныеToolStripMenuItem1";
            this.удалитьДанныеToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.удалитьДанныеToolStripMenuItem1.Text = "Удалить данные";
            this.удалитьДанныеToolStripMenuItem1.Click += new System.EventHandler(this.удалитьДанныеToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Древовидное представление";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem деревоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьДанныеToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem добавитьДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьДанныеToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem удалитьДанныеToolStripMenuItem1;
    }
}

