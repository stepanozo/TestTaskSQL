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
using System.Xml.Linq;

namespace test_DataBase
{

  

    public partial class RemainingProducts : Form
    {

        public Form1 mainForm;

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("Товар", "Товар");
            dataGridView1.Columns.Add("Приход", "Приход");
            dataGridView1.Columns.Add("Расход", "Расход");
            dataGridView1.Columns.Add("В наличии", "В наличии");

        }


        internal void ReadSingleRow(DataGridView dgw, IDataReader record)
        {

            dgw.Rows.Add(record.GetString(0), record.GetInt32(1), record.GetInt32(2), record.GetInt32(3));//Записывает в таблицу ту строку, которая сейчас в записи (которую прочитали из базы данных)
        }

        internal void RefreshDataGrid(DataGridView dgw)
        {

            dgw.Rows.Clear(); //Очистим, чтобы считать из базы данных

            string queryString = $"select *, (Приход - Расход) as Остаток " +
                 $"from " +
                     $"( " +
                     $"select Товар.Name as Товар, coalesce(Приход,0) as Приход, coalesce(Расход,0) as Расход " +
                     $"from Товар " +
                     $"full join " +
                         $"(select sum(Quantity) as Расход, Product from Расход group by Product) as РасходыСумма " +
                     $"on Товар.Name = РасходыСумма.Product " +
                     $"left join " +
                         $"(select sum(Quantity) as Приход, Product from Приход group by Product) as ПриходыСумма " +
                     $"on Товар.Name = ПриходыСумма.Product " +
                     $") " +
                     $" as Табло where Приход-Расход > 0";

            //string queryString = $"select *, (Приход - Расход) as 'В наличии'\r\nfrom\r\n(\r\n\tselect Товар.Name as Товар, coalesce(Приход,0) as Приход, coalesce(Расход,0) as Расход\r\n\tfrom Товар \r\n\t full join\r\n\t\t\t(select sum(Quantity) as Расход, Product from Расход group by Product) as РасходыСумма\r\n\ton Товар.Name = РасходыСумма.Product\r\n\tleft join\r\n\t\t\t(select sum(Quantity) as Приход, Product from Приход group by Product) as ПриходыСумма\r\n\ton Товар.Name = ПриходыСумма.Product\r\n) \r\nas Табло";

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

        public RemainingProducts()
        {
            InitializeComponent();
        }

        private void RemainingProducts_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void RemainingProducts_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.товарыВНаличииToolStripMenuItem.Enabled = true;
        }
    }
}
