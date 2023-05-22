using Example.Classes;
using Example.Forms;
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

namespace Example
{
    public partial class Autorization : Form
    {
        public Autorization()
        {
            InitializeComponent();
        }

        int check_login_user = 0;
        int check_password_user = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    SQLclass.OpenConnection();
                    SqlCommand sqlCommandLogin = new SqlCommand("SELECT COUNT(*) FROM auth WHERE login = '" + textBox1.Text + "'", SQLclass.conn);
                    SqlDataReader readerLogin = sqlCommandLogin.ExecuteReader();
                
                    while (readerLogin.Read())
                    {
                        check_login_user = Convert.ToInt32(readerLogin[0]);
                    }
                    readerLogin.Close();

                    if(check_login_user == 0)
                    {
                        MessageBox.Show("Данного аккаунта не существует в базе данных!", "Пожалуйста проверьте введенные данные!");
                        SQLclass.CloseConnection();
                    }
                    else
                    {
                        SqlCommand sqlCommandPassword = new SqlCommand("SELECT COUNT(*) FROM auth WHERE password = '" + textBox2.Text + "'", SQLclass.conn);
                        SqlDataReader readerPassword = sqlCommandPassword.ExecuteReader();

                        while (readerPassword.Read())
                        {
                            check_password_user = Convert.ToInt32(readerPassword[0]);
                        }
                        readerPassword.Close();


                        if (check_password_user == 1)
                        {
                            SQLclass.CloseConnection();
                            MessageBox.Show("Удачный вход");
                            this.Hide();
                            MainWindows mainWindows = new MainWindows();
                            mainWindows.Show();
                            
                        }
                        else
                        {
                            MessageBox.Show("Пароль введен не верно!");
                            SQLclass.CloseConnection();
                        }                        
                   }                   
                }
                else
                    MessageBox.Show("Пожалуйста введите данные в поля", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void Autorization_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
