using Example.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example.Forms
{
    public partial class MainWindows : Form
    {
        public MainWindows()
        {
            InitializeComponent();

            StaticVars.panel = this.panel1;
        }

        private void MainWindows_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        public void UpdateData()
        {
            try
            {
                SQLclass.OpenConnection();

                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM auth", SQLclass.conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];


                SqlDataAdapter a_box = new SqlDataAdapter("SELECT login AS login, id FROM auth", SQLclass.conn);

                // заполнение данных
                DataSet ds_box = new DataSet();
                a_box.Fill(ds_box);

                comboBox1.DataSource = ds_box.Tables[0];
                comboBox1.DisplayMember = "login";
                comboBox1.ValueMember = "id";

                SQLclass.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int user_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            try
            {
                SQLclass.OpenConnection();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM auth WHERE id = '" + user_id + "'", SQLclass.conn);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    textBox1.Text = reader[0].ToString();
                    textBox2.Text = reader[1].ToString();
                    textBox3.Text = reader[2].ToString();
                }
                reader.Close();
                SQLclass.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    SQLclass.OpenConnection();

                    SqlCommand sqlCommand = new SqlCommand("UPDATE auth SET login = '" + textBox2.Text + "', password = '" + textBox3.Text + "' WHERE id = '" + textBox1.Text + "'", SQLclass.conn);
                    sqlCommand.ExecuteNonQuery();

                    SQLclass.CloseConnection();
                    UpdateData();
                    MessageBox.Show("Данные успешно изменены!");
                }
                else
                    MessageBox.Show("Пожалуйста заполните все данные!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text !="")
                {
                    SQLclass.OpenConnection();

                    SqlCommand sqlCommand = new SqlCommand("DELETE FROM auth WHERE id = '" + textBox1.Text + "'", SQLclass.conn);
                    sqlCommand.ExecuteNonQuery();

                    SQLclass.CloseConnection();
                    UpdateData();
                    MessageBox.Show($"Аккаунт под номером {textBox1.Text} успешно удален!");
                }               
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    SQLclass.OpenConnection();

                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO auth(login,password) VALUES (N'" + textBox2.Text + "', N'" + textBox3.Text + "')", SQLclass.conn);
                    sqlCommand.ExecuteNonQuery();

                    SQLclass.CloseConnection();
                    UpdateData();
                    MessageBox.Show($"Новый аккаунт успешно добавлен!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void MainWindows_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Autorization autorization = new Autorization();
            autorization.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            add_book add_Book = new add_book() { Dock = DockStyle.Fill, TopMost = true, TopLevel = false };
            panel1.Controls.Add(add_Book);
            add_Book.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            edit_book edit_Book = new edit_book() { Dock = DockStyle.Fill, TopMost = true, TopLevel = false };
            panel1.Controls.Add(edit_Book);
            edit_Book.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            catalog_form catalog_Form = new catalog_form() { Dock = DockStyle.Fill, TopMost = true, TopLevel = false };
            panel1.Controls.Add(catalog_Form);
            catalog_Form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            StaticVars.role_user = 1;
            MessageBox.Show("1");
        }
    }
}
