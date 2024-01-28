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
    public partial class NewProductForm : Form
    {

        public Form1 mainForm;
        public NewProductForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string queryString = $"select * from Товар where Name = ('" + textBox1.Text + "')";
            SqlCommand command = new SqlCommand(queryString, mainForm.dataBase.getConnection());
            mainForm.dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read()) //Проверим, получилось ли прочитать продукт с таким названием
            {
                label1.Text = "Продукт с таким названием уже существует.";
                mainForm.dataBase.closeConnection();
                reader.Close();
            }
            else
            {
                reader.Close();
                queryString = $"insert into Товар (Name) VALUES ('" + textBox1.Text + "')";
                command = new SqlCommand(queryString, mainForm.dataBase.getConnection());
                

                reader = command.ExecuteReader();
                reader.Close();

                mainForm.dataBase.closeConnection();
                mainForm.RefreshDataGrid(mainForm.productGrid);
                Close();
            }
        }

        private void NewProductForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.addProductButton.Enabled = true;
        }
    }
}
