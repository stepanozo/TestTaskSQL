namespace test_DataBase
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outcomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.productGrid = new System.Windows.Forms.DataGridView();
            this.delProductButton = new System.Windows.Forms.Button();
            this.addProductButton = new System.Windows.Forms.Button();
            this.товарыВНаличииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(421, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.incomeToolStripMenuItem,
            this.outcomeToolStripMenuItem,
            this.товарыВНаличииToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            this.файлToolStripMenuItem.Click += new System.EventHandler(this.файлToolStripMenuItem_Click);
            // 
            // incomeToolStripMenuItem
            // 
            this.incomeToolStripMenuItem.Name = "incomeToolStripMenuItem";
            this.incomeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.incomeToolStripMenuItem.Text = "Приход";
            this.incomeToolStripMenuItem.Click += new System.EventHandler(this.приходToolStripMenuItem_Click);
            // 
            // outcomeToolStripMenuItem
            // 
            this.outcomeToolStripMenuItem.Name = "outcomeToolStripMenuItem";
            this.outcomeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.outcomeToolStripMenuItem.Text = "Расход";
            this.outcomeToolStripMenuItem.Click += new System.EventHandler(this.outcomeToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // productGrid
            // 
            this.productGrid.AllowUserToAddRows = false;
            this.productGrid.AllowUserToDeleteRows = false;
            this.productGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productGrid.Location = new System.Drawing.Point(12, 27);
            this.productGrid.Name = "productGrid";
            this.productGrid.ReadOnly = true;
            this.productGrid.Size = new System.Drawing.Size(274, 365);
            this.productGrid.TabIndex = 2;
            this.productGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // delProductButton
            // 
            this.delProductButton.Location = new System.Drawing.Point(317, 27);
            this.delProductButton.Name = "delProductButton";
            this.delProductButton.Size = new System.Drawing.Size(98, 60);
            this.delProductButton.TabIndex = 3;
            this.delProductButton.Text = "Удалить товар";
            this.delProductButton.UseVisualStyleBackColor = true;
            this.delProductButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // addProductButton
            // 
            this.addProductButton.Location = new System.Drawing.Point(317, 102);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(98, 60);
            this.addProductButton.TabIndex = 4;
            this.addProductButton.Text = "Добавить товар";
            this.addProductButton.UseVisualStyleBackColor = true;
            this.addProductButton.Click += new System.EventHandler(this.addProductButton_Click);
            // 
            // товарыВНаличииToolStripMenuItem
            // 
            this.товарыВНаличииToolStripMenuItem.Name = "товарыВНаличииToolStripMenuItem";
            this.товарыВНаличииToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.товарыВНаличииToolStripMenuItem.Text = "Товары в наличии";
            this.товарыВНаличииToolStripMenuItem.Click += new System.EventHandler(this.товарыВНаличииToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 450);
            this.Controls.Add(this.addProductButton);
            this.Controls.Add(this.delProductButton);
            this.Controls.Add(this.productGrid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Тестовое задание";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button delProductButton;
        public System.Windows.Forms.Button addProductButton;
        public System.Windows.Forms.ToolStripMenuItem incomeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem outcomeToolStripMenuItem;
        internal System.Windows.Forms.DataGridView productGrid;
        internal System.Windows.Forms.ToolStripMenuItem товарыВНаличииToolStripMenuItem;
    }
}

