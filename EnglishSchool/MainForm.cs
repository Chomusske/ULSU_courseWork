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
    public partial class MainForm : Form
    {
        MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
        int role;
        int logic_variant;
        string user_id;
        public MainForm()
        {
            InitializeComponent();
        }
        public MainForm(MySqlConnectionStringBuilder conn_string, int role, string user_id)// конструктор с ссылкой на бд
        {
            this.conn_string = conn_string;
            this.role = role;
            this.user_id = user_id;
            InitializeComponent(role);

            
        }
        //admin buttons
        private void students_button_Click(object sender, EventArgs e)//Кнопка выхода
        {
            //Application.Exit();
            logic_variant = 0;
            
            LogicForm form= new LogicForm(this.conn_string,logic_variant,user_id);
            this.Hide();
            form.Closed += (o, args) => { this.Show(); };
            form.Show();
        }

        private void schedule_button_Click(object sender, EventArgs e)//Кнопка выхода
        {
            //Application.Exit();
            logic_variant = 1;
            LogicForm form = new LogicForm(this.conn_string, logic_variant, user_id);
            this.Hide();
            form.Closed += (o, args) => { this.Show(); };
            form.Show();
        }

        private void groups_button_Click(object sender, EventArgs e)//Кнопка выхода
        {
            //Application.Exit();
            logic_variant = 2;
            LogicForm form = new LogicForm(this.conn_string, logic_variant, user_id);
            this.Hide();
            form.Closed += (o, args) => { this.Show(); };
            form.Show();
        }
        private void users_button_Click(object sender, EventArgs e)//Кнопка выхода
        {
            //Application.Exit();
            logic_variant = 3;
            LogicForm form = new LogicForm(this.conn_string, logic_variant, user_id);
            this.Hide();
            form.Closed += (o, args) => { this.Show(); };
            form.Show();
        }
        //
        //user_buttons
        private void exircise_button_Click(object sender, EventArgs e)//Кнопка выхода
        {
            //Application.Exit();
            logic_variant = 6;
            LogicForm form = new LogicForm(this.conn_string, logic_variant, user_id);
            this.Hide();
            form.Closed += (o, args) => { this.Show(); };
            form.Show();
        }

        private void user_schedule_button_Click(object sender, EventArgs e)//Кнопка выхода
        {
            //Application.Exit();
            logic_variant = 4;
            LogicForm form = new LogicForm(this.conn_string, logic_variant, user_id);
            this.Hide();
            form.Closed += (o, args) => { this.Show(); };
            form.Show();
        }

        private void user_groups_button_Click(object sender, EventArgs e)//Кнопка выхода
        {
            //Application.Exit();
            logic_variant = 5;
            LogicForm form = new LogicForm(this.conn_string, logic_variant, user_id);
            this.Hide();
            form.Closed += (o, args) => { this.Show(); };
            form.Show();
        }
        //
        private void exit_button_Click(object sender, EventArgs e)//Кнопка выхода
        {
            Application.Exit();
        }
    }
}
