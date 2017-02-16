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
    public partial class Form1 : Form
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Employees;Integrated Security=True";

        public Form1()
        {
            try
            {
                InitializeComponent();
                tableOpen();
                listPozition();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// получение списка должностей
        /// </summary>
        public void listPozition()
        {
            try
            {
                using (SqlConnection SqlCon = new SqlConnection(connectionString))
                {
                    SqlCon.Open();
                    using (SqlCommand SqlCom = new SqlCommand("SELECT DISTINCT Должность FROM Сотрудники", SqlCon))
                    {
                        SqlDataReader r = SqlCom.ExecuteReader();
                        comboBox1.Items.Clear();
                        comboBox1.Items.Add("все сотрудники");
                        while (r.Read())
                        {
                            comboBox1.Items.Add(r.GetString(0));
                        }
                        r.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// заполнение таблицы данными из базы
        /// </summary>
        public void tableOpen()
        {
            try
            {
                SqlConnection SqlCon = new SqlConnection(connectionString);
                SqlCommand SqlCom = new SqlCommand("SELECT * FROM Сотрудники;", SqlCon);
                SqlCon.Open();
                dataGridView1.ColumnCount = 5;
                dataGridView1.RowCount = 0;
                dataGridView1.Columns[0].HeaderText = "Имя";
                dataGridView1.Columns[1].HeaderText = "Фамилия";
                dataGridView1.Columns[2].HeaderText = "Должность";
                dataGridView1.Columns[3].HeaderText = "Год рождения";
                dataGridView1.Columns[4].HeaderText = "Зарплата";
                SqlDataReader r = SqlCom.ExecuteReader();
                int index = 0;
                while (r.Read())
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = r.GetString(0);
                    dataGridView1.Rows[index].Cells[1].Value = r.GetString(1);
                    dataGridView1.Rows[index].Cells[2].Value = r.GetString(2);
                    dataGridView1.Rows[index].Cells[3].Value = r.GetInt32(3);
                    dataGridView1.Rows[index].Cells[4].Value = r.GetInt32(4);
                    index++;
                }
                r.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// добавление сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                newEmployee form = new newEmployee(connectionString, "add");
                form.ShowDialog();
                tableOpen();
                listPozition();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// удаление сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                newEmployee form = new newEmployee(connectionString, "delete");
                form.ShowDialog();
                tableOpen();
                listPozition();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// фильтруем таблицу по выбраному значению
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "все сотрудники")
                {
                    tableOpen();
                    listPozition();
                }
                else
                    for (int i = 1; i < comboBox1.Items.Count; i++)
                    {
                        if (comboBox1.Text == comboBox1.Items[i].ToString())
                        {
                            using (SqlConnection SqlCon = new SqlConnection(connectionString))
                            {
                                SqlCon.Open();
                                using (SqlCommand SqlCom = new SqlCommand("SELECT * FROM Сотрудники WHERE Должность='" + comboBox1.Items[i] + "'", SqlCon))
                                {
                                    SqlDataReader r = SqlCom.ExecuteReader();
                                    int index = 0;
                                    dataGridView1.RowCount = 0;
                                    while (r.Read())
                                    {
                                        dataGridView1.Rows.Add();
                                        dataGridView1.Rows[index].Cells[0].Value = r.GetString(0);
                                        dataGridView1.Rows[index].Cells[1].Value = r.GetString(1);
                                        dataGridView1.Rows[index].Cells[2].Value = r.GetString(2);
                                        dataGridView1.Rows[index].Cells[3].Value = r.GetInt32(3);
                                        dataGridView1.Rows[index].Cells[4].Value = r.GetInt32(4);
                                        index++;
                                    }
                                    r.Close();
                                }
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// обновить таблицу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                tableOpen();
                listPozition();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// отчёт
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Report form = new Report();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
