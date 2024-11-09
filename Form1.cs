using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace demoP2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database database = new Database();

            var login = textBox1.Text;
            var password = textBox2.Text;

            string query = $"insert into register(login_user, password_user) values ('{login}', '{password}')";
            SqlCommand command = new SqlCommand(query, database.GetConnection());
            database.openConnection();
            if(command.ExecuteNonQuery() == 1) 
            {
                MessageBox.Show("Аккаунт успешно создан!", "Успех!");
                Form2 form2 = new Form2();
                this.Hide();
                form2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Аккаунт не создан!");
            }
            database.closeConnection();
        }
    }
}
