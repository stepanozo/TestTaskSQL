using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_DataBase
{
    public partial class Form1 : Form
    {
        Income incomeForm;
        Income outcomeForm;
        RemainingProducts remainingProductsForm;
        NewProductForm newProductForm;


        internal DataBase dataBase = new DataBase();

        public Form1()
        {
            InitializeComponent();
        }

        private void CreateColumns()
        {
            productGrid.Columns.Add("ID_product", "ID_product");
            productGrid.Columns.Add("Name", "Name");
        }

        internal void ReadSingleRow(DataGridView dgw, IDataReader record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1)); //Записывает в таблицу ту строку, которая сейчас в записи (которую прочитали из базы данных)
        }

        internal void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear(); //Очистим, чтобы считать из базы данных

            string queryString = $"select * from Товар";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection()); //Создали команду, в качестве параметров - запрос в формате строки и соединение с базой данных

            dataBase.openConnection(); 

            SqlDataReader reader = command.ExecuteReader(); 

            while(reader.Read())
            {
                ReadSingleRow(dgw, reader); //Пока ридер что-то ещё считывает, записываем в нашу таблицу строки, которые он читает
            }
            reader.Close();
            dataBase.closeConnection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(productGrid);
        }

        private void товарыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void приходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            incomeForm = new Income("Приход");
            incomeForm.mainForm = this;
            incomeForm.Show();
            incomeToolStripMenuItem.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Удалим также приходы и уходы с этим товаром, если удаляем сам товар
            string queryString = $"delete from Товар where Name ='" + Convert.ToString(productGrid[1, productGrid.CurrentCell.RowIndex].Value)+"'"
                + $" delete from Приход where Product ='" + Convert.ToString(productGrid[1, productGrid.CurrentCell.RowIndex].Value) + "'" +
                 $" delete from Расход where Product ='" + Convert.ToString(productGrid[1, productGrid.CurrentCell.RowIndex].Value) + "'";
            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();
            reader.Close();

            
          
            dataBase.closeConnection();
            RefreshDataGrid(productGrid);
            if(incomeForm!=null && incomeForm.Created)
                incomeForm.RefreshDataGrid(incomeForm.productGrid);
            if(outcomeForm!=null && outcomeForm.Created)
                 outcomeForm.RefreshDataGrid(outcomeForm.productGrid);


        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            newProductForm = new NewProductForm();
            newProductForm.mainForm = this;
            newProductForm.Show();
            addProductButton.Enabled = false;

        }

        private void outcomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            outcomeForm = new Income("Расход");
            outcomeForm.mainForm = this;
            outcomeForm.Show();
            outcomeToolStripMenuItem.Enabled = false;
        }

        private void товарыВНаличииToolStripMenuItem_Click(object sender, EventArgs e)
        {

            remainingProductsForm = new RemainingProducts();
            remainingProductsForm.mainForm = this;
            remainingProductsForm.Show();
            товарыВНаличииToolStripMenuItem.Enabled = false;
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
