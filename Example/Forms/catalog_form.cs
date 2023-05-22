using Example.Classes;
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

namespace Example.Forms
{
    public partial class catalog_form : Form
    {
        public catalog_form()
        {
            InitializeComponent();
        }

        int count_pull = 0;

        private void catalog_form_Load(object sender, EventArgs e)
        {
            GenerateData();
        }

        public void GenerateData()
        {
            SQLclass.OpenConnection();

            SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(id) FROM auth", SQLclass.conn);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                count_pull = Convert.ToInt32(reader[0]);
            }
            reader.Close();

            int x = 0;
            string[] users_ids = new string[count_pull];
            string[] users_loginss = new string[count_pull];
            string[] users_passwords = new string[count_pull];

            SqlCommand sqlCommand_get = new SqlCommand("SELECT * FROM auth", SQLclass.conn);
            SqlDataReader reader_get = sqlCommand_get.ExecuteReader();

            while (reader_get.Read())
            {
                users_ids[x] = reader_get[0].ToString();
                users_loginss[x] = reader_get[1].ToString();
                users_passwords[x] = reader_get[2].ToString();
                x++;
            }
            reader_get.Close();


            for (int i = 0; i < users_ids.Length; i++)
            {
                book_info_panel book_Info_Panel = new book_info_panel(users_loginss[i], users_passwords[i], Convert.ToInt32(users_ids[i]), StaticVars.role_user) { Dock = DockStyle.Top };
                panel1.Controls.Add(book_Info_Panel);
            }

            SQLclass.CloseConnection();
        }
    }
}
