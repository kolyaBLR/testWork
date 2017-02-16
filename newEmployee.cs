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

namespace SqlServerAndStruct
{
    public partial class newEmployee : Form
    {
        private string connectionString;
        private string status;

        public newEmployee(string _connectionString, string _status)
        {
            try
            {
                InitializeComponent();
                connectionString = _connectionString;
                status = _status;
                if (status == "delete")
                    button2.Text = "Удалить";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void delete(string tb4, string tb5)
        {
            try
            {
                using (SqlConnection SqlCon = new SqlConnection(connectionString))
                {
                    SqlCon.Open();
                    string sql = "DelEmp";
                    using (SqlCommand SqlCom = new SqlCommand(sql, SqlCon))
                    {
                        Employees emp = new Employees(textBox1.Text, textBox2.Text, textBox3.Text, int.Parse(tb4), int.Parse(tb5));
                        SqlCom.CommandType = CommandType.StoredProcedure;
                        SqlCom.Parameters.AddWithValue("@Имя", emp.name);
                        SqlCom.Parameters.AddWithValue("@Фамилия", emp.surname);
                        SqlCom.Parameters.AddWithValue("@Должность", emp.position);
                        SqlCom.Parameters.AddWithValue("@ГодРождения", emp.year);
                        SqlCom.Parameters.AddWithValue("@Зарплата", emp.salary);
                        SqlCom.ExecuteNonQuery();
                        MessageBox.Show("Все сотрудники с такими данными успешно удалены.");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                    }
                    SqlCon.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void add(string tb4, string tb5)
        {
            try
            {
                using (SqlConnection SqlCon = new SqlConnection(connectionString))
                {
                    SqlCon.Open();
                    string sql = "INSERT INTO Сотрудники(Имя, Фамилия, Должность, ГодРождения, Зарплата) VALUES(@Имя, @Фамилия, @Должность, @ГодРождения, @Зарплата)";
                    using (SqlCommand SqlCom = new SqlCommand(sql, SqlCon))
                    {
                        Employees emp = new Employees(textBox1.Text, textBox2.Text, textBox3.Text, int.Parse(tb4), int.Parse(tb5));
                        SqlCom.Parameters.AddWithValue("@Имя", emp.name);
                        SqlCom.Parameters.AddWithValue("@Фамилия", emp.surname);
                        SqlCom.Parameters.AddWithValue("@Должность", emp.position);
                        SqlCom.Parameters.AddWithValue("@ГодРождения", emp.year);
                        SqlCom.Parameters.AddWithValue("@Зарплата", emp.salary);
                        SqlCom.ExecuteNonQuery();
                        MessageBox.Show("Сотрудник добавлен успешно.");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// сохранить сотрудника в бд
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "")
                    MessageBox.Show("Не возможно выполнить операцию. Заполните хотя бы одно поле.");
                else
                {
                    string tb4 = textBox4.Text, tb5 = textBox5.Text;
                    if (textBox4.Text == "")
                        tb4 = "0";
                    if (textBox5.Text == "")
                        tb5 = "0";
                    if (status == "add")
                        add(tb4, tb5);
                    else
                        delete(tb4, tb5);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
