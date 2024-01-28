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
using System.Runtime;
using System.Reflection;

namespace test_DataBase
{

    public partial class Income : Form
    {

        //Эти два поля могут меняться в зависимости от того, для прихода эта форма или для расхода
        internal string tableName;
        internal string idName;

        public Form1 mainForm;
        public NewIncomeForm newIncomeForm;
        public ChangeIncome changeIncomeForm;

        public Income(string tableName)
        {
            this.tableName = tableName;
            idName = (tableName == "Приход") ? "ID_Income" : "ID_outcome";
            InitializeComponent();
        }


        internal void ReadSingleRow(DataGridView dgw, IDataReader record)
        {
            
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), Convert.ToString(record.GetDateTime(3)).Substring(0, 10) ) ;//Записывает в таблицу ту строку, которая сейчас в записи (которую прочитали из базы данных)
        }
        
        internal void RefreshDataGrid(DataGridView dgw, string stringDate1 = "01.01.2000" , string stringDate2 = "31.12.2024")
        {

            stringDate1 = stringDate1.Substring(6) + "-" + stringDate1.Substring(3, 2) + "-" + stringDate1.Substring(0, 2);
            stringDate2 = stringDate2.Substring(6) + "-" + stringDate2.Substring(3, 2) + "-" + stringDate2.Substring(0, 2);

            dgw.Rows.Clear(); //Очистим, чтобы считать из базы данных

            string queryString = $"select * from {tableName} where Date > '{stringDate1}' and Date < '{stringDate2}'";

            SqlCommand command = new SqlCommand(queryString, mainForm.dataBase.getConnection()); //Создали команду, в качестве параметров - запрос в формате строки и соединение с базой данных

            mainForm.dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader); //Пока ридер что-то ещё считывает, записываем в нашу таблицу строки, которые он читает
            }
            reader.Close();
            mainForm.dataBase.closeConnection();

        }


        private void CreateColumns()
        {
            productGrid.Columns.Add($"{idName}", $"{idName}");
            productGrid.Columns.Add("Product", "Product");
            productGrid.Columns.Add("Quantity", "Quantity");
            productGrid.Columns.Add("Date", "Date");

        }


        private void Income_Load(object sender, EventArgs e)
        {
            this.Text = tableName;
            CreateColumns();
            RefreshDataGrid(productGrid); 
        }

        private void Income_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            //Разблокируем соответствующую кнопку в зависимости от того, на какую таблицу в базе ссылается форма
            ToolStripMenuItem itm = (tableName == "Приход") ? mainForm.incomeToolStripMenuItem : mainForm.outcomeToolStripMenuItem;
            itm.Enabled = true;
        }

        private void deleteIncomeButton_Click(object sender, EventArgs e)
        {
            int index = productGrid.CurrentCell.RowIndex;
            string currentID = Convert.ToString(productGrid[0, index].Value);

            //Проверяем именно по ID, потому что могут быть две абсолютно одинаковые операции в 1 день. У них будет различаться только ID.
            string queryString = $"delete from {tableName} where {idName} ='{currentID}'";  
            SqlCommand command = new SqlCommand(queryString, mainForm.dataBase.getConnection());
            mainForm.dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();
            reader.Close();
            mainForm.dataBase.closeConnection();
            RefreshDataGrid(productGrid);
        }

        private void addIncomeButton_Click(object sender, EventArgs e)
        {
            newIncomeForm = new NewIncomeForm();
            newIncomeForm.Show();
            newIncomeForm.f1 = this.mainForm;
            newIncomeForm.mainForm = this;
            addIncomeButton.Enabled = false;
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            changeIncomeForm = new ChangeIncome();
            int index = productGrid.CurrentCell.RowIndex;
            changeIncomeForm.currentID = Convert.ToInt32(productGrid[0, index].Value);
            changeIncomeForm.textBox1.Text = Convert.ToString(productGrid[1, index].Value);
            changeIncomeForm.textBox2.Text = Convert.ToString(productGrid[2, index].Value);
            changeIncomeForm.textBox3.Text = Convert.ToString(productGrid[3, index].Value);
            changeIncomeForm.Show();
     
            changeIncomeForm.f1 = this.mainForm;
            changeIncomeForm.mainForm = this;
            changeButton.Enabled = false;
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

            if(IsDate(textBox1.Text) && IsDate(textBox2.Text))
                RefreshDataGrid(productGrid, textBox1.Text, textBox2.Text);
        }
    }
}
