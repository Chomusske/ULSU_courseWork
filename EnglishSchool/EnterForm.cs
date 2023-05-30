using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EnglishSchool
{
    public partial class EnterForm : Form
    {
        MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
        public EnterForm()
        {
            InitializeComponent();
        }
        public EnterForm(MySqlConnectionStringBuilder conn_string)// конструктор с ссылкой на бд
        {
            this.conn_string = conn_string;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void EnterForm_FormClosed(object sender, FormClosedEventArgs e)//Если неугомонный польхователь закрыл через панель задач

        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)//Кнопка входа
        {
            MySqlDataReader read_res;
            int role;
            string user_id;
            MySqlConnection conn = new MySqlConnection(conn_string.ToString());
            MySqlCommand cmd = (MySqlCommand)conn.CreateCommand();

            string sql = "Select role, user_data_id from LoginInfo Where login = @login and password = @password";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@login", textBox1.Text.ToString());
            cmd.Parameters.AddWithValue("@password", textBox2.Text.ToString());

            try
            {   

                conn.Open();
                MessageBox.Show("Успешное подключение");

                read_res= cmd.ExecuteReader();
                read_res.Read();
                try { 
                    role = read_res.GetInt16(0);
                    user_id = read_res.GetString(1);
                    Program.Context.MainForm = new MainForm(conn_string, role, user_id);
                    Program.Context.MainForm.Show();
                    read_res.Close();
                    this.Close();

                        

                }
                catch { MessageBox.Show("Invalid LogIn Data!"); }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)//Кнопка выхода
        {
            Application.Exit();
        }
    }
}
