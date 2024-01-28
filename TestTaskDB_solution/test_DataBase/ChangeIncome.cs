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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace test_DataBase
{
    public partial class ChangeIncome : Form
    {

        internal Form1 f1;
        internal Income mainForm;

        internal int currentID;
        public ChangeIncome()
        {
            InitializeComponent();
        }

        private void ChangeIncome_Load(object sender, EventArgs e)
        {
        
        }

       bool IsDate(string s)
       {
            int temp;
            if (s.Length != 10)
                return false;
            if (s[2] != '.' || s[5] != '.')
                return false;
            if (!int.TryParse(s.Substring(0,2), out temp) || !int.TryParse(s.Substring(3, 2), out temp) || !int.TryParse(s.Substring(6, 4), out temp))
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
                queryString = $"update {mainForm.tableName} set Product = '{textBox1.Text}', Quantity = {textBox2.Text}, Date = '{date}' where {mainForm.idName} = {currentID}";
                command = new SqlCommand(queryString, f1.dataBase.getConnection());
                f1.dataBase.openConnection();
                reader = command.ExecuteReader();
                reader.Close();
                mainForm.RefreshDataGrid(mainForm.productGrid);
                f1.dataBase.closeConnection();
                Close();
            }
            else
                warningLabel.Text = "Некорректный ввод!";
            
        }

        private void ChangeIncome_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.changeButton.Enabled = true;
        }
    }
}
