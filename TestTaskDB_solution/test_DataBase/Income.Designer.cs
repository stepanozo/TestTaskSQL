namespace test_DataBase
{
    partial class Income
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
            this.productGrid = new System.Windows.Forms.DataGridView();
            this.addIncomeButton = new System.Windows.Forms.Button();
            this.deleteIncomeButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // productGrid
            // 
            this.productGrid.AllowUserToAddRows = false;
            this.productGrid.AllowUserToDeleteRows = false;
            this.productGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productGrid.Location = new System.Drawing.Point(12, 27);
            this.productGrid.Name = "productGrid";
            this.productGrid.ReadOnly = true;
            this.productGrid.Size = new System.Drawing.Size(459, 380);
            this.productGrid.TabIndex = 3;
            // 
            // addIncomeButton
            // 
            this.addIncomeButton.Location = new System.Drawing.Point(494, 27);
            this.addIncomeButton.Name = "addIncomeButton";
            this.addIncomeButton.Size = new System.Drawing.Size(216, 75);
            this.addIncomeButton.TabIndex = 4;
            this.addIncomeButton.Text = "Добавить";
            this.addIncomeButton.UseVisualStyleBackColor = true;
            this.addIncomeButton.Click += new System.EventHandler(this.addIncomeButton_Click);
            // 
            // deleteIncomeButton
            // 
            this.deleteIncomeButton.Location = new System.Drawing.Point(494, 120);
            this.deleteIncomeButton.Name = "deleteIncomeButton";
            this.deleteIncomeButton.Size = new System.Drawing.Size(216, 75);
            this.deleteIncomeButton.TabIndex = 5;
            this.deleteIncomeButton.Text = "Удалить";
            this.deleteIncomeButton.UseVisualStyleBackColor = true;
            this.deleteIncomeButton.Click += new System.EventHandler(this.deleteIncomeButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(494, 211);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(216, 75);
            this.changeButton.TabIndex = 6;
            this.changeButton.Text = "Изменить";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(494, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Начало периода";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(494, 324);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "01.01.2000";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(610, 324);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "31.12.2024";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(607, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Конец периода";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(494, 361);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 46);
            this.button1.TabIndex = 11;
            this.button1.Text = "Обновить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Income
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.deleteIncomeButton);
            this.Controls.Add(this.addIncomeButton);
            this.Controls.Add(this.productGrid);
            this.Name = "Income";
            this.Text = "Приход";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Income_FormClosed);
            this.Load += new System.EventHandler(this.Income_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView productGrid;
        private System.Windows.Forms.Button deleteIncomeButton;
        internal System.Windows.Forms.Button addIncomeButton;
        internal System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}