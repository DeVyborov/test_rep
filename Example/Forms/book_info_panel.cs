using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example.Forms
{
    public partial class book_info_panel : UserControl
    {
        public book_info_panel()
        {
            InitializeComponent();
        }

        string user_login = "";
        string user_password = "";
        int user_id = 0;

        public book_info_panel(string user_login_form, string user_password_form, int user_id_form, int id_user_role)
        {
            InitializeComponent();

            user_login = user_login_form;
            user_password = user_password_form; 
            user_id = user_id_form;

            label1.Text = user_login;
            label2.Text = user_password;

            button1.Text = "Редактировать: " + user_id.ToString();

            if(id_user_role == 1)
            {
                button2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(user_id.ToString());
        }
    }
}
