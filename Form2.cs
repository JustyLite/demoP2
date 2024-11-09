using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace demoP2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Database database = new Database();
        private void log_in_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox1.MaxLength = 50;
            textBox2.MaxLength = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loginUser = textBox1.Text;
            var passUser = textBox2.Text;

            SqlDataAdapter adapter  = new SqlDataAdapter();
            DataTable table = new DataTable();
            string query = $"select id_user,login_user,password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";
            SqlCommand command = new SqlCommand(query, database.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 form1 = new Form1();
                this.Hide();
                form1.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Такого аккаунта не существует!", "Аккаунта не существует", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
