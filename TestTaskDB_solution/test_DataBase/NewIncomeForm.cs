using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_DataBase
{
    public partial class NewIncomeForm : Form
    {
        internal Form1 f1;
        internal Income mainForm;
        public NewIncomeForm()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        bool IsDate(string s)
        {
            int temp;
            if (s.Length != 10)
                return false;
            if (s[2] != '.' || s[5] != '.')
                return false;
            if (!int.TryParse(s.Substring(0, 2), out temp) || !int.TryParse(s.Substring(3, 2), out temp) || !int.TryParse(s.Substring(6, 4), out temp))
                return false;
            return true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int temp;
            if (int.TryParse(textBox2.Text, out temp) && IsDate(textBox3.Text)) //Проверим корректность ввода данных. Если данные некорректны, ничего не меняем.
            {
                //Проверим, если такого товара нет в списке товаров, то добавим
                string queryString = $"select * from Товар where Name = '{textBox1.Text}'";
                SqlCommand command = new SqlCommand(queryString, f1.dataBase.getConnection());
                f1.dataBase.openConnection();
                SqlDataReader reader = command.ExecuteReader();
                if (!reader.Read()) //Проверим, получилось ли прочитать продукт с таким названием
                {
                    reader.Close();
                    queryString = $"insert into Товар (Name) VALUES ('{textBox1.Text}')";
                    command = new SqlCommand(queryString, f1.dataBase.getConnection());
                    reader = command.ExecuteReader();
                    reader.Close();
                    f1.RefreshDataGrid(f1.productGrid);

                }
                else
                    reader.Close();

                string date = textBox3.Text.Substring(6) + "-" + textBox3.Text.Substring(3, 2) + "-" + textBox3.Text.Substring(0, 2);
                queryString = $"insert into {mainForm.tableName} (Product, Quantity, Date) VALUES ('{textBox1.Text}',{textBox2.Text},'{date}')";
                command = new SqlCommand(queryString, f1.dataBase.getConnection());
                f1.dataBase.openConnection();
                reader = command.ExecuteReader();
                reader.Close();
                f1.dataBase.closeConnection();
                mainForm.RefreshDataGrid(mainForm.productGrid);
                Close();
            }
            else
                warningLabel.Text = "Некорректный ввод!";

        }

        private void NewIncomeForm_Load(object sender, EventArgs e)
        {

        }

        private void NewIncomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.addIncomeButton.Enabled = true;
        }
    }
}
