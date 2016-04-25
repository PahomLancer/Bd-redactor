using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'knigiDataSet.Книги' table. You can move, or remove it, as needed.
            this.книгиTableAdapter.Fill(this.knigiDataSet.Книги);
            // TODO: This line of code loads data into the 'knigiDataSet.Авторы' table. You can move, or remove it, as needed.
            this.авторыTableAdapter.Fill(this.knigiDataSet.Авторы);
            // TODO: This line of code loads data into the 'knigiDataSet.Автор_книги' table. You can move, or remove it, as needed.
            this.автор_книгиTableAdapter.Fill(this.knigiDataSet.Автор_книги);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            автор_книгиTableAdapter.Update(knigiDataSet);
            авторыTableAdapter.Update(knigiDataSet);
            автор_книгиTableAdapter.Update(knigiDataSet);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dataGridView4.DataSource = dt;
            dt.Clear();
            OleDbConnection connect = new
            OleDbConnection(global::Database.Properties.Settings.Default.knigiConnectionString);
            connect.Open();
            //string strSQL = "SELECT * FROM Авторы";
            //string strSQL = "SELECT Авторы.Фамилия, Книги.Название FROM Авторы, Книги, Автор_книги where Авторы.ID=Автор_книги.ID_автора and Книги.ID=Автор_книги.ID_книги";
            string strSQL = "SELECT Авторы.Фамилия, Книги.Название FROM Авторы, Книги, Автор_книги where Авторы.ID=Автор_книги.ID_автора and Книги.ID=Автор_книги.ID_книги and Авторы.Фамилия='"+textBox1.Text+"'";
            OleDbDataAdapter da = new OleDbDataAdapter(strSQL, connect);
            da.Fill(dt);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dataGridView4.DataSource = dt;
            dt.Clear();
            OleDbConnection connect = new
            OleDbConnection(global::Database.Properties.Settings.Default.knigiConnectionString);
            connect.Open();
            //string strSQL = "SELECT * FROM Авторы";
            //string strSQL = "SELECT Авторы.Фамилия, Книги.Название FROM Авторы, Книги, Автор_книги where Авторы.ID=Автор_книги.ID_автора and Книги.ID=Автор_книги.ID_книги";
            string strSQL = "SELECT Авторы.Фамилия, Книги.Название FROM Авторы, Книги, Автор_книги where Авторы.ID=Автор_книги.ID_автора and Книги.ID=Автор_книги.ID_книги and Книги.Название='" + textBox2.Text + "'";
            OleDbDataAdapter da = new OleDbDataAdapter(strSQL, connect);
            da.Fill(dt);
        }
    }
}
