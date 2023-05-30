using MySql.Data.MySqlClient;
using MySql.Data.Types;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace EnglishSchool
{
    public partial class DetailView : Form
    {
        DataTable dt = new DataTable();
        DataTable dt_2= new DataTable();
        DataTable teachers = new DataTable();
        DataTable groups = new DataTable();
        MySqlConnectionStringBuilder conn_string;
        int row_id;
        MySqlConnection conn;
        MySqlCommand cmd;
        public DetailView()
        {
            InitializeComponent();
        }
        public DetailView(MySqlConnectionStringBuilder conn_string, int row_id, int variant)//student detail/change view
        {
            MessageBox.Show(row_id.ToString());
            conn = new MySqlConnection(conn_string.ToString());
            cmd = (MySqlCommand)conn.CreateCommand();
            this.conn_string = conn_string;
            this.BackColor = Color.Gray;
            if (variant == 0)
            {
                this.row_id = row_id;

                InitializeComponent();

                FillForStudentChanges();
            }
            else if (variant == 1)
            {
                this.row_id = row_id;

                InitializeComponent();

                FillForStudentDetails();
            }
            else if (variant == 3)
            {
                this.row_id = row_id;

                InitializeComponent();

                FillForScheduleDetails();
            }
            else if (variant == 4)
            {
                this.row_id = row_id;

                InitializeComponent();

                FillForSchedulePeriodChange();
            }
            else if (variant == 6)
            {
                this.row_id = row_id;

                InitializeComponent();

                FillForGroupDetails();

                //this.Load += new EventHandler(Form1_Load);
            }
            else if (variant == 7)
            {
                this.row_id = row_id;

                InitializeComponent();

                FillForUserDetails();
            }
            else if (variant == 8)
            {
                this.row_id = row_id;

                InitializeComponent();

                FillForUserChanges();
            }
            else if (variant == 10)
            {
                this.row_id = row_id;

                InitializeComponent();

                FillForUserScheduleDetails();
            }
            

        }
        public DetailView(MySqlConnectionStringBuilder conn_string, int variant)//student add view
        {
            conn = new MySqlConnection(conn_string.ToString());
            cmd = (MySqlCommand)conn.CreateCommand();
            this.conn_string = conn_string;
            this.BackColor = Color.Gray;
            if (variant == 2)
            {
                
                InitializeComponent();
                this.ClientSize = new System.Drawing.Size(600, 800);
                this.exit_button.Location = new System.Drawing.Point(Size.Width - 90, 10);
                FillForAddStudent();
            }
            else if (variant == 5) 
            {
                InitializeComponent();

                FillForScheduleAdding();
            }
            else if (variant == 9)
            {
                InitializeComponent();

                FillForAddUser();
            }
        }
        private void exit_button_Click(object sender, EventArgs e)//Кнопка выхода
        {
            this.Close();
        }
        //
        //studetns
        //
        private void exit_button_refresh()
        {
            this.exit_button.Location = new System.Drawing.Point(Size.Width - 90, 10);
        }

        private void GetStudentInfo()
        {
            cmd.CommandText = "SELECT id, FIO, age, spec, phone, parent_info, start_date, exercise_amount, status, change_date FROM students Where id = @id";
            cmd.Parameters.AddWithValue("@id", this.row_id);
            conn.Open();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                dt.Clear();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                }
            }
            conn.Close();
            cmd.Parameters.Clear();
        }

        private void FillForStudentDetails()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            GetStudentInfo();
            //
            //data_layout
            //
            this.id = new System.Windows.Forms.TextBox();
            this.first_name = new System.Windows.Forms.TextBox();
            this.second_name= new System.Windows.Forms.TextBox();
            this.last_name= new System.Windows.Forms.TextBox();
            this.phone = new System.Windows.Forms.MaskedTextBox();
            //
            this.id_label = new System.Windows.Forms.Label();
            this.first_name_label = new System.Windows.Forms.Label();
            this.second_name_label = new System.Windows.Forms.Label();
            this.last_name_label = new System.Windows.Forms.Label();
            this.phone_label = new System.Windows.Forms.Label();
            //
            this.delete_student= new System.Windows.Forms.Button();
            //
            this.delete_student.Location = new System.Drawing.Point(Size.Width - 250, 10);
            this.delete_student.Name = "delete_student";
            this.delete_student.Size = new System.Drawing.Size(150, 60);
            this.delete_student.TabIndex = 0;
            this.delete_student.Text = "Удалить студента";
            this.delete_student.UseVisualStyleBackColor = true;
            this.delete_student.Click += new System.EventHandler(this.delete_student_Button_Click);
            //
            this.Controls.Add(this.delete_student);
            //
            //
            this.add_ex_amount = new System.Windows.Forms.Button();
            //
            this.add_ex_amount.Location = new System.Drawing.Point(Size.Width - 500, Size.Height-150);
            this.add_ex_amount.Name = "add_ex";
            this.add_ex_amount.Size = new System.Drawing.Size(150, 60);
            this.add_ex_amount.TabIndex = 0;
            this.add_ex_amount.Text = "добавить занятий";
            this.add_ex_amount.UseVisualStyleBackColor = true;
            this.add_ex_amount.Click += new System.EventHandler(this.add_ex_Button_Click);
            //
            this.Controls.Add(this.add_ex_amount);
            //
            //
            this.ex_amount_ch = new System.Windows.Forms.TextBox();
            this.ex_amount_label_ch = new System.Windows.Forms.Label();
            //
            this.ex_amount_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ex_amount_label_ch.ForeColor = Color.AntiqueWhite;
            this.ex_amount_label_ch.Location = new System.Drawing.Point(Size.Width - 340, Size.Height - 150);
            this.ex_amount_label_ch.Name = "ex_amount";
            this.ex_amount_label_ch.AutoSize = true;
            this.ex_amount_label_ch.Text = "Кол-во \nзанятий";
            //
            this.ex_amount_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ex_amount_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ex_amount_ch.Location = new System.Drawing.Point(Size.Width - 230, Size.Height - 150);
            this.ex_amount_ch.Name = "ex_amount";
            this.ex_amount_ch.Size = new System.Drawing.Size(60, 60);
            this.ex_amount_ch.MaxLength = 4;
            this.ex_amount_ch.TabIndex = 0;
            this.ex_amount_ch.ReadOnly = false;
            //
            this.Controls.Add(this.ex_amount_ch);
            this.Controls.Add(this.ex_amount_label_ch);
            //
            //
            int height = 60;
            // 
            // id
            // 
            this.id_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.id_label.ForeColor = Color.AntiqueWhite;
            this.id_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
            this.id_label.Name = "id";
            this.id_label.Text= "id";
            //
            this.id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.id.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(240, 30);
            this.id.TabIndex = 0;
            this.id.ReadOnly= true;
            // 
            // last_name
            // 
            height += 50;
            this.last_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.last_name_label.ForeColor = Color.AntiqueWhite;
            this.last_name_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
            this.last_name_label.Name = "last_name";
            this.last_name_label.Text = "Фамилия";
            //
            this.last_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.last_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.last_name.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.last_name.Name = "FIO";
            this.last_name.Size = new System.Drawing.Size(240, 30);
            this.last_name.TabIndex = 1;
            this.last_name.ReadOnly = true;
            // 
            // first_name
            // 
            height += 50;
            this.first_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.first_name_label.ForeColor = Color.AntiqueWhite;
            this.first_name_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
            this.first_name_label.Name = "first_name";
            this.first_name_label.Text = "Имя";
            //
            this.first_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.first_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.first_name.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.first_name.Name = "FIO";
            this.first_name.Size = new System.Drawing.Size(240, 30);
            this.first_name.TabIndex = 1;
            this.first_name.ReadOnly = true;
            // 
            // second_name
            // 
            height += 50;
            this.second_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.second_name_label.ForeColor = Color.AntiqueWhite;
            this.second_name_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
            this.second_name_label.Name = "second_name";
            this.second_name_label.Text = "Отчество ";
            //
            this.second_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.second_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.second_name.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.second_name.Name = "FIO";
            this.second_name.Size = new System.Drawing.Size(240, 30);
            this.second_name.TabIndex = 1;
            this.second_name.ReadOnly = true;
            // 
            // phone
            // 
            height += 50;
            this.phone_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phone_label.ForeColor = Color.AntiqueWhite;
            this.phone_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
            this.phone_label.Name = "id";
            this.phone_label.Text = "Телефон";
            //
            this.phone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phone.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(240, 30);
            this.phone.TabIndex = 2;
            this.phone.ReadOnly = true;
            this.phone.Mask = "+7(000)000-00-00";
            //
            //
            this.Controls.Add(this.id);
            this.Controls.Add(this.first_name);
            this.Controls.Add(this.second_name);
            this.Controls.Add(this.last_name);
            this.Controls.Add(this.phone);
            //
            this.Controls.Add(this.id_label);
            this.Controls.Add(this.first_name_label);
            this.Controls.Add(this.second_name_label);
            this.Controls.Add(this.last_name_label);
            this.Controls.Add(this.phone_label);
            //
            //
            string[] fio_string = dt.Rows[0].Field<string>("FIO").Split(' ');
            //
            //
            this.id.Text = dt.Rows[0].Field<int>("id").ToString();
            this.first_name.Text = fio_string[1];
            this.second_name.Text = fio_string[2];
            this.last_name.Text = fio_string[0];
            //
            //
            if (dt.Rows[0].Field<string>("phone")==null)
            {
                this.phone.Text = "Отсутствует";
            }
            else { this.phone.Text = dt.Rows[0].Field<string>("phone"); }
            //
            //
            if (dt.Rows[0].Field<string>("parent_info")!=null)
            {
                this.parent_first_name = new System.Windows.Forms.TextBox();
                this.parent_second_name = new System.Windows.Forms.TextBox();
                this.parent_last_name = new System.Windows.Forms.TextBox();
                this.parent_workplace = new System.Windows.Forms.TextBox();
                this.parent_phone = new System.Windows.Forms.MaskedTextBox();
                //
                this.parent_info_label = new System.Windows.Forms.Label();
                //
                string[] parent_info = dt.Rows[0].Field<string>("parent_info").Split(' ');
                // 
                // parent_first_name
                // 
                this.parent_first_name = new System.Windows.Forms.TextBox();
                height += 50;
                this.parent_info_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.parent_info_label.ForeColor = Color.AntiqueWhite;
                this.parent_info_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
                this.parent_info_label.AutoSize = true;
                this.parent_info_label.Name = "parent_info";
                this.parent_info_label.Text = "ФИО родителя\nместо работы\nтелефон";
                //
                this.parent_first_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.parent_first_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.parent_first_name.Location = new System.Drawing.Point(Size.Width - 850, height);
                this.parent_first_name.Name = "parent_FIO";
                this.parent_first_name.Size = new System.Drawing.Size(240, 30);
                this.parent_first_name.TabIndex = 1;
                this.parent_first_name.ReadOnly = true;
                // 
                // parent_second_name
                // 
                height += 50;
                this.parent_second_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.parent_second_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.parent_second_name.Location = new System.Drawing.Point(Size.Width - 850, height);
                this.parent_second_name.Name = "parent_FIO";
                this.parent_second_name.Size = new System.Drawing.Size(240, 30);
                this.parent_second_name.TabIndex = 1;
                this.parent_second_name.ReadOnly = true;
                // 
                // parent_last_name
                // 
                height += 50;
                this.parent_last_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.parent_last_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.parent_last_name.Location = new System.Drawing.Point(Size.Width - 850, height);
                this.parent_last_name.Name = "parent_FIO";
                this.parent_last_name.Size = new System.Drawing.Size(240, 30);
                this.parent_last_name.TabIndex = 1;
                this.parent_last_name.ReadOnly = true;
                // 
                // parent_workplace
                // 
                height += 50;
                this.parent_workplace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.parent_workplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.parent_workplace.Location = new System.Drawing.Point(Size.Width - 850, height);
                this.parent_workplace.Name = "parent_workplace";
                this.parent_workplace.Size = new System.Drawing.Size(240, 30);
                this.parent_workplace.TabIndex = 1;
                this.parent_workplace.ReadOnly = true;
                // 
                // parent_phone
                // 
                height += 50;
                this.parent_phone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.parent_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.parent_phone.Location = new System.Drawing.Point(Size.Width - 850, height);
                this.parent_phone.Name = "parent_phone";
                this.parent_phone.Size = new System.Drawing.Size(240, 30);
                this.parent_phone.TabIndex = 2;
                this.parent_phone.ReadOnly = true;
                this.parent_phone.Mask = "+7(000)000-00-00";
                //
                //
                this.Controls.Add(this.parent_first_name);
                this.Controls.Add(this.parent_second_name);
                this.Controls.Add(this.parent_last_name);
                this.Controls.Add(this.parent_workplace);
                this.Controls.Add(this.parent_phone);
                //
                this.Controls.Add(this.parent_info_label);
                //
                //
                this.parent_first_name.Text = parent_info[0];
                this.parent_second_name.Text = parent_info[1];
                this.parent_last_name.Text = parent_info[2];
                //
                //
                string parent_workkplace_string = "";
                for (int i = 4; i < parent_info.Length-1; i++)
                {
                    parent_workkplace_string = parent_workkplace_string + parent_info[i] + " ";
                }
                parent_workkplace_string += parent_info[parent_info.Length - 1];
                this.parent_workplace.Text = parent_workkplace_string;
                //
                //
                this.parent_phone.Text = parent_info[3];

            }
            //
            //
            this.ex_amount = new System.Windows.Forms.TextBox();
            this.age = new System.Windows.Forms.TextBox();
            this.spec = new System.Windows.Forms.TextBox();
            this.start_date = new System.Windows.Forms.TextBox();
            //
            this.ex_amount_label = new System.Windows.Forms.Label();
            this.age_label = new System.Windows.Forms.Label();
            this.spec_label = new System.Windows.Forms.Label();
            this.start_date_label = new System.Windows.Forms.Label();
            // 
            // age
            // 
            height += 50;
            this.age_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.age_label.ForeColor = Color.AntiqueWhite;
            this.age_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
            this.age_label.Name = "age";
            this.age_label.Text = "Возраст";
            //
            this.age.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.age.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.age.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(240, 30);
            this.age.TabIndex = 1;
            this.age.ReadOnly = true;
            // 
            // specialization
            // 
            height += 50;
            this.spec_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spec_label.ForeColor = Color.AntiqueWhite;
            this.spec_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
            this.spec_label.Name = "specialization";
            this.spec_label.AutoSize = true;
            this.spec_label.Text = "Деятельность";
            //
            this.spec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spec.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spec.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.spec.Name = "specialization";
            this.spec.Size = new System.Drawing.Size(240, 30);
            this.spec.TabIndex = 1;
            this.spec.ReadOnly = true;
            // 
            // start_date
            // 
            height += 50;
            this.start_date_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_date_label.ForeColor = Color.AntiqueWhite;
            this.start_date_label.Location = new System.Drawing.Point(Size.Width - 1000, height-10);
            this.start_date_label.Name = "start_date";
            this.start_date_label.AutoSize = true;
            this.start_date_label.Text = "Дата \nрегистрации";
            //
            this.start_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.start_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_date.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(240, 30);
            this.start_date.TabIndex = 1;
            this.start_date.ReadOnly = true;
            // 
            // ex_amount
            // 
            height += 50;
            this.ex_amount_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ex_amount_label.ForeColor = Color.AntiqueWhite;
            this.ex_amount_label.Location = new System.Drawing.Point(Size.Width - 1000, height-10);
            this.ex_amount_label.Name = "ex_amount";
            this.ex_amount_label.AutoSize = true;
            this.ex_amount_label.Text = "Занятий \nпроплачено";
            //
            this.ex_amount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ex_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ex_amount.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.ex_amount.Name = "ex_amount";
            this.ex_amount.Size = new System.Drawing.Size(240, 30);
            this.ex_amount.TabIndex = 0;
            this.ex_amount.ReadOnly = true;
            //
            //
            this.Controls.Add(this.ex_amount);
            this.Controls.Add(this.age);
            this.Controls.Add(this.spec);
            this.Controls.Add(this.start_date);
            this.Controls.Add(this.ex_amount_label);
            this.Controls.Add(this.age_label);
            this.Controls.Add(this.spec_label);
            this.Controls.Add(this.start_date_label);
            //
            //
            this.ex_amount.Text = dt.Rows[0].Field<int>("exercise_amount").ToString();
            this.age.Text = dt.Rows[0].Field<int>("age").ToString();
            this.spec.Text = dt.Rows[0].Field<string>("spec");
            this.start_date.Text = dt.Rows[0].Field<DateTime>("start_date").ToString("yyyy-MM-dd");
        }

        private void FillForStudentChanges()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Controls.Clear();
            this.Controls.Add(exit_button);
            GetStudentInfo();
            //
            //data_layout
            //
            this.id = new System.Windows.Forms.TextBox();
            this.first_name = new System.Windows.Forms.TextBox();
            this.second_name = new System.Windows.Forms.TextBox();
            this.last_name = new System.Windows.Forms.TextBox();
            this.phone = new System.Windows.Forms.MaskedTextBox();
            //
            this.id_label = new System.Windows.Forms.Label();
            this.first_name_label = new System.Windows.Forms.Label();
            this.second_name_label = new System.Windows.Forms.Label();
            this.last_name_label = new System.Windows.Forms.Label();
            this.phone_label = new System.Windows.Forms.Label();
            int height = 60;
            // 
            // id
            // 
            this.id_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.id_label.ForeColor = Color.AntiqueWhite;
            this.id_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
            this.id_label.Name = "id";
            this.id_label.Text = "id";
            //
            this.id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.id.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(240, 30);
            this.id.TabIndex = 0;
            this.id.ReadOnly = true;
            // 
            // last_name
            // 
            height += 50;
            this.last_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.last_name_label.ForeColor = Color.AntiqueWhite;
            this.last_name_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
            this.last_name_label.Name = "last_name";
            this.last_name_label.Text = "Фамилия";
            //
            this.last_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.last_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.last_name.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.last_name.Name = "FIO";
            this.last_name.Size = new System.Drawing.Size(240, 30);
            this.last_name.TabIndex = 1;
            this.last_name.ReadOnly = true;
            // 
            // first_name
            // 
            height += 50;
            this.first_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.first_name_label.ForeColor = Color.AntiqueWhite;
            this.first_name_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
            this.first_name_label.Name = "first_name";
            this.first_name_label.Text = "Имя";
            //
            this.first_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.first_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.first_name.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.first_name.Name = "FIO";
            this.first_name.Size = new System.Drawing.Size(240, 30);
            this.first_name.TabIndex = 1;
            this.first_name.ReadOnly = true;
            // 
            // second_name
            // 
            height += 50;
            this.second_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.second_name_label.ForeColor = Color.AntiqueWhite;
            this.second_name_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
            this.second_name_label.Name = "second_name";
            this.second_name_label.Text = "Отчество ";
            //
            this.second_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.second_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.second_name.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.second_name.Name = "FIO";
            this.second_name.Size = new System.Drawing.Size(240, 30);
            this.second_name.TabIndex = 1;
            this.second_name.ReadOnly = true;
            // 
            // phone
            // 
            height += 50;
            this.phone_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phone_label.ForeColor = Color.AntiqueWhite;
            this.phone_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
            this.phone_label.Name = "id";
            this.phone_label.Text = "Телефон";
            //
            this.phone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phone.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(240, 30);
            this.phone.TabIndex = 2;
            this.phone.ReadOnly = true;
            this.phone.Mask = "+7(000)000-00-00";
            //
            //
            this.Controls.Add(this.id);
            this.Controls.Add(this.first_name);
            this.Controls.Add(this.second_name);
            this.Controls.Add(this.last_name);
            this.Controls.Add(this.phone);
            //
            this.Controls.Add(this.id_label);
            this.Controls.Add(this.first_name_label);
            this.Controls.Add(this.second_name_label);
            this.Controls.Add(this.last_name_label);
            this.Controls.Add(this.phone_label);
            //
            //
            string[] fio_string = dt.Rows[0].Field<string>("FIO").Split(' ');
            //
            //
            this.id.Text = dt.Rows[0].Field<int>("id").ToString();
            this.first_name.Text = fio_string[1];
            this.second_name.Text = fio_string[2];
            this.last_name.Text = fio_string[0];
            //
            //
            if (dt.Rows[0].Field<string>("phone") == null)
            {
                this.phone.Text = "Отсутствует";
            }
            else { this.phone.Text = dt.Rows[0].Field<string>("phone"); }
            //
            //
            if (dt.Rows[0].Field<string>("parent_info") != null)
            {
                this.parent_first_name = new System.Windows.Forms.TextBox();
                this.parent_second_name = new System.Windows.Forms.TextBox();
                this.parent_last_name = new System.Windows.Forms.TextBox();
                this.parent_workplace = new System.Windows.Forms.TextBox();
                this.parent_phone = new System.Windows.Forms.MaskedTextBox();
                //
                this.parent_info_label = new System.Windows.Forms.Label();
                //
                string[] parent_info = dt.Rows[0].Field<string>("parent_info").Split(' ');
                // 
                // parent_first_name
                // 
                this.parent_first_name = new System.Windows.Forms.TextBox();
                height += 50;
                this.parent_info_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.parent_info_label.ForeColor = Color.AntiqueWhite;
                this.parent_info_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
                this.parent_info_label.AutoSize = true;
                this.parent_info_label.Name = "parent_info";
                this.parent_info_label.Text = "ФИО родителя\nместо работы\nтелефон";
                //
                this.parent_first_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.parent_first_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.parent_first_name.Location = new System.Drawing.Point(Size.Width - 850, height);
                this.parent_first_name.Name = "parent_FIO";
                this.parent_first_name.Size = new System.Drawing.Size(240, 30);
                this.parent_first_name.TabIndex = 1;
                this.parent_first_name.ReadOnly = true;
                // 
                // parent_second_name
                // 
                height += 50;
                this.parent_second_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.parent_second_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.parent_second_name.Location = new System.Drawing.Point(Size.Width - 850, height);
                this.parent_second_name.Name = "parent_FIO";
                this.parent_second_name.Size = new System.Drawing.Size(240, 30);
                this.parent_second_name.TabIndex = 1;
                this.parent_second_name.ReadOnly = true;
                // 
                // parent_last_name
                // 
                height += 50;
                this.parent_last_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.parent_last_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.parent_last_name.Location = new System.Drawing.Point(Size.Width - 850, height);
                this.parent_last_name.Name = "parent_FIO";
                this.parent_last_name.Size = new System.Drawing.Size(240, 30);
                this.parent_last_name.TabIndex = 1;
                this.parent_last_name.ReadOnly = true;
                // 
                // parent_workplace
                // 
                height += 50;
                this.parent_workplace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.parent_workplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.parent_workplace.Location = new System.Drawing.Point(Size.Width - 850, height);
                this.parent_workplace.Name = "parent_workplace";
                this.parent_workplace.Size = new System.Drawing.Size(240, 30);
                this.parent_workplace.TabIndex = 1;
                this.parent_workplace.ReadOnly = true;
                // 
                // parent_phone
                // 
                height += 50;
                this.parent_phone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.parent_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.parent_phone.Location = new System.Drawing.Point(Size.Width - 850, height);
                this.parent_phone.Name = "parent_phone";
                this.parent_phone.Size = new System.Drawing.Size(240, 30);
                this.parent_phone.TabIndex = 2;
                this.parent_phone.ReadOnly = true;
                this.parent_phone.Mask = "+7(000)000-00-00";
                //
                //
                this.Controls.Add(this.parent_first_name);
                this.Controls.Add(this.parent_second_name);
                this.Controls.Add(this.parent_last_name);
                this.Controls.Add(this.parent_workplace);
                this.Controls.Add(this.parent_phone);
                //
                this.Controls.Add(this.parent_info_label);
                //
                //
                this.parent_first_name.Text = parent_info[0];
                this.parent_second_name.Text = parent_info[1];
                this.parent_last_name.Text = parent_info[2];
                //
                //
                string parent_workkplace_string = "";
                for (int i = 4; i < parent_info.Length - 1; i++)
                {
                    parent_workkplace_string = parent_workkplace_string + parent_info[i] + " ";
                }
                parent_workkplace_string += parent_info[parent_info.Length - 1];
                this.parent_workplace.Text = parent_workkplace_string;
                //
                //
                this.parent_phone.Text = parent_info[3];

            }
            //
            //
            this.ex_amount = new System.Windows.Forms.TextBox();
            this.age = new System.Windows.Forms.TextBox();
            this.spec = new System.Windows.Forms.TextBox();
            this.start_date = new System.Windows.Forms.TextBox();
            //
            this.ex_amount_label = new System.Windows.Forms.Label();
            this.age_label = new System.Windows.Forms.Label();
            this.spec_label = new System.Windows.Forms.Label();
            this.start_date_label = new System.Windows.Forms.Label();
            // 
            // age
            // 
            height += 50;
            this.age_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.age_label.ForeColor = Color.AntiqueWhite;
            this.age_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
            this.age_label.Name = "age";
            this.age_label.Text = "Возраст";
            //
            this.age.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.age.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.age.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(240, 30);
            this.age.TabIndex = 1;
            this.age.ReadOnly = true;
            // 
            // specialization
            // 
            height += 50;
            this.spec_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spec_label.ForeColor = Color.AntiqueWhite;
            this.spec_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
            this.spec_label.Name = "specialization";
            this.spec_label.AutoSize = true;
            this.spec_label.Text = "Деятельность";
            //
            this.spec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spec.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spec.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.spec.Name = "specialization";
            this.spec.Size = new System.Drawing.Size(240, 30);
            this.spec.TabIndex = 1;
            this.spec.ReadOnly = true;
            // 
            // start_date
            // 
            height += 50;
            this.start_date_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_date_label.ForeColor = Color.AntiqueWhite;
            this.start_date_label.Location = new System.Drawing.Point(Size.Width - 1000, height - 10);
            this.start_date_label.Name = "start_date";
            this.start_date_label.AutoSize = true;
            this.start_date_label.Text = "Дата \nрегистрации";
            //
            this.start_date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.start_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_date.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(240, 30);
            this.start_date.TabIndex = 1;
            this.start_date.ReadOnly = true;
            // 
            // ex_amount
            // 
            height += 50;
            this.ex_amount_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ex_amount_label.ForeColor = Color.AntiqueWhite;
            this.ex_amount_label.Location = new System.Drawing.Point(Size.Width - 1000, height - 10);
            this.ex_amount_label.Name = "ex_amount";
            this.ex_amount_label.AutoSize = true;
            this.ex_amount_label.Text = "Занятий \nпроплачено";
            //
            this.ex_amount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ex_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ex_amount.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.ex_amount.Name = "ex_amount";
            this.ex_amount.Size = new System.Drawing.Size(240, 30);
            this.ex_amount.TabIndex = 0;
            this.ex_amount.ReadOnly = true;
            //
            //
            this.Controls.Add(this.ex_amount);
            this.Controls.Add(this.age);
            this.Controls.Add(this.spec);
            this.Controls.Add(this.start_date);
            this.Controls.Add(this.ex_amount_label);
            this.Controls.Add(this.age_label);
            this.Controls.Add(this.spec_label);
            this.Controls.Add(this.start_date_label);
            //
            //
            this.ex_amount.Text = dt.Rows[0].Field<int>("exercise_amount").ToString();
            this.age.Text = dt.Rows[0].Field<int>("age").ToString();
            this.spec.Text = dt.Rows[0].Field<string>("spec");
            this.start_date.Text = dt.Rows[0].Field<DateTime>("start_date").ToString("yyyy-MM-dd");
            //
            //
            //change_data_layout ctrl m ctrl h ctrl u
            //
            //
            this.apply_changes = new System.Windows.Forms.Button();
            this.apply_changes.Location = new System.Drawing.Point(Size.Width - 130, 180);
            this.apply_changes.Name = "exit_button";
            this.apply_changes.Size = new System.Drawing.Size(100, 60);
            this.apply_changes.TabIndex = 0;
            this.apply_changes.Text = "Подтвердить \nизменения";
            this.apply_changes.UseVisualStyleBackColor = true;
            this.apply_changes.Click += new System.EventHandler(this.apply_student_changes_Button_Click);


            this.Controls.Add(this.apply_changes);
            this.id_ch = new System.Windows.Forms.TextBox();
            this.first_name_ch = new System.Windows.Forms.TextBox();
            this.second_name_ch = new System.Windows.Forms.TextBox();
            this.last_name_ch = new System.Windows.Forms.TextBox();
            this.phone_ch = new System.Windows.Forms.MaskedTextBox();
            this.allow_parent = new System.Windows.Forms.CheckBox();
            //
            this.id_label_ch = new System.Windows.Forms.Label();
            this.first_name_label_ch = new System.Windows.Forms.Label();
            this.second_name_label_ch = new System.Windows.Forms.Label();
            this.last_name_label_ch = new System.Windows.Forms.Label();
            this.phone_label_ch = new System.Windows.Forms.Label();
            height = 60;
            // 
            // last_name
            // 
            height += 50;
            this.last_name_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.last_name_label_ch.ForeColor = Color.AntiqueWhite;
            this.last_name_label_ch.Location = new System.Drawing.Point(Size.Width - 560, height);
            this.last_name_label_ch.Name = "last_name";
            this.last_name_label_ch.Text = "Фамилия";
            //
            this.last_name_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.last_name_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.last_name_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.last_name_ch.Name = "FIO";
            this.last_name_ch.Size = new System.Drawing.Size(240, 30);
            this.last_name_ch.TabIndex = 1;
            this.last_name_ch.ReadOnly = false;
            // 
            // first_name
            // 
            height += 50;
            this.first_name_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.first_name_label_ch.ForeColor = Color.AntiqueWhite;
            this.first_name_label_ch.Location = new System.Drawing.Point(Size.Width - 560, height);
            this.first_name_label_ch.Name = "first_name";
            this.first_name_label_ch.Text = "Имя";
            //
            this.first_name_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.first_name_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.first_name_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.first_name_ch.Name = "FIO";
            this.first_name_ch.Size = new System.Drawing.Size(240, 30);
            this.first_name_ch.TabIndex = 1;
            this.first_name_ch.ReadOnly = false;
            // 
            // second_name
            // 
            height += 50;
            this.second_name_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.second_name_label_ch.ForeColor = Color.AntiqueWhite;
            this.second_name_label_ch.Location = new System.Drawing.Point(Size.Width - 560, height);
            this.second_name_label_ch.Name = "second_name";
            this.second_name_label_ch.Text = "Отчество ";
            //
            this.second_name_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.second_name_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.second_name_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.second_name_ch.Name = "FIO";
            this.second_name_ch.Size = new System.Drawing.Size(240, 30);
            this.second_name_ch.TabIndex = 1;
            this.second_name_ch.ReadOnly = false;
            // 
            // phone
            // 
            height += 50;
            this.phone_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phone_label_ch.ForeColor = Color.AntiqueWhite;
            this.phone_label_ch.Location = new System.Drawing.Point(Size.Width - 560, height);
            this.phone_label_ch.Name = "id";
            this.phone_label_ch.Text = "Телефон";
            //
            this.phone_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.phone_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phone_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.phone_ch.Name = "phone";
            this.phone_ch.Size = new System.Drawing.Size(240, 30);
            this.phone_ch.TabIndex = 2;
            this.phone_ch.ReadOnly = false;
            this.phone_ch.Mask = "+7(000)000-00-00";
            //
            //
            this.Controls.Add(this.first_name_ch);
            this.Controls.Add(this.second_name_ch);
            this.Controls.Add(this.last_name_ch);
            this.Controls.Add(this.phone_ch);
            //
            this.Controls.Add(this.id_label_ch);
            this.Controls.Add(this.first_name_label_ch);
            this.Controls.Add(this.second_name_label_ch);
            this.Controls.Add(this.last_name_label_ch);
            this.Controls.Add(this.phone_label_ch);
            //
            //
            this.first_name_ch.Text = "Иван";
            this.second_name_ch.Text = "Иванович";
            this.last_name_ch.Text = "Иванов";
            this.phone_ch.Text = "9999999999";
            //
            //

            this.parent_first_name_ch = new System.Windows.Forms.TextBox();
            this.parent_second_name_ch = new System.Windows.Forms.TextBox();
            this.parent_last_name_ch = new System.Windows.Forms.TextBox();
            this.parent_workplace_ch = new System.Windows.Forms.TextBox();
            this.parent_phone_ch = new System.Windows.Forms.MaskedTextBox();
            //
            this.parent_info_label_ch = new System.Windows.Forms.Label();
            // 
            // parent_last_name
            // 
            height += 50;
            this.parent_last_name_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parent_last_name_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parent_last_name_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.parent_last_name_ch.Name = "parent_FIO";
            this.parent_last_name_ch.Size = new System.Drawing.Size(240, 30);
            this.parent_last_name_ch.TabIndex = 1;
            this.parent_last_name_ch.ReadOnly = false;
            //
            this.parent_info_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parent_info_label_ch.ForeColor = Color.AntiqueWhite;
            this.parent_info_label_ch.Location = new System.Drawing.Point(Size.Width - 560, height);
            this.parent_info_label_ch.AutoSize = true;
            this.parent_info_label_ch.Name = "parent_info";
            this.parent_info_label_ch.Text = "ФИО родителя\n\n\n\n\n\nместо работы\n\nтелефон +7";
            this.parent_info_label_ch.Visible= false;
            // 
            // parent_first_name
            // 
            this.parent_first_name_ch = new System.Windows.Forms.TextBox();
            height += 50;

            this.parent_first_name_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parent_first_name_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parent_first_name_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.parent_first_name_ch.Name = "parent_FIO";
            this.parent_first_name_ch.Size = new System.Drawing.Size(240, 30);
            this.parent_first_name_ch.TabIndex = 1;
            this.parent_first_name_ch.ReadOnly = true;
            // 
            // parent_second_name
            // 
            height += 50;
            this.parent_second_name_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parent_second_name_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parent_second_name_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.parent_second_name_ch.Name = "parent_FIO";
            this.parent_second_name_ch.Size = new System.Drawing.Size(240, 30);
            this.parent_second_name_ch.TabIndex = 1;
            this.parent_second_name_ch.ReadOnly = true;
            //
            //Cheker
            //
            this.allow_parent.Location = new System.Drawing.Point(Size.Width - 130, 110);
            this.allow_parent.AutoSize = true;
            this.allow_parent.ForeColor = Color.AntiqueWhite;
            this.allow_parent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.allow_parent.Text = "Данные о \nродителе";
            this.allow_parent.Checked = false;
            this.allow_parent.CheckedChanged += new System.EventHandler(this.allow_parent_checked_Changed);
            // 
            // parent_workplace
            // 
            height += 50;
            this.parent_workplace_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parent_workplace_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parent_workplace_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.parent_workplace_ch.Name = "parent_workplace";
            this.parent_workplace_ch.Size = new System.Drawing.Size(240, 30);
            this.parent_workplace_ch.TabIndex = 1;
            this.parent_workplace_ch.ReadOnly = true;
            // 
            // parent_phone
            // 
            height += 50;
            this.parent_phone_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parent_phone_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parent_phone_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.parent_phone_ch.Name = "parent_phone";
            this.parent_phone_ch.Size = new System.Drawing.Size(240, 30);
            this.parent_phone_ch.TabIndex = 2;
            this.parent_phone_ch.ReadOnly = true;
            this.parent_phone_ch.Mask = "+7(000)000-00-00";
            //
            //
            this.Controls.Add(this.parent_first_name_ch);
            this.Controls.Add(this.parent_second_name_ch);
            this.Controls.Add(this.parent_last_name_ch);
            this.Controls.Add(this.parent_workplace_ch);
            this.Controls.Add(this.parent_phone_ch);
            //
            this.Controls.Add(this.parent_info_label_ch);
            this.Controls.Add(this.allow_parent);
            //
            //
            this.parent_first_name_ch.BackColor = Color.Black;
            this.parent_second_name_ch.BackColor = Color.Black;
            this.parent_last_name_ch.BackColor = Color.Black;
            this.parent_workplace_ch.BackColor = Color.Black;
            this.parent_phone_ch.BackColor = Color.Black;
            //
            //
            this.ex_amount_ch = new System.Windows.Forms.TextBox();
            this.age_ch = new System.Windows.Forms.TextBox();
            this.spec_ch = new System.Windows.Forms.TextBox();

            //
            this.ex_amount_label_ch = new System.Windows.Forms.Label();
            this.age_label_ch = new System.Windows.Forms.Label();
            this.spec_label_ch = new System.Windows.Forms.Label();
            this.start_date_label_ch = new System.Windows.Forms.Label();
            // 
            // age
            // 
            height += 50;
            this.age_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.age_label_ch.ForeColor = Color.AntiqueWhite;
            this.age_label_ch.Location = new System.Drawing.Point(Size.Width - 560, height);
            this.age_label_ch.Name = "age";
            this.age_label_ch.Text = "Возраст";
            //
            this.age_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.age_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.age_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.age_ch.Name = "age";
            this.age_ch.Size = new System.Drawing.Size(240, 30);
            this.age_ch.TabIndex = 1;
            this.age_ch.ReadOnly = false;
            // 
            // specialization
            // 
            height += 50;
            this.spec_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spec_label_ch.ForeColor = Color.AntiqueWhite;
            this.spec_label_ch.Location = new System.Drawing.Point(Size.Width - 560, height);
            this.spec_label_ch.Name = "specialization";
            this.spec_label_ch.AutoSize = true;
            this.spec_label_ch.Text = "Деятельность";
            //
            this.spec_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spec_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spec_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.spec_ch.Name = "specialization";
            this.spec_ch.Size = new System.Drawing.Size(240, 30);
            this.spec_ch.TabIndex = 1;
            this.spec_ch.ReadOnly = false;

            height += 50;
            
            // 
            // ex_amount
            // 
            height += 50;
            this.ex_amount_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ex_amount_label_ch.ForeColor = Color.AntiqueWhite;
            this.ex_amount_label_ch.Location = new System.Drawing.Point(Size.Width - 560, height - 10);
            this.ex_amount_label_ch.Name = "ex_amount";
            this.ex_amount_label_ch.AutoSize = true;
            this.ex_amount_label_ch.Text = "Занятий \nпроплачено";
            //
            this.ex_amount_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ex_amount_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ex_amount_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.ex_amount_ch.Name = "ex_amount";
            this.ex_amount_ch.Size = new System.Drawing.Size(240, 30);
            this.ex_amount_ch.TabIndex = 0;
            this.ex_amount_ch.ReadOnly = false;
            //
            //
            this.Controls.Add(this.ex_amount_ch);
            this.Controls.Add(this.age_ch);
            this.Controls.Add(this.spec_ch);
            this.Controls.Add(this.start_date_ch);
            this.Controls.Add(this.ex_amount_label_ch);
            this.Controls.Add(this.age_label_ch);
            this.Controls.Add(this.spec_label_ch);
            this.Controls.Add(this.start_date_label_ch);
            //
            //
            this.ex_amount_ch.Text = "0";
            this.age_ch.Text = "99";
            this.spec_ch.Text = "Работает";
        }

        private void FillForAddStudent()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //
            //
            //change_data_layout ctrl m ctrl h ctrl u
            //
            //
            int height = 10;
            this.apply_changes = new System.Windows.Forms.Button();
            this.apply_changes.Location = new System.Drawing.Point(Size.Width - 130, 180);
            this.apply_changes.Name = "exit_button";
            this.apply_changes.Size = new System.Drawing.Size(100, 60);
            this.apply_changes.TabIndex = 0;
            this.apply_changes.Text = "Добавить \nстудента";
            this.apply_changes.UseVisualStyleBackColor = true;
            this.apply_changes.Click += new System.EventHandler(this.add_student_Button_Click);


            this.Controls.Add(this.apply_changes);
            this.first_name_ch = new System.Windows.Forms.TextBox();
            this.second_name_ch = new System.Windows.Forms.TextBox();
            this.last_name_ch = new System.Windows.Forms.TextBox();
            this.phone_ch = new System.Windows.Forms.MaskedTextBox();
            //
            this.id_label_ch = new System.Windows.Forms.Label();
            this.first_name_label_ch = new System.Windows.Forms.Label();
            this.second_name_label_ch = new System.Windows.Forms.Label();
            this.last_name_label_ch = new System.Windows.Forms.Label();
            this.phone_label_ch = new System.Windows.Forms.Label();
            height = 60;
            // 
            // last_name
            // 
            height += 50;
            this.last_name_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.last_name_label_ch.ForeColor = Color.AntiqueWhite;
            this.last_name_label_ch.Location = new System.Drawing.Point(Size.Width - 550, height);
            this.last_name_label_ch.Name = "last_name";
            this.last_name_label_ch.Text = "Фамилия";
            //
            this.last_name_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.last_name_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.last_name_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.last_name_ch.Name = "FIO";
            this.last_name_ch.Size = new System.Drawing.Size(240, 30);
            this.last_name_ch.TabIndex = 1;
            this.last_name_ch.ReadOnly = false;
            // 
            // first_name
            // 
            height += 50;
            this.first_name_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.first_name_label_ch.ForeColor = Color.AntiqueWhite;
            this.first_name_label_ch.Location = new System.Drawing.Point(Size.Width - 550, height);
            this.first_name_label_ch.Name = "first_name";
            this.first_name_label_ch.Text = "Имя";
            //
            this.first_name_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.first_name_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.first_name_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.first_name_ch.Name = "FIO";
            this.first_name_ch.Size = new System.Drawing.Size(240, 30);
            this.first_name_ch.TabIndex = 1;
            this.first_name_ch.ReadOnly = false;
            // 
            // second_name
            // 
            height += 50;
            this.second_name_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.second_name_label_ch.ForeColor = Color.AntiqueWhite;
            this.second_name_label_ch.Location = new System.Drawing.Point(Size.Width - 550, height);
            this.second_name_label_ch.Name = "second_name";
            this.second_name_label_ch.Text = "Отчество ";
            //
            this.second_name_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.second_name_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.second_name_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.second_name_ch.Name = "FIO";
            this.second_name_ch.Size = new System.Drawing.Size(240, 30);
            this.second_name_ch.TabIndex = 1;
            this.second_name_ch.ReadOnly = false;
            // 
            // phone
            // 
            height += 50;
            this.phone_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phone_label_ch.ForeColor = Color.AntiqueWhite;
            this.phone_label_ch.Location = new System.Drawing.Point(Size.Width - 550, height);
            this.phone_label_ch.Name = "id";
            this.phone_label_ch.Text = "Телефон";
            //
            this.phone_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.phone_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phone_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.phone_ch.Name = "phone";
            this.phone_ch.Size = new System.Drawing.Size(240, 30);
            this.phone_ch.TabIndex = 2;
            this.phone_ch.ReadOnly = false;
            this.phone_ch.Mask = "+7(000)000-00-00";
            //
            //
            this.Controls.Add(this.id_ch);
            this.Controls.Add(this.first_name_ch);
            this.Controls.Add(this.second_name_ch);
            this.Controls.Add(this.last_name_ch);
            this.Controls.Add(this.phone_ch);
            //
            this.Controls.Add(this.id_label_ch);
            this.Controls.Add(this.first_name_label_ch);
            this.Controls.Add(this.second_name_label_ch);
            this.Controls.Add(this.last_name_label_ch);
            this.Controls.Add(this.phone_label_ch);
            //
            //
            this.first_name_ch.Text = "Иван";
            this.second_name_ch.Text = "Иванович";
            this.last_name_ch.Text = "Иванов";
            this.phone_ch.Text = "9999999999";
            //
            //

            this.parent_first_name_ch = new System.Windows.Forms.TextBox();
            this.parent_second_name_ch = new System.Windows.Forms.TextBox();
            this.parent_last_name_ch = new System.Windows.Forms.TextBox();
            this.parent_workplace_ch = new System.Windows.Forms.TextBox();
            this.parent_phone_ch = new System.Windows.Forms.MaskedTextBox();
            this.allow_parent = new System.Windows.Forms.CheckBox();
            //
            this.parent_info_label_ch = new System.Windows.Forms.Label();
            // 
            // parent_last_name
            // 
            height += 50;
            this.parent_last_name_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parent_last_name_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parent_last_name_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.parent_last_name_ch.Name = "parent_FIO";
            this.parent_last_name_ch.Size = new System.Drawing.Size(240, 30);
            this.parent_last_name_ch.TabIndex = 1;
            this.parent_last_name_ch.ReadOnly = false;
            //
            // 
            this.parent_info_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parent_info_label_ch.ForeColor = Color.AntiqueWhite;
            this.parent_info_label_ch.Location = new System.Drawing.Point(Size.Width - 550, height);
            this.parent_info_label_ch.AutoSize = true;
            this.parent_info_label_ch.Name = "parent_info";
            this.parent_info_label_ch.Text = "ФИО родителя\n\n\n\n\n\nместо работы\n\nтелефон +7";
            this.parent_info_label_ch.Visible = false;
            // 
            // parent_first_name
            // 
            height += 50;
            this.parent_first_name_ch = new System.Windows.Forms.TextBox();
            this.parent_first_name_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parent_first_name_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parent_first_name_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.parent_first_name_ch.Name = "parent_FIO";
            this.parent_first_name_ch.Size = new System.Drawing.Size(240, 30);
            this.parent_first_name_ch.TabIndex = 1;
            this.parent_first_name_ch.ReadOnly = true;
            
            // 
            // parent_second_name
            // 
            height += 50;
            this.parent_second_name_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parent_second_name_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parent_second_name_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.parent_second_name_ch.Name = "parent_FIO";
            this.parent_second_name_ch.Size = new System.Drawing.Size(240, 30);
            this.parent_second_name_ch.TabIndex = 1;
            this.parent_second_name_ch.ReadOnly = true;
            //
            //checker
            //
            this.allow_parent.Location = new System.Drawing.Point(Size.Width - 130, 110);
            this.allow_parent.AutoSize = true;
            this.allow_parent.ForeColor = Color.AntiqueWhite;
            this.allow_parent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.allow_parent.Text = "Данные о \nродителе";
            this.allow_parent.Checked = false;
            this.allow_parent.CheckedChanged += new System.EventHandler(this.allow_parent_checked_Changed);
            // 
            // parent_workplace
            // 
            height += 50;
            this.parent_workplace_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parent_workplace_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parent_workplace_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.parent_workplace_ch.Name = "parent_workplace";
            this.parent_workplace_ch.Size = new System.Drawing.Size(240, 30);
            this.parent_workplace_ch.TabIndex = 1;
            this.parent_workplace_ch.ReadOnly = true;
            // 
            // parent_phone
            // 
            height += 50;
            this.parent_phone_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parent_phone_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parent_phone_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.parent_phone_ch.Name = "parent_phone";
            this.parent_phone_ch.Size = new System.Drawing.Size(240, 30);
            this.parent_phone_ch.TabIndex = 2;
            this.parent_phone_ch.ReadOnly = true;
            this.parent_phone_ch.Mask = "+7(000)000-00-00";
            //
            //
            this.Controls.Add(this.parent_first_name_ch);
            this.Controls.Add(this.parent_second_name_ch);
            this.Controls.Add(this.parent_last_name_ch);
            this.Controls.Add(this.parent_workplace_ch);
            this.Controls.Add(this.parent_phone_ch);
            //
            this.Controls.Add(this.parent_info_label_ch);
            this.Controls.Add(this.allow_parent);
            //
            //
            this.parent_first_name_ch.BackColor = Color.Black;
            this.parent_second_name_ch.BackColor = Color.Black;
            this.parent_last_name_ch.BackColor = Color.Black;
            this.parent_workplace_ch.BackColor = Color.Black;
            this.parent_phone_ch.BackColor = Color.Black;
            //
            //
            this.ex_amount_ch = new System.Windows.Forms.TextBox();
            this.age_ch = new System.Windows.Forms.TextBox();
            this.spec_ch = new System.Windows.Forms.TextBox();
            this.start_date_ch = new System.Windows.Forms.MaskedTextBox();
            //
            this.ex_amount_label_ch = new System.Windows.Forms.Label();
            this.age_label_ch = new System.Windows.Forms.Label();
            this.spec_label_ch = new System.Windows.Forms.Label();
            this.start_date_label_ch = new System.Windows.Forms.Label();
            // 
            // age
            // 
            height += 50;
            this.age_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.age_label_ch.ForeColor = Color.AntiqueWhite;
            this.age_label_ch.Location = new System.Drawing.Point(Size.Width - 550, height);
            this.age_label_ch.Name = "age";
            this.age_label_ch.Text = "Возраст";
            //
            this.age_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.age_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.age_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.age_ch.Name = "age";
            this.age_ch.Size = new System.Drawing.Size(240, 30);
            this.age_ch.TabIndex = 1;
            this.age_ch.ReadOnly = false;
            // 
            // specialization
            // 
            height += 50;
            this.spec_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spec_label_ch.ForeColor = Color.AntiqueWhite;
            this.spec_label_ch.Location = new System.Drawing.Point(Size.Width - 550, height);
            this.spec_label_ch.Name = "specialization";
            this.spec_label_ch.AutoSize = true;
            this.spec_label_ch.Text = "Деятельность";
            //
            this.spec_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spec_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spec_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.spec_ch.Name = "specialization";
            this.spec_ch.Size = new System.Drawing.Size(240, 30);
            this.spec_ch.TabIndex = 1;
            this.spec_ch.ReadOnly = false;
            // 
            // start_date
            // 
            height += 50;
            this.start_date_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_date_label_ch.ForeColor = Color.AntiqueWhite;
            this.start_date_label_ch.Location = new System.Drawing.Point(Size.Width - 550, height - 10);
            this.start_date_label_ch.Name = "start_date";
            this.start_date_label_ch.AutoSize = true;
            this.start_date_label_ch.Text = "Дата \nрегистрации";
            //
            this.start_date_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.start_date_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_date_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.start_date_ch.Name = "start_date";
            this.start_date_ch.Size = new System.Drawing.Size(240, 30);
            this.start_date_ch.TabIndex = 1;
            this.start_date_ch.ReadOnly = false;
            this.start_date_ch.Mask = "0000-00-00";
            // 
            // ex_amount
            // 
            height += 50;
            this.ex_amount_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ex_amount_label_ch.ForeColor = Color.AntiqueWhite;
            this.ex_amount_label_ch.Location = new System.Drawing.Point(Size.Width - 550, height - 10);
            this.ex_amount_label_ch.Name = "ex_amount";
            this.ex_amount_label_ch.AutoSize = true;
            this.ex_amount_label_ch.Text = "Занятий \nпроплачено";
            //
            this.ex_amount_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ex_amount_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ex_amount_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.ex_amount_ch.Name = "ex_amount";
            this.ex_amount_ch.Size = new System.Drawing.Size(240, 30);
            this.ex_amount_ch.TabIndex = 0;
            this.ex_amount_ch.ReadOnly = false;
            //
            //
            this.Controls.Add(this.ex_amount_ch);
            this.Controls.Add(this.age_ch);
            this.Controls.Add(this.spec_ch);
            this.Controls.Add(this.start_date_ch);
            this.Controls.Add(this.ex_amount_label_ch);
            this.Controls.Add(this.age_label_ch);
            this.Controls.Add(this.spec_label_ch);
            this.Controls.Add(this.start_date_label_ch);
            //
            //
            this.ex_amount_ch.Text = "0";
            this.age_ch.Text = "99";
            this.spec_ch.Text = "Работает";
            this.start_date_ch.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void apply_student_changes_Button_Click(object sender, EventArgs e)
        {
            
            cmd.CommandText = "SELECT change_date FROM students Where id = @id";
            cmd.Parameters.AddWithValue("@id", this.row_id);
            conn.Open();
            string change_date=cmd.ExecuteScalar().ToString();
            cmd.Parameters.Clear();
            conn.Close();
            if (dt.Rows[0]["change_date"].ToString() == change_date)
            {
                MessageBox.Show(change_date);
                cmd.CommandText = "UPDATE students SET FIO = @FIO, age = @age, spec = @spec, phone = @phone, " +
                    "parent_info = @parent_info, exercise_amount = @ex_amount WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", this.row_id);
                cmd.Parameters.AddWithValue("@FIO", (this.last_name_ch.Text.ToString() + " " + this.first_name_ch.Text.ToString() + " " + this.second_name_ch.Text.ToString()));
                cmd.Parameters.AddWithValue("@age", this.age_ch.Text.ToString());
                cmd.Parameters.AddWithValue("@spec", this.spec_ch.Text.ToString());
                cmd.Parameters.AddWithValue("@phone", this.phone_ch.Text.ToString());
                if (this.allow_parent.Checked == true)
                    cmd.Parameters.AddWithValue("@parent_info", (this.parent_last_name_ch.Text.ToString() + " " + this.parent_first_name_ch.Text.ToString() + " "
                    + this.parent_second_name_ch.Text.ToString() + " "
                    + this.parent_phone_ch.Text.ToString() + " " + this.parent_workplace_ch.Text.ToString()));
                
                else if (this.allow_parent.Checked == false)
                    cmd.Parameters.AddWithValue("@parent_info", null);

                cmd.Parameters.AddWithValue("@ex_amount", this.ex_amount_ch.Text.ToString());
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                cmd.Parameters.Clear();
                this.Close();
            }
            else 
            {
                MessageBox.Show("Данные устарели! Обновляем...");
                FillForStudentChanges();
                
            }
        }

        private void add_student_Button_Click(object sender, EventArgs e)
        {

            try { 
                cmd.CommandText = "INSERT students (FIO, age, spec, phone, " +
                    "parent_info, start_date, exercise_amount)" +
                    "Values (@FIO, @age, @spec, @phone, @parent_info, @start_date, @ex_amount)";
                cmd.Parameters.AddWithValue("@FIO", (this.last_name_ch.Text.ToString() + " " + this.first_name_ch.Text.ToString() + " " + this.second_name_ch.Text.ToString()));
                cmd.Parameters.AddWithValue("@age", this.age_ch.Text.ToString());
                cmd.Parameters.AddWithValue("@spec", this.spec_ch.Text.ToString());
                cmd.Parameters.AddWithValue("@phone", this.phone_ch.Text.ToString());
                if (this.allow_parent.Checked == true)
                    cmd.Parameters.AddWithValue("@parent_info", (this.parent_last_name_ch.Text.ToString() + " " + this.parent_first_name_ch.Text.ToString() + " "
                    + this.parent_second_name_ch.Text.ToString() + " "
                    + this.parent_phone_ch.Text.ToString() + " " + this.parent_workplace_ch.Text.ToString()));
                
                else if (this.allow_parent.Checked == false)
                    cmd.Parameters.AddWithValue("@parent_info", null);
                cmd.Parameters.AddWithValue("@start_date", this.start_date_ch.Text.ToString());
                cmd.Parameters.AddWithValue("@ex_amount", this.ex_amount_ch.Text.ToString());
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                cmd.Parameters.Clear();


                cmd.CommandText = "Select id from students ORDER BY id DESC LIMIT 1";
                conn.Open();
                string std_id = cmd.ExecuteScalar().ToString(); ;
                conn.Close();
                cmd.Parameters.Clear();

                cmd.CommandText = "INSERT student_division (student_id)" +
                    "Values (@std_id)";
                cmd.Parameters.AddWithValue("@std_id", std_id);
                
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                cmd.Parameters.Clear();

                MessageBox.Show("Succes");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Данные устарели! Обновляем...");
                FillForAddStudent();
            }
        }

        private void allow_parent_checked_Changed(object sender, EventArgs e)
        {
            if (this.allow_parent.Checked == true)
            {
                this.parent_first_name_ch.BackColor = Color.White;
                this.parent_second_name_ch.BackColor = Color.White;
                this.parent_last_name_ch.BackColor = Color.White;
                this.parent_workplace_ch.BackColor = Color.White;
                this.parent_phone_ch.BackColor = Color.White;

                this.parent_first_name_ch.ReadOnly = false;
                this.parent_second_name_ch.ReadOnly = false;
                this.parent_last_name_ch.ReadOnly = false;
                this.parent_workplace_ch.ReadOnly = false;
                this.parent_phone_ch.ReadOnly = false;

                this.parent_first_name_ch.Text = "Иван";
                this.parent_first_name_ch.Text = "Иван";
                this.parent_second_name_ch.Text = "Иванович";
                this.parent_last_name_ch.Text = "Иванов";
                this.parent_workplace_ch.Text = "ООО " + "Очумелые Ручки";
                this.parent_phone_ch.Text = "9999999999";
                this.parent_info_label_ch.Visible = true;

            }
            else {
                this.parent_first_name_ch.BackColor = Color.Black;
                this.parent_second_name_ch.BackColor = Color.Black;
                this.parent_last_name_ch.BackColor = Color.Black;
                this.parent_workplace_ch.BackColor = Color.Black;
                this.parent_phone_ch.BackColor = Color.Black;

                this.parent_first_name_ch.ReadOnly = true;
                this.parent_second_name_ch.ReadOnly = true;
                this.parent_last_name_ch.ReadOnly = true;
                this.parent_workplace_ch.ReadOnly = true;
                this.parent_phone_ch.ReadOnly = true;

                this.parent_first_name_ch.Text = String.Empty;
                this.parent_first_name_ch.Text = String.Empty;
                this.parent_second_name_ch.Text = String.Empty;
                this.parent_last_name_ch.Text = String.Empty;
                this.parent_workplace_ch.Text = String.Empty;
                this.parent_phone_ch.Text = String.Empty;
                this.parent_info_label_ch.Visible = false;
            }
        }

        private void delete_student_Button_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "SELECT change_date FROM students Where id = @id";
            cmd.Parameters.AddWithValue("@id", this.row_id);
            conn.Open();
            string change_date = cmd.ExecuteScalar().ToString();
            cmd.Parameters.Clear();
            conn.Close();
            if (dt.Rows[0]["change_date"].ToString() == change_date)
            {
                MessageBox.Show(change_date);
                cmd.CommandText = "UPDATE students SET status = 0 WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", this.row_id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                cmd.Parameters.Clear();
                this.Close();
            }
            else
            {
                MessageBox.Show("Данные устарели! Обновляем...");
                FillForStudentDetails();

            }
        }

        private void add_ex_Button_Click(Object sender, EventArgs e)
        {
            cmd.CommandText = "SELECT change_date FROM students Where id = @id";
            cmd.Parameters.AddWithValue("@id", this.row_id);
            conn.Open();
            string change_date = cmd.ExecuteScalar().ToString();
            cmd.Parameters.Clear();
            conn.Close();
            if (dt.Rows[0]["change_date"].ToString() == change_date)
            {
                MessageBox.Show(change_date);
                cmd.CommandText = "UPDATE students SET exercise_amount = @ex_amount WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", this.row_id);
                cmd.Parameters.AddWithValue("@ex_amount", (Convert.ToInt32(this.ex_amount.Text.ToString())+Convert.ToInt32(this.ex_amount_ch.Text.ToString())).ToString());
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                cmd.Parameters.Clear();
                this.Close();
            }
            else
            {
                MessageBox.Show("Данные устарели! Обновляем...");
                FillForStudentChanges();

            }
        }
        //
        //Schedule
        //
        private void GetDailySchedule()
        {
            cmd.CommandText = "Select daily_schedule.id as id, week_days.DayOfWeek as день, daily_schedule.start_time as начало, daily_schedule.end_time as конец, daily_schedule.change_date from daily_schedule " +
                "JOIN week_days ON daily_schedule.day = week_days.id Where schedule_id = @id";
            cmd.Parameters.AddWithValue("@id", row_id);
            conn.Open();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                dt.Clear();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                }
            }
            conn.Close();
            cmd.Parameters.Clear();
        }

        private void FillForScheduleDetails()
        {
            this.ClientSize = new System.Drawing.Size(700, 200);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            exit_button_refresh();

            this.grid_view = new System.Windows.Forms.DataGridView();

            GetDailySchedule();

            this.grid_view.AllowUserToAddRows = false;
            this.grid_view.DataSource = dt;

            this.grid_view.Font = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.grid_view.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.grid_view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grid_view.Location = new System.Drawing.Point(this.Size.Width - 675, 10);
            this.grid_view.Size = new System.Drawing.Size(this.Size.Width - 300, this.Size.Height-150);
            //
            this.Controls.Add(grid_view);
            //
            //
            this.add_ex_amount = new System.Windows.Forms.Button();
            //
            this.add_ex_amount.Location = new System.Drawing.Point(Size.Width - 250, 10);
            this.add_ex_amount.Name = "change daily_schedule";
            this.add_ex_amount.Size = new System.Drawing.Size(150, 60);
            this.add_ex_amount.TabIndex = 0;
            this.add_ex_amount.Text = "изменить расписание";
            this.add_ex_amount.UseVisualStyleBackColor = true;
            this.add_ex_amount.Click += new System.EventHandler(this.change_schedule_Button_Click);
            //
            this.Controls.Add(this.add_ex_amount);
            //
            this.change_elemtens = new System.Windows.Forms.GroupBox();
            //
            this.change_elemtens.Location = new System.Drawing.Point(10, Size.Height);
            this.change_elemtens.Size = new System.Drawing.Size(Size.Width - 40, 250);
            this.Controls.Add(change_elemtens);
            //
            this.day_picker_1 = new System.Windows.Forms.ComboBox();
            this.day_picker_2 = new System.Windows.Forms.ComboBox();
            this.time_picker_11 = new System.Windows.Forms.DateTimePicker();
            this.time_picker_12 = new System.Windows.Forms.DateTimePicker();
            this.time_picker_21 = new System.Windows.Forms.DateTimePicker();
            this.time_picker_22 = new System.Windows.Forms.DateTimePicker();
            //
            this.day_picker_1.Items.Add("Понедельник");
            this.day_picker_1.Items.Add("Вторник");
            this.day_picker_1.Items.Add("Среда");
            this.day_picker_1.Items.Add("Четверг");
            this.day_picker_1.Items.Add("Пятница");
            this.day_picker_1.Items.Add("Суббота");
            this.day_picker_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.day_picker_1.Size = new System.Drawing.Size(150, 30);
            this.day_picker_1.Location = new System.Drawing.Point(10, 40);
            this.day_picker_1.DropDownStyle = ComboBoxStyle.DropDownList;
            //
            this.day_picker_2.Items.Add("Понедельник");
            this.day_picker_2.Items.Add("Вторник");
            this.day_picker_2.Items.Add("Среда");
            this.day_picker_2.Items.Add("Четверг");
            this.day_picker_2.Items.Add("Пятница");
            this.day_picker_2.Items.Add("Суббота");
            this.day_picker_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.day_picker_2.Size = new System.Drawing.Size(150, 40);
            this.day_picker_2.Location = new System.Drawing.Point(10, 150);
            this.day_picker_2.DropDownStyle = ComboBoxStyle.DropDownList;
            //
            this.time_picker_11 = new System.Windows.Forms.DateTimePicker();
            this.time_picker_12 = new System.Windows.Forms.DateTimePicker();
            this.time_picker_21 = new System.Windows.Forms.DateTimePicker();
            this.time_picker_22 = new System.Windows.Forms.DateTimePicker();
            //
            this.time_picker_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.time_picker_11.Size = new System.Drawing.Size(150, 30);
            this.time_picker_11.Location = new System.Drawing.Point(170, 40);
            this.time_picker_11.CustomFormat = "HH:mm:ss";
            this.time_picker_11.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.time_picker_11.ShowUpDown = true;
            //
            this.time_picker_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.time_picker_12.Size = new System.Drawing.Size(150, 30);
            this.time_picker_12.Location = new System.Drawing.Point(330, 40);
            this.time_picker_12.CustomFormat = "HH:mm:ss";
            this.time_picker_12.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.time_picker_12.ShowUpDown = true;
            //
            this.time_picker_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.time_picker_21.Size = new System.Drawing.Size(150, 30);
            this.time_picker_21.Location = new System.Drawing.Point(170, 150);
            this.time_picker_21.CustomFormat = "HH:mm:ss";
            this.time_picker_21.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.time_picker_21.ShowUpDown = true;
            //
            this.time_picker_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.time_picker_22.Size = new System.Drawing.Size(150, 30);
            this.time_picker_22.Location = new System.Drawing.Point(330, 150);
            this.time_picker_22.CustomFormat = "HH:mm:ss";
            this.time_picker_22.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.time_picker_22.ShowUpDown = true;
            //
            this.apply_changes = new System.Windows.Forms.Button();
            this.cansel_button= new System.Windows.Forms.Button();
            //
            this.apply_changes.Location = new System.Drawing.Point(this.change_elemtens.Size.Width - 160, 40);
            this.apply_changes.Name = "change daily_schedule";
            this.apply_changes.Size = new System.Drawing.Size(150, 60);
            this.apply_changes.TabIndex = 0;
            this.apply_changes.Text = "изменить расписание";
            this.apply_changes.UseVisualStyleBackColor = true;
            this.apply_changes.Click += new System.EventHandler(this.change_daily_shedule_apply_Button_Click);
            //
            this.cansel_button.Location = new System.Drawing.Point(this.change_elemtens.Size.Width - 160, 150);
            this.cansel_button.Name = "change daily_schedule";
            this.cansel_button.Size = new System.Drawing.Size(150, 60);
            this.cansel_button.TabIndex = 0;
            this.cansel_button.Text = "Отменить изменения";
            this.cansel_button.UseVisualStyleBackColor = true;
            this.cansel_button.Click += new System.EventHandler(this.change_shedule_cansel_Button_Click);
            //
            this.change_elemtens.Controls.Add(apply_changes);
            this.change_elemtens.Controls.Add(cansel_button);
            this.change_elemtens.Controls.Add(day_picker_1);
            this.change_elemtens.Controls.Add(day_picker_2);
            this.change_elemtens.Controls.Add(time_picker_11);
            this.change_elemtens.Controls.Add(time_picker_12);
            this.change_elemtens.Controls.Add(time_picker_21);
            this.change_elemtens.Controls.Add(time_picker_22);
            this.change_elemtens.Hide();
        }

        private void FillForScheduleAdding()
        {
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            exit_button_refresh();

            this.change_elemtens = new System.Windows.Forms.GroupBox();
            //
            this.change_elemtens.Location = new System.Drawing.Point(10, 100);
            this.change_elemtens.Size = new System.Drawing.Size(Size.Width - 40, 400);
            this.Controls.Add(change_elemtens);
            //
            this.day_picker_1 = new System.Windows.Forms.ComboBox();
            this.day_picker_2 = new System.Windows.Forms.ComboBox();
            this.period_picker_11 = new System.Windows.Forms.DateTimePicker();
            this.period_picker_12 = new System.Windows.Forms.DateTimePicker();
            this.time_picker_11 = new System.Windows.Forms.DateTimePicker();
            this.time_picker_12 = new System.Windows.Forms.DateTimePicker();
            this.time_picker_21 = new System.Windows.Forms.DateTimePicker();
            this.time_picker_22 = new System.Windows.Forms.DateTimePicker();
            //
            this.day_picker_1.Items.Add("Понедельник");
            this.day_picker_1.Items.Add("Вторник");
            this.day_picker_1.Items.Add("Среда");
            this.day_picker_1.Items.Add("Четверг");
            this.day_picker_1.Items.Add("Пятница");
            this.day_picker_1.Items.Add("Суббота");
            this.day_picker_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.day_picker_1.Size = new System.Drawing.Size(150, 30);
            this.day_picker_1.Location = new System.Drawing.Point(10, 40);
            this.day_picker_1.DropDownStyle = ComboBoxStyle.DropDownList;
            //
            this.day_picker_2.Items.Add("Понедельник");
            this.day_picker_2.Items.Add("Вторник");
            this.day_picker_2.Items.Add("Среда");
            this.day_picker_2.Items.Add("Четверг");
            this.day_picker_2.Items.Add("Пятница");
            this.day_picker_2.Items.Add("Суббота");
            this.day_picker_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.day_picker_2.Size = new System.Drawing.Size(150, 40);
            this.day_picker_2.Location = new System.Drawing.Point(10, 150);
            this.day_picker_2.DropDownStyle = ComboBoxStyle.DropDownList;
            //
            this.time_picker_11 = new System.Windows.Forms.DateTimePicker();
            this.time_picker_12 = new System.Windows.Forms.DateTimePicker();
            this.time_picker_21 = new System.Windows.Forms.DateTimePicker();
            this.time_picker_22 = new System.Windows.Forms.DateTimePicker();
            //
            this.time_picker_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.time_picker_11.Size = new System.Drawing.Size(150, 30);
            this.time_picker_11.Location = new System.Drawing.Point(170, 40);
            this.time_picker_11.CustomFormat = "HH:mm:ss";
            this.time_picker_11.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.time_picker_11.ShowUpDown = true;
            //
            this.time_picker_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.time_picker_12.Size = new System.Drawing.Size(150, 30);
            this.time_picker_12.Location = new System.Drawing.Point(330, 40);
            this.time_picker_12.CustomFormat = "HH:mm:ss";
            this.time_picker_12.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.time_picker_12.ShowUpDown = true;
            //
            this.time_picker_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.time_picker_21.Size = new System.Drawing.Size(150, 30);
            this.time_picker_21.Location = new System.Drawing.Point(170, 150);
            this.time_picker_21.CustomFormat = "HH:mm:ss";
            this.time_picker_21.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.time_picker_21.ShowUpDown = true;
            //
            this.time_picker_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.time_picker_22.Size = new System.Drawing.Size(150, 30);
            this.time_picker_22.Location = new System.Drawing.Point(330, 150);
            this.time_picker_22.CustomFormat = "HH:mm:ss";
            this.time_picker_22.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.time_picker_22.ShowUpDown = true;
            //
            this.apply_changes = new System.Windows.Forms.Button();
            //
            this.apply_changes.Location = new System.Drawing.Point(this.change_elemtens.Size.Width - 160, 40);
            this.apply_changes.Name = "change daily_schedule";
            this.apply_changes.Size = new System.Drawing.Size(150, 60);
            this.apply_changes.TabIndex = 0;
            this.apply_changes.Text = "добавить расписание";
            this.apply_changes.UseVisualStyleBackColor = true;
            this.apply_changes.Click += new System.EventHandler(this.add_shedule_apply_Button_Click);
            //
            this.change_elemtens.Controls.Add(apply_changes);
            this.change_elemtens.Controls.Add(day_picker_1);
            this.change_elemtens.Controls.Add(day_picker_2);
            this.change_elemtens.Controls.Add(time_picker_11);
            this.change_elemtens.Controls.Add(time_picker_12);
            this.change_elemtens.Controls.Add(time_picker_21);
            this.change_elemtens.Controls.Add(time_picker_22);
            this.change_elemtens.Controls.Add(teacher_picker);
            this.change_elemtens.Controls.Add(group_picker);
            //
            this.teacher_picker = new System.Windows.Forms.ComboBox();
            this.group_picker = new System.Windows.Forms.ComboBox();
            //
            //
            cmd.CommandText = "Select id, FIO from user_data WHERE post = 'Преподаватель'";
            conn.Open();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                teachers.Clear();
                if (dr.HasRows)
                {
                    teachers.Load(dr);
                }
            }
            conn.Close();
            cmd.Parameters.Clear();
            //
            cmd.CommandText = "Select id, group_name from groups";
            conn.Open();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                groups.Clear();
                if (dr.HasRows)
                {
                    groups.Load(dr);
                }
            }
            conn.Close();
            cmd.Parameters.Clear();
            //
            //
            foreach (DataRow dr in teachers.Rows)
            {
                this.teacher_picker.Items.Add(dr[1].ToString());
            }
            this.teacher_picker.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.teacher_picker.Size = new System.Drawing.Size(300, 30);
            this.teacher_picker.Location = new System.Drawing.Point(10, 200);
            this.teacher_picker.DropDownStyle = ComboBoxStyle.DropDownList;
            //
            foreach (DataRow dr in groups.Rows)
            {
                this.group_picker.Items.Add(dr[1].ToString());
            }
            //
            this.group_picker.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.group_picker.Size = new System.Drawing.Size(300, 40);
            this.group_picker.Location = new System.Drawing.Point(320, 200);
            this.group_picker.DropDownStyle = ComboBoxStyle.DropDownList;
            //
            this.change_elemtens.Controls.Add(this.teacher_picker);
            this.change_elemtens.Controls.Add(this.group_picker);
            //
            this.day_picker_1.Text = "Понедельник";
            this.day_picker_2.Text = "Вторник";
            this.time_picker_11.Text = "10:10:00";
            this.time_picker_12.Text = "10:10:00";
            this.time_picker_21.Text = "10:10:00";
            this.time_picker_22.Text = "10:10:00";
            //
            this.period_picker_11 = new DateTimePicker();
            this.period_picker_12 = new DateTimePicker();
            //
            //
            this.period_picker_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.period_picker_11.Size = new System.Drawing.Size(300, 30);
            this.period_picker_11.Location = new System.Drawing.Point(10, 300);
            this.period_picker_11.CustomFormat = "yyyy:MM:dd";
            this.period_picker_11.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.period_picker_11.ShowUpDown = true;
            //
            this.period_picker_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.period_picker_12.Size = new System.Drawing.Size(300, 30);
            this.period_picker_12.Location = new System.Drawing.Point(320, 300);
            this.period_picker_12.CustomFormat = "yyyy:MM:dd";
            this.period_picker_12.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.period_picker_12.ShowUpDown = true;
            //
            this.change_elemtens.Controls.Add(period_picker_11);
            this.change_elemtens.Controls.Add(period_picker_12);
        }

        private void FillForSchedulePeriodChange()
        {
            this.ClientSize = new System.Drawing.Size(700, 200);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            exit_button_refresh();

            this.period_picker_11 = new System.Windows.Forms.DateTimePicker();
            this.period_picker_12 = new System.Windows.Forms.DateTimePicker();
            //
            //
            this.period_picker_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.period_picker_11.Size = new System.Drawing.Size(300, 30);
            this.period_picker_11.Location = new System.Drawing.Point(10, 50);
            this.period_picker_11.CustomFormat = "yyyy:MM:dd";
            this.period_picker_11.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.period_picker_11.ShowUpDown = true;
            //
            this.period_picker_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.period_picker_12.Size = new System.Drawing.Size(300, 30);
            this.period_picker_12.Location = new System.Drawing.Point(320, 50);
            this.period_picker_12.CustomFormat = "yyyy:MM:dd";
            this.period_picker_12.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.period_picker_12.ShowUpDown = true;
            //
            //
            cmd.CommandText = "SELECT id, start_date, " +
                "end_date, change_date FROM schedule " +
                "WHERE id = @id";
            conn.Open();
            cmd.Parameters.AddWithValue("@id", row_id);
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                dt.Clear();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                }
            }
            conn.Close();
            cmd.Parameters.Clear();
            //
            this.apply_changes = new System.Windows.Forms.Button();
            //
            this.apply_changes.Location = new System.Drawing.Point(this.Size.Width - 560, 120);
            this.apply_changes.Name = "change daily_schedule";
            this.apply_changes.Size = new System.Drawing.Size(150, 60);
            this.apply_changes.TabIndex = 0;
            this.apply_changes.Text = "изменить расписание";
            this.apply_changes.UseVisualStyleBackColor = true;
            this.apply_changes.Click += new System.EventHandler(this.change_shedule_apply_Button_Click);
            this.period_picker_11.Text= dt.Rows[0][1].ToString();
            this.period_picker_12.Text = dt.Rows[0][2].ToString();
            this.Controls.Add(period_picker_11);
            this.Controls.Add(period_picker_12);
            this.Controls.Add(apply_changes);

        }

        private void change_schedule_Button_Click(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.change_elemtens.Show();
            this.time_picker_11.Text = this.dt.Rows[0][2].ToString();
            this.time_picker_12.Text = this.dt.Rows[0][3].ToString();
            this.time_picker_21.Text = this.dt.Rows[1][2].ToString();
            this.time_picker_22.Text = this.dt.Rows[1][3].ToString();

            this.day_picker_1.Text = this.dt.Rows[0][1].ToString();
            this.day_picker_2.Text = this.dt.Rows[1][1].ToString();
        }

        private void change_daily_shedule_apply_Button_Click(Object sender, EventArgs e)
        {
            cmd.CommandText = "SELECT change_date FROM daily_schedule Where id = @id";
            cmd.Parameters.AddWithValue("@id", this.dt.Rows[0][0].ToString());
            conn.Open();
            string change_date_1 = cmd.ExecuteScalar().ToString();
            cmd.Parameters.Clear();
            conn.Close();
            cmd.CommandText = "SELECT change_date FROM daily_schedule Where id = @id";
            cmd.Parameters.AddWithValue("@id", this.dt.Rows[1][0].ToString());
            conn.Open();
            string change_date_2 = cmd.ExecuteScalar().ToString();
            cmd.Parameters.Clear();
            conn.Close();
            if (this.dt.Rows[0][4].ToString() == change_date_1 && this.dt.Rows[1][4].ToString() == change_date_2)
            {
                MessageBox.Show(change_date_1, change_date_2);
                cmd.CommandText = "UPDATE daily_schedule SET day = @day, start_time = @start_time, end_time = @end_time WHERE id = @id";

                cmd.Parameters.AddWithValue("@id", this.dt.Rows[0][0].ToString());
                cmd.Parameters.AddWithValue("@start_time", time_picker_11.Text.ToString());
                cmd.Parameters.AddWithValue("@end_time", time_picker_12.Text.ToString());
                switch (day_picker_1.Text.ToString())
                {
                    case "Понедельник":
                        cmd.Parameters.AddWithValue("@day", "1");
                        break;
                    case "Вторник":
                        cmd.Parameters.AddWithValue("@day", "2");
                        break;
                    case "Среда":
                        cmd.Parameters.AddWithValue("@day", "3");
                        break;
                    case "Четверг":
                        cmd.Parameters.AddWithValue("@day","4");
                        break;
                    case "Пятница":
                        cmd.Parameters.AddWithValue("@day", "5");
                        break;
                    case "Суббота":
                        cmd.Parameters.AddWithValue("@day", "6");
                        break;
                }

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@id", this.dt.Rows[1][0].ToString());
                cmd.Parameters.AddWithValue("@start_time", time_picker_21.Text.ToString());
                cmd.Parameters.AddWithValue("@end_time", time_picker_22.Text.ToString());
                switch (day_picker_2.Text.ToString())
                {
                    case "Понедельник":
                        cmd.Parameters.AddWithValue("@day", "1");
                        break;
                    case "Вторник":
                        cmd.Parameters.AddWithValue("@day", "2");
                        break;
                    case "Среда":
                        cmd.Parameters.AddWithValue("@day", "3");
                        break;
                    case "Четверг":
                        cmd.Parameters.AddWithValue("@day", "4");
                        break;
                    case "Пятница":
                        cmd.Parameters.AddWithValue("@day", "5");
                        break;
                    case "Суббота":
                        cmd.Parameters.AddWithValue("@day", "6");
                        break;
                }

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                cmd.Parameters.Clear();
                this.Close();
            }
            else
            {
                MessageBox.Show("Данные устарели! Обновляем...");
                FillForScheduleDetails();

            }
        }

        private void change_shedule_cansel_Button_Click(Object sender, EventArgs e) 
        {
            this.change_elemtens.Hide();
            this.ClientSize = new System.Drawing.Size(700, 200);
        }

        private void add_shedule_apply_Button_Click(object sender, EventArgs e) 
        {
            cmd.CommandText = "INSERT INTO schedule (group_id, teacher_id, start_date, end_date) VALUES (@group, @teacher, @start, @end)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@group", groups.Rows[GetRowIndex(groups,"group_name",group_picker.Text.ToString())][0]);
            cmd.Parameters.AddWithValue("@teacher", teachers.Rows[GetRowIndex(teachers, "FIO", teacher_picker.Text.ToString())][0]);
            cmd.Parameters.AddWithValue("@start", period_picker_11.Text.ToString());
            cmd.Parameters.AddWithValue("@end", period_picker_12.Text.ToString());
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Parameters.Clear();
            //
            cmd.CommandText = "Select id from schedule ORDER BY id DESC LIMIT 1";
            conn.Open();
            string schedule_id = cmd.ExecuteScalar().ToString(); ;
            conn.Close();
            cmd.Parameters.Clear();
            //
            cmd.CommandText = "INSERT INTO daily_schedule (schedule_id, day, start_time, end_time) VALUES (@schedule_id, @day, @start_time, @end_time),(@schedule_id, @day2, @start_time2, @end_time2)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@schedule_id", schedule_id);
            switch (day_picker_1.Text.ToString())
            {
                case "Понедельник":
                    cmd.Parameters.AddWithValue("@day", "1");
                    break;
                case "Вторник":
                    cmd.Parameters.AddWithValue("@day", "2");
                    break;
                case "Среда":
                    cmd.Parameters.AddWithValue("@day", "3");
                    break;
                case "Четверг":
                    cmd.Parameters.AddWithValue("@day", "4");
                    break;
                case "Пятница":
                    cmd.Parameters.AddWithValue("@day", "5");
                    break;
                case "Суббота":
                    cmd.Parameters.AddWithValue("@day", "6");
                    break;
            }
            switch (day_picker_2.Text.ToString())
            {
                case "Понедельник":
                    cmd.Parameters.AddWithValue("@day2", "1");
                    break;
                case "Вторник":
                    cmd.Parameters.AddWithValue("@day2", "2");
                    break;
                case "Среда":
                    cmd.Parameters.AddWithValue("@day2", "3");
                    break;
                case "Четверг":
                    cmd.Parameters.AddWithValue("@day2", "4");
                    break;
                case "Пятница":
                    cmd.Parameters.AddWithValue("@day2", "5");
                    break;
                case "Суббота":
                    cmd.Parameters.AddWithValue("@day2", "6");
                    break;
            }
            cmd.Parameters.AddWithValue("@start_time", time_picker_11.Text.ToString());
            cmd.Parameters.AddWithValue("@end_time", time_picker_12.Text.ToString());
            cmd.Parameters.AddWithValue("@start_time2", time_picker_21.Text.ToString());
            cmd.Parameters.AddWithValue("@end_time2", time_picker_22.Text.ToString());
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Parameters.Clear();
            this.Close();

        }

        private void change_shedule_apply_Button_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "SELECT change_date FROM schedule Where id = @id";
            cmd.Parameters.AddWithValue("@id", dt.Rows[0][0].ToString());
            conn.Open();
            string change_date_1 = cmd.ExecuteScalar().ToString();
            cmd.Parameters.Clear();
            conn.Close();
            if (this.dt.Rows[0][3].ToString() == change_date_1)
            {
                MessageBox.Show(change_date_1);
                cmd.CommandText = "UPDATE schedule SET start_date = @start_time, end_date = @end_time WHERE id = @id";

                cmd.Parameters.AddWithValue("@id", this.dt.Rows[0][0].ToString());
                cmd.Parameters.AddWithValue("@start_time", period_picker_11.Text.ToString());
                cmd.Parameters.AddWithValue("@end_time", period_picker_12.Text.ToString());
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                cmd.Parameters.Clear();
                this.Close();
            }
            else
            {
                MessageBox.Show("Данные устарели! Обновляем...");
                FillForSchedulePeriodChange();

            }

        }

        private int GetRowIndex(DataTable table, string columnName, object value)
        {
            // Формируем условие для поиска строки
            string filterExpression = columnName + " = '" + value.ToString() + "'";

            // Используем метод Select для получения массива строк, соответствующих условию
            DataRow[] foundRows = table.Select(filterExpression);

            // Проверяем, найдены ли строки
            if (foundRows.Length > 0)
            {
                // Используем метод Array.IndexOf для получения индекса первой найденной строки
                int rowIndex = Array.IndexOf(table.Rows.Cast<DataRow>().ToArray(), foundRows[0]);

                return rowIndex;
            }

            // Если строка не найдена, возвращаем -1
            return -1;
        }
        //
        //groups
        //
        private void FillForGroupDetails()
        {
            this.Size = new System.Drawing.Size(this.Size.Width+200, this.Size.Height );
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            exit_button_refresh();

            this.grid_view = new System.Windows.Forms.DataGridView();
            this.grid_view_2 = new System.Windows.Forms.DataGridView();
            //
            this.grid_view.DataSource = GetallStudentFromGroup();
            this.grid_view.DefaultCellStyle.Font = new Font("Arial", 12);
            this.grid_view.Width = 425;
            this.grid_view.Height = Size.Height - 50;
            this.grid_view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grid_view.ScrollBars = ScrollBars.Both;
            this.grid_view.AllowUserToAddRows = false;
            this.Controls.Add(this.grid_view);
            //
            this.grid_view_2.DataSource = GetallNonGroupStudents();
            this.grid_view_2.DefaultCellStyle.Font = new Font("Arial", 12);
            this.grid_view_2.Width = 425;
            this.grid_view_2.Height = Size.Height - 50;
            this.grid_view_2.Location = new Point(575, 0);
            this.grid_view_2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grid_view_2.ScrollBars = ScrollBars.Both;
            this.grid_view_2.AllowUserToAddRows = false;
            this.Controls.Add(this.grid_view_2);
            //
            this.apply_changes = new System.Windows.Forms.Button();
            this.delete_student = new System.Windows.Forms.Button();
            //
            this.apply_changes.Location = new System.Drawing.Point(450, 0);
            this.apply_changes.Font = new Font("Arial", 12);
            this.apply_changes.Width = 100;
            this.apply_changes.Height = Size.Height - 50;
            this.apply_changes.Text= "Удалить студента";
            this.apply_changes.UseVisualStyleBackColor = true;
            this.apply_changes.Click += new EventHandler(remove_from_group_Click);
            this.Controls.Add(this.apply_changes);
            //
            this.delete_student.Location = new System.Drawing.Point(1025, 0);
            this.delete_student.Font = new Font("Arial", 12);
            this.delete_student.Width = 100;
            this.delete_student.Height = Size.Height - 50;
            this.delete_student.Text = "Добавить студента";
            this.delete_student.UseVisualStyleBackColor = true;
            this.delete_student.Click += new EventHandler(add_to_group_Click);
            this.Controls.Add(this.delete_student);

        }

        private DataTable GetallStudentFromGroup()
        {
            //select * from student_division join students on student_division.student_id = students.id where student_division.group_id = 1
            //select student_division.group_id as 'jija',students.FIO as 'FIO' from student_division join students on student_division.student_id = students.id where student_division.group_id = 1

            cmd.Parameters.Clear();
            cmd.CommandText = "select students.id as 'student_id', student_division.group_id as 'группа',students.FIO as 'FIO', student_division.change_date, student_division.id from student_division " +
                "join students on student_division.student_id = students.id where student_division.group_id = @id";
            conn.Open();
            
            cmd.Parameters.AddWithValue("@id", row_id.ToString());
            dt.Clear();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                dt.Clear();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                }
            }
            conn.Close();
            cmd.Parameters.Clear();
            return dt;
        }

        private DataTable GetallNonGroupStudents()
        {
            //select * from student_division join students on student_division.student_id = students.id where student_division.group_id = 1
            //select student_division.group_id as 'jija',students.FIO as 'FIO' from student_division join students on student_division.student_id = students.id where student_division.group_id = 1

            cmd.Parameters.Clear();
            cmd.CommandText = "select students.id as 'id', student_division.group_id as 'группа',students.FIO as 'FIO', student_division.change_date, student_division.id from student_division " +
                "join students on student_division.student_id = students.id where student_division.group_id is NULL";
            conn.Open();

            dt_2.Clear();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                dt_2.Clear();
                if (dr.HasRows)
                {
                    dt_2.Load(dr);
                }
            }
            conn.Close();
            cmd.Parameters.Clear();
            return dt_2;
        }

        private void remove_from_group_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "SELECT change_date FROM student_division Where student_id = @id";
            MessageBox.Show(this.dt.Rows[grid_view.CurrentCell.RowIndex][0].ToString());
            cmd.Parameters.AddWithValue("@id", this.dt.Rows[grid_view.CurrentCell.RowIndex][0].ToString());
            conn.Open();
            string change_date_2 = cmd.ExecuteScalar().ToString();
            cmd.Parameters.Clear();
            conn.Close();
            if (this.dt.Rows[grid_view.CurrentRow.Index][3].ToString() == change_date_2)
            {
                MessageBox.Show(change_date_2);
                cmd.CommandText = "UPDATE student_division SET group_id = NULL WHERE student_id = @std_id";

                cmd.Parameters.AddWithValue("@std_id", this.dt.Rows[grid_view.CurrentRow.Index][0].ToString());


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                cmd.Parameters.Clear();
                this.grid_view.DataSource = GetallStudentFromGroup();
                this.grid_view_2.DataSource = GetallNonGroupStudents();
                this.grid_view.Refresh();
                this.grid_view_2.Refresh();
            }
        }

        private void add_to_group_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "SELECT change_date FROM student_division Where student_id = @id";
            MessageBox.Show(this.dt_2.Rows[grid_view_2.CurrentCell.RowIndex][0].ToString());
            cmd.Parameters.AddWithValue("@id", this.dt_2.Rows[grid_view_2.CurrentCell.RowIndex][0].ToString());
            conn.Open();
            string change_date_2 = cmd.ExecuteScalar().ToString();
            cmd.Parameters.Clear();
            conn.Close();
            if (this.dt_2.Rows[grid_view_2.CurrentRow.Index][3].ToString() == change_date_2)
            {
                MessageBox.Show(change_date_2);
                cmd.CommandText = "UPDATE student_division SET group_id = @group_id WHERE student_id = @std_id";

                cmd.Parameters.AddWithValue("@std_id", this.dt_2.Rows[grid_view_2.CurrentRow.Index][0].ToString());
                cmd.Parameters.AddWithValue("@group_id", row_id.ToString());
                

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                cmd.Parameters.Clear();
                this.grid_view.DataSource = GetallStudentFromGroup();
                this.grid_view_2.DataSource = GetallNonGroupStudents();
                this.grid_view.Refresh();
                this.grid_view_2.Refresh();
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.grid_view.Columns[3].Visible= false;
            this.grid_view_2.Columns[3].Visible = false;
            this.grid_view.Columns[4].Visible = false;
            this.grid_view_2.Columns[4].Visible = false;
        }
        //
        //users
        //
        private void GetUserInfo()
        {
            cmd.CommandText = "SELECT user_data.id, user_data.FIO, user_data.phone, user_data.post, LoginInfo.login, LoginInfo.password, " +
                "LoginInfo.role, user_data.change_date as date1, LoginInfo.change_date as date2 FROM user_data JOIN LoginInfo on LoginInfo.user_data_id = user_data.id Where user_data.id = @id";
            cmd.Parameters.AddWithValue("@id", this.row_id.ToString());
            conn.Open();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                dt.Clear();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                }
            }
            conn.Close();
            cmd.Parameters.Clear();
        }

        private void FillForUserDetails()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Width = this.Width / 2;
            GetUserInfo();
            exit_button_refresh();
            //
            //data_layout
            //
            this.id = new System.Windows.Forms.TextBox();
            this.first_name = new System.Windows.Forms.TextBox();
            this.second_name = new System.Windows.Forms.TextBox();
            this.last_name = new System.Windows.Forms.TextBox();
            this.phone = new System.Windows.Forms.MaskedTextBox();
            //
            this.id_label = new System.Windows.Forms.Label();
            this.first_name_label = new System.Windows.Forms.Label();
            this.second_name_label = new System.Windows.Forms.Label();
            this.last_name_label = new System.Windows.Forms.Label();
            this.phone_label = new System.Windows.Forms.Label();
            //
            //
            int height = 60;
            // 
            // id
            // 
            this.id_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.id_label.ForeColor = Color.AntiqueWhite;
            this.id_label.Location = new System.Drawing.Point(Size.Width - 500, height);
            this.id_label.Name = "id";
            this.id_label.Text = "id";
            //
            this.id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.id.Location = new System.Drawing.Point(Size.Width - 375, height);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(240, 30);
            this.id.TabIndex = 0;
            this.id.ReadOnly = true;
            // 
            // last_name
            // 
            height += 50;
            this.last_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.last_name_label.ForeColor = Color.AntiqueWhite;
            this.last_name_label.Location = new System.Drawing.Point(Size.Width - 500, height);
            this.last_name_label.Name = "last_name";
            this.last_name_label.Text = "Фамилия";
            //
            this.last_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.last_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.last_name.Location = new System.Drawing.Point(Size.Width - 375, height);
            this.last_name.Name = "FIO";
            this.last_name.Size = new System.Drawing.Size(240, 30);
            this.last_name.TabIndex = 1;
            this.last_name.ReadOnly = true;
            // 
            // first_name
            // 
            height += 50;
            this.first_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.first_name_label.ForeColor = Color.AntiqueWhite;
            this.first_name_label.Location = new System.Drawing.Point(Size.Width - 500, height);
            this.first_name_label.Name = "first_name";
            this.first_name_label.Text = "Имя";
            //
            this.first_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.first_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.first_name.Location = new System.Drawing.Point(Size.Width - 375, height);
            this.first_name.Name = "FIO";
            this.first_name.Size = new System.Drawing.Size(240, 30);
            this.first_name.TabIndex = 1;
            this.first_name.ReadOnly = true;
            // 
            // second_name
            // 
            height += 50;
            this.second_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.second_name_label.ForeColor = Color.AntiqueWhite;
            this.second_name_label.Location = new System.Drawing.Point(Size.Width - 500, height);
            this.second_name_label.Name = "second_name";
            this.second_name_label.Text = "Отчество ";
            //
            this.second_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.second_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.second_name.Location = new System.Drawing.Point(Size.Width - 375, height);
            this.second_name.Name = "FIO";
            this.second_name.Size = new System.Drawing.Size(240, 30);
            this.second_name.TabIndex = 1;
            this.second_name.ReadOnly = true;
            // 
            // phone
            // 
            height += 50;
            this.phone_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phone_label.ForeColor = Color.AntiqueWhite;
            this.phone_label.Location = new System.Drawing.Point(Size.Width - 500, height);
            this.phone_label.Name = "id";
            this.phone_label.Text = "Телефон";
            //
            this.phone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phone.Location = new System.Drawing.Point(Size.Width - 375, height);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(240, 30);
            this.phone.TabIndex = 2;
            this.phone.ReadOnly = true;
            this.phone.Mask = "+7(000)000-00-00";
            //
            //
            this.Controls.Add(this.id);
            this.Controls.Add(this.first_name);
            this.Controls.Add(this.second_name);
            this.Controls.Add(this.last_name);
            this.Controls.Add(this.phone);
            //
            this.Controls.Add(this.id_label);
            this.Controls.Add(this.first_name_label);
            this.Controls.Add(this.second_name_label);
            this.Controls.Add(this.last_name_label);
            this.Controls.Add(this.phone_label);
            //
            //
            string[] fio_string = dt.Rows[0].Field<string>("FIO").Split(' ');
            //
            //
            this.id.Text = dt.Rows[0].Field<int>("id").ToString();
            this.first_name.Text = fio_string[1];
            this.second_name.Text = fio_string[2];
            this.last_name.Text = fio_string[0];
            //
            //
            if (dt.Rows[0].Field<string>("phone") == null)
            {
                this.phone.Text = "Отсутствует";
            }
            else { this.phone.Text = dt.Rows[0].Field<string>("phone"); }
            //
            //

            this.parent_workplace = new System.Windows.Forms.TextBox();
            //
            this.parent_info_label = new System.Windows.Forms.Label();
            //
            height += 50;
            this.parent_info_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parent_info_label.ForeColor = Color.AntiqueWhite;
            this.parent_info_label.Location = new System.Drawing.Point(Size.Width - 500, height);
            this.parent_info_label.AutoSize = true;
            this.parent_info_label.Name = "Должность";
            this.parent_info_label.Text = "Должность";
            // 
            // parent_workplace
            // 
            this.parent_workplace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parent_workplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parent_workplace.Location = new System.Drawing.Point(Size.Width - 375, height);
            this.parent_workplace.Name = "post";
            this.parent_workplace.Size = new System.Drawing.Size(240, 30);
            this.parent_workplace.TabIndex = 1;
            this.parent_workplace.ReadOnly = true;
            //
            //
            this.Controls.Add(this.parent_workplace);
            //
            this.Controls.Add(this.parent_info_label);
            //
            //
            this.parent_workplace.Text = dt.Rows[0].Field<string>("post").ToString();
            //
            //
            this.ex_amount = new System.Windows.Forms.TextBox();
            this.age = new System.Windows.Forms.TextBox();
            this.spec = new System.Windows.Forms.TextBox();
            //
            this.ex_amount_label = new System.Windows.Forms.Label();
            this.age_label = new System.Windows.Forms.Label();
            this.spec_label = new System.Windows.Forms.Label();
            // 
            // age
            // 
            height += 50;
            this.age_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.age_label.ForeColor = Color.AntiqueWhite;
            this.age_label.Location = new System.Drawing.Point(Size.Width - 500, height);
            this.age_label.Name = "login";
            this.age_label.Text = "login";
            //
            this.age.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.age.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.age.Location = new System.Drawing.Point(Size.Width - 375, height);
            this.age.Name = "login";
            this.age.Size = new System.Drawing.Size(240, 30);
            this.age.TabIndex = 1;
            this.age.ReadOnly = true;
            // 
            // specialization
            // 
            height += 50;
            this.spec_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spec_label.ForeColor = Color.AntiqueWhite;
            this.spec_label.Location = new System.Drawing.Point(Size.Width - 500, height);
            this.spec_label.Name = "password";
            this.spec_label.AutoSize = true;
            this.spec_label.Text = "password";
            //
            this.spec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spec.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spec.Location = new System.Drawing.Point(Size.Width - 375, height);
            this.spec.Name = "password";
            this.spec.Size = new System.Drawing.Size(240, 30);
            this.spec.TabIndex = 1;
            this.spec.ReadOnly = true;
            // 
            // ex_amount
            // 
            height += 50;
            this.ex_amount_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ex_amount_label.ForeColor = Color.AntiqueWhite;
            this.ex_amount_label.Location = new System.Drawing.Point(Size.Width - 500, height - 10);
            this.ex_amount_label.Name = "role";
            this.ex_amount_label.AutoSize = true;
            this.ex_amount_label.Text = "role";
            //
            this.ex_amount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ex_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ex_amount.Location = new System.Drawing.Point(Size.Width - 375, height);
            this.ex_amount.Name = "role";
            this.ex_amount.Size = new System.Drawing.Size(240, 30);
            this.ex_amount.TabIndex = 0;
            this.ex_amount.ReadOnly = true;
            //
            //
            this.Controls.Add(this.ex_amount);
            this.Controls.Add(this.age);
            this.Controls.Add(this.spec);
            this.Controls.Add(this.ex_amount_label);
            this.Controls.Add(this.age_label);
            this.Controls.Add(this.spec_label);
            //
            //
            this.ex_amount.Text = dt.Rows[0].Field<int>("role").ToString();
            this.age.Text = dt.Rows[0].Field<string>("login").ToString();
            this.spec.Text = dt.Rows[0].Field<string>("password").ToString();
        }

        private void FillForUserChanges()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Controls.Clear();
            this.Controls.Add(exit_button);
            GetUserInfo();
            //
            //data_layout
            //
            this.id = new System.Windows.Forms.TextBox();
            this.first_name = new System.Windows.Forms.TextBox();
            this.second_name = new System.Windows.Forms.TextBox();
            this.last_name = new System.Windows.Forms.TextBox();
            this.phone = new System.Windows.Forms.MaskedTextBox();
            //
            this.id_label = new System.Windows.Forms.Label();
            this.first_name_label = new System.Windows.Forms.Label();
            this.second_name_label = new System.Windows.Forms.Label();
            this.last_name_label = new System.Windows.Forms.Label();
            this.phone_label = new System.Windows.Forms.Label();
            //
            //
            int height = 60;
            // 
            // id
            // 
            this.id_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.id_label.ForeColor = Color.AntiqueWhite;
            this.id_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
            this.id_label.Name = "id";
            this.id_label.Text = "id";
            //
            this.id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.id.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(240, 30);
            this.id.TabIndex = 0;
            this.id.ReadOnly = true;
            // 
            // last_name
            // 
            height += 50;
            this.last_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.last_name_label.ForeColor = Color.AntiqueWhite;
            this.last_name_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
            this.last_name_label.Name = "last_name";
            this.last_name_label.Text = "Фамилия";
            //
            this.last_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.last_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.last_name.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.last_name.Name = "FIO";
            this.last_name.Size = new System.Drawing.Size(240, 30);
            this.last_name.TabIndex = 1;
            this.last_name.ReadOnly = true;
            // 
            // first_name
            // 
            height += 50;
            this.first_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.first_name_label.ForeColor = Color.AntiqueWhite;
            this.first_name_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
            this.first_name_label.Name = "first_name";
            this.first_name_label.Text = "Имя";
            //
            this.first_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.first_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.first_name.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.first_name.Name = "FIO";
            this.first_name.Size = new System.Drawing.Size(240, 30);
            this.first_name.TabIndex = 1;
            this.first_name.ReadOnly = true;
            // 
            // second_name
            // 
            height += 50;
            this.second_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.second_name_label.ForeColor = Color.AntiqueWhite;
            this.second_name_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
            this.second_name_label.Name = "second_name";
            this.second_name_label.Text = "Отчество ";
            //
            this.second_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.second_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.second_name.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.second_name.Name = "FIO";
            this.second_name.Size = new System.Drawing.Size(240, 30);
            this.second_name.TabIndex = 1;
            this.second_name.ReadOnly = true;
            // 
            // phone
            // 
            height += 50;
            this.phone_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phone_label.ForeColor = Color.AntiqueWhite;
            this.phone_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
            this.phone_label.Name = "id";
            this.phone_label.Text = "Телефон";
            //
            this.phone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phone.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(240, 30);
            this.phone.TabIndex = 2;
            this.phone.ReadOnly = true;
            this.phone.Mask = "+7(000)000-00-00";
            //
            //
            this.Controls.Add(this.id);
            this.Controls.Add(this.first_name);
            this.Controls.Add(this.second_name);
            this.Controls.Add(this.last_name);
            this.Controls.Add(this.phone);
            //
            this.Controls.Add(this.id_label);
            this.Controls.Add(this.first_name_label);
            this.Controls.Add(this.second_name_label);
            this.Controls.Add(this.last_name_label);
            this.Controls.Add(this.phone_label);
            //
            //
            string[] fio_string = dt.Rows[0].Field<string>("FIO").Split(' ');
            //
            //
            this.id.Text = dt.Rows[0].Field<int>("id").ToString();
            this.first_name.Text = fio_string[1];
            this.second_name.Text = fio_string[2];
            this.last_name.Text = fio_string[0];
            //
            //
            if (dt.Rows[0].Field<string>("phone") == null)
            {
                this.phone.Text = "Отсутствует";
            }
            else { this.phone.Text = dt.Rows[0].Field<string>("phone"); }
            //
            //

            this.parent_workplace = new System.Windows.Forms.TextBox();
            //
            this.parent_info_label = new System.Windows.Forms.Label();
            //
            height += 50;
            this.parent_info_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parent_info_label.ForeColor = Color.AntiqueWhite;
            this.parent_info_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
            this.parent_info_label.AutoSize = true;
            this.parent_info_label.Name = "Должность";
            this.parent_info_label.Text = "Должность";
            // 
            // parent_workplace
            // 
            this.parent_workplace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parent_workplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parent_workplace.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.parent_workplace.Name = "post";
            this.parent_workplace.Size = new System.Drawing.Size(240, 30);
            this.parent_workplace.TabIndex = 1;
            this.parent_workplace.ReadOnly = true;
            //
            //
            this.Controls.Add(this.parent_workplace);
            //
            this.Controls.Add(this.parent_info_label);
            //
            //
            this.parent_workplace.Text = dt.Rows[0].Field<string>("post").ToString();
            //
            //
            this.ex_amount = new System.Windows.Forms.TextBox();
            this.age = new System.Windows.Forms.TextBox();
            this.spec = new System.Windows.Forms.TextBox();
            //
            this.ex_amount_label = new System.Windows.Forms.Label();
            this.age_label = new System.Windows.Forms.Label();
            this.spec_label = new System.Windows.Forms.Label();
            // 
            // age
            // 
            height += 50;
            this.age_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.age_label.ForeColor = Color.AntiqueWhite;
            this.age_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
            this.age_label.Name = "login";
            this.age_label.Text = "login";
            //
            this.age.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.age.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.age.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.age.Name = "login";
            this.age.Size = new System.Drawing.Size(240, 30);
            this.age.TabIndex = 1;
            this.age.ReadOnly = true;
            // 
            // specialization
            // 
            height += 50;
            this.spec_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spec_label.ForeColor = Color.AntiqueWhite;
            this.spec_label.Location = new System.Drawing.Point(Size.Width - 1000, height);
            this.spec_label.Name = "password";
            this.spec_label.AutoSize = true;
            this.spec_label.Text = "password";
            //
            this.spec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spec.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spec.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.spec.Name = "password";
            this.spec.Size = new System.Drawing.Size(240, 30);
            this.spec.TabIndex = 1;
            this.spec.ReadOnly = true;
            // 
            // ex_amount
            // 
            height += 50;
            this.ex_amount_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ex_amount_label.ForeColor = Color.AntiqueWhite;
            this.ex_amount_label.Location = new System.Drawing.Point(Size.Width - 1000, height - 10);
            this.ex_amount_label.Name = "role";
            this.ex_amount_label.AutoSize = true;
            this.ex_amount_label.Text = "role";
            //
            this.ex_amount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ex_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ex_amount.Location = new System.Drawing.Point(Size.Width - 850, height);
            this.ex_amount.Name = "role";
            this.ex_amount.Size = new System.Drawing.Size(240, 30);
            this.ex_amount.TabIndex = 0;
            this.ex_amount.ReadOnly = true;
            //
            //
            this.Controls.Add(this.ex_amount);
            this.Controls.Add(this.age);
            this.Controls.Add(this.spec);
            this.Controls.Add(this.ex_amount_label);
            this.Controls.Add(this.age_label);
            this.Controls.Add(this.spec_label);
            //
            //
            this.ex_amount.Text = dt.Rows[0].Field<int>("role").ToString();
            this.age.Text = dt.Rows[0].Field<string>("login").ToString();
            this.spec.Text = dt.Rows[0].Field<string>("password").ToString();
            //
            //
            //change_data_layout ctrl m ctrl h ctrl u 560 400
            //
            //
            this.apply_changes = new System.Windows.Forms.Button();
            this.apply_changes.Location = new System.Drawing.Point(Size.Width - 130, 180);
            this.apply_changes.Name = "exit_button";
            this.apply_changes.Size = new System.Drawing.Size(100, 60);
            this.apply_changes.TabIndex = 0;
            this.apply_changes.Text = "Подтвердить \nизменения";
            this.apply_changes.UseVisualStyleBackColor = true;
            this.apply_changes.Click += new System.EventHandler(this.apply_user_changes_Button_Click);
            this.Controls.Add(this.apply_changes);
            //
            //
            this.first_name_ch = new System.Windows.Forms.TextBox();
            this.second_name_ch = new System.Windows.Forms.TextBox();
            this.last_name_ch = new System.Windows.Forms.TextBox();
            this.phone_ch = new System.Windows.Forms.MaskedTextBox();
            //
            this.first_name_label_ch = new System.Windows.Forms.Label();
            this.second_name_label_ch = new System.Windows.Forms.Label();
            this.last_name_label_ch = new System.Windows.Forms.Label();
            this.phone_label_ch = new System.Windows.Forms.Label();
            //
            //
            height = 110;
            // 
            // last_name
            // 
            this.last_name_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.last_name_label_ch.ForeColor = Color.AntiqueWhite;
            this.last_name_label_ch.Location = new System.Drawing.Point(Size.Width - 560, height);
            this.last_name_label_ch.Name = "last_name";
            this.last_name_label_ch.Text = "Фамилия";
            //
            this.last_name_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.last_name_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.last_name_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.last_name_ch.Name = "FIO";
            this.last_name_ch.Size = new System.Drawing.Size(240, 30);
            this.last_name_ch.TabIndex = 1;
            this.last_name_ch.ReadOnly = false;
            // 
            // first_name
            // 
            height += 50;
            this.first_name_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.first_name_label_ch.ForeColor = Color.AntiqueWhite;
            this.first_name_label_ch.Location = new System.Drawing.Point(Size.Width - 560, height);
            this.first_name_label_ch.Name = "first_name";
            this.first_name_label_ch.Text = "Имя";
            //
            this.first_name_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.first_name_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.first_name_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.first_name_ch.Name = "FIO";
            this.first_name_ch.Size = new System.Drawing.Size(240, 30);
            this.first_name_ch.TabIndex = 1;
            this.first_name_ch.ReadOnly = false;
            // 
            // second_name
            // 
            height += 50;
            this.second_name_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.second_name_label_ch.ForeColor = Color.AntiqueWhite;
            this.second_name_label_ch.Location = new System.Drawing.Point(Size.Width - 560, height);
            this.second_name_label_ch.Name = "second_name";
            this.second_name_label_ch.Text = "Отчество ";
            //
            this.second_name_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.second_name_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.second_name_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.second_name_ch.Name = "FIO";
            this.second_name_ch.Size = new System.Drawing.Size(240, 30);
            this.second_name_ch.TabIndex = 1;
            this.second_name_ch.ReadOnly = false;
            // 
            // phone
            // 
            height += 50;
            this.phone_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phone_label_ch.ForeColor = Color.AntiqueWhite;
            this.phone_label_ch.Location = new System.Drawing.Point(Size.Width - 560, height);
            this.phone_label_ch.Name = "id";
            this.phone_label_ch.Text = "Телефон";
            //
            this.phone_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.phone_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phone_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.phone_ch.Name = "phone";
            this.phone_ch.Size = new System.Drawing.Size(240, 30);
            this.phone_ch.TabIndex = 2;
            this.phone_ch.ReadOnly = false;
            this.phone_ch.Mask = "+7(000)000-00-00";
            //
            //
            this.Controls.Add(this.first_name_ch);
            this.Controls.Add(this.second_name_ch);
            this.Controls.Add(this.last_name_ch);
            this.Controls.Add(this.phone_ch);
            //
            this.Controls.Add(this.first_name_label_ch);
            this.Controls.Add(this.second_name_label_ch);
            this.Controls.Add(this.last_name_label_ch);
            this.Controls.Add(this.phone_label_ch);
            //
            //
            fio_string = dt.Rows[0].Field<string>("FIO").Split(' ');
            //
            //
            this.first_name_ch.Text = fio_string[1];
            this.second_name_ch.Text = fio_string[2];
            this.last_name_ch.Text = fio_string[0];
            //
            //
            if (dt.Rows[0].Field<string>("phone") == null)
            {
                this.phone_ch.Text = "Отсутствует";
            }
            else { this.phone_ch.Text = dt.Rows[0].Field<string>("phone"); }
            //
            //

            this.parent_workplace_ch = new System.Windows.Forms.TextBox();
            //
            this.parent_info_label_ch = new System.Windows.Forms.Label();
            //
            height += 50;
            this.parent_info_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parent_info_label_ch.ForeColor = Color.AntiqueWhite;
            this.parent_info_label_ch.Location = new System.Drawing.Point(Size.Width - 560, height);
            this.parent_info_label_ch.AutoSize = true;
            this.parent_info_label_ch.Name = "Должность";
            this.parent_info_label_ch.Text = "Должность";
            // 
            // parent_workplace
            // 
            this.parent_workplace_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parent_workplace_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parent_workplace_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.parent_workplace_ch.Name = "post";
            this.parent_workplace_ch.Size = new System.Drawing.Size(240, 30);
            this.parent_workplace_ch.TabIndex = 1;
            this.parent_workplace_ch.ReadOnly = false;
            //
            //
            this.Controls.Add(this.parent_workplace_ch);
            //
            this.Controls.Add(this.parent_info_label_ch);
            //
            //
            this.parent_workplace_ch.Text = dt.Rows[0].Field<string>("post").ToString();
            //
            //
            this.ex_amount_ch = new System.Windows.Forms.TextBox();
            this.age_ch = new System.Windows.Forms.TextBox();
            this.spec_ch = new System.Windows.Forms.TextBox();
            //
            this.ex_amount_label_ch = new System.Windows.Forms.Label();
            this.age_label_ch = new System.Windows.Forms.Label();
            this.spec_label_ch = new System.Windows.Forms.Label();
            // 
            // age
            // 
            height += 50;
            this.age_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.age_label_ch.ForeColor = Color.AntiqueWhite;
            this.age_label_ch.Location = new System.Drawing.Point(Size.Width - 560, height);
            this.age_label_ch.Name = "login";
            this.age_label_ch.Text = "login";
            //
            this.age_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.age_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.age_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.age_ch.Name = "login";
            this.age_ch.Size = new System.Drawing.Size(240, 30);
            this.age_ch.TabIndex = 1;
            this.age_ch.ReadOnly = false;
            // 
            // specialization
            // 
            height += 50;
            this.spec_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spec_label_ch.ForeColor = Color.AntiqueWhite;
            this.spec_label_ch.Location = new System.Drawing.Point(Size.Width - 560, height);
            this.spec_label_ch.Name = "password";
            this.spec_label_ch.AutoSize = true;
            this.spec_label_ch.Text = "password";
            //
            this.spec_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spec_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spec_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.spec_ch.Name = "password";
            this.spec_ch.Size = new System.Drawing.Size(240, 30);
            this.spec_ch.TabIndex = 1;
            this.spec_ch.ReadOnly = false;
            // 
            // ex_amount
            // 
            height += 50;
            this.ex_amount_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ex_amount_label_ch.ForeColor = Color.AntiqueWhite;
            this.ex_amount_label_ch.Location = new System.Drawing.Point(Size.Width - 560, height - 10);
            this.ex_amount_label_ch.Name = "role";
            this.ex_amount_label_ch.AutoSize = true;
            this.ex_amount_label_ch.Text = "role";
            //
            this.ex_amount_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ex_amount_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ex_amount_ch.Location = new System.Drawing.Point(Size.Width - 400, height);
            this.ex_amount_ch.Name = "role";
            this.ex_amount_ch.Size = new System.Drawing.Size(240, 30);
            this.ex_amount_ch.TabIndex = 0;
            this.ex_amount_ch.ReadOnly = false;
            //
            //
            this.Controls.Add(this.ex_amount_ch);
            this.Controls.Add(this.age_ch);
            this.Controls.Add(this.spec_ch);
            this.Controls.Add(this.ex_amount_label_ch);
            this.Controls.Add(this.age_label_ch);
            this.Controls.Add(this.spec_label_ch);
            //
            //
            this.ex_amount_ch.Text = dt.Rows[0].Field<int>("role").ToString();
            this.age_ch.Text = dt.Rows[0].Field<string>("login").ToString();
            this.spec_ch.Text = dt.Rows[0].Field<string>("password").ToString();
        }

        private void FillForAddUser()
        {
            //
            //
            //change_data_layout ctrl m ctrl h ctrl u 560 400
            //
            //
            this.Width = this.Width / 2;
            exit_button_refresh();
            this.apply_changes = new System.Windows.Forms.Button();
            this.apply_changes.Location = new System.Drawing.Point(Size.Width - 130, 180);
            this.apply_changes.Name = "exit_button";
            this.apply_changes.Size = new System.Drawing.Size(100, 60);
            this.apply_changes.TabIndex = 0;
            this.apply_changes.Text = "Добавить";
            this.apply_changes.UseVisualStyleBackColor = true;
            this.apply_changes.Click += new System.EventHandler(this.apply_user_add_Button_Click);
            this.Controls.Add(this.apply_changes);
            //
            //
            this.first_name_ch = new System.Windows.Forms.TextBox();
            this.second_name_ch = new System.Windows.Forms.TextBox();
            this.last_name_ch = new System.Windows.Forms.TextBox();
            this.phone_ch = new System.Windows.Forms.MaskedTextBox();
            //
            this.first_name_label_ch = new System.Windows.Forms.Label();
            this.second_name_label_ch = new System.Windows.Forms.Label();
            this.last_name_label_ch = new System.Windows.Forms.Label();
            this.phone_label_ch = new System.Windows.Forms.Label();
            //
            //
            int height = 110;
            // 
            // last_name
            // 
            this.last_name_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.last_name_label_ch.ForeColor = Color.AntiqueWhite;
            this.last_name_label_ch.Location = new System.Drawing.Point(Size.Width - 500, height);
            this.last_name_label_ch.Name = "last_name";
            this.last_name_label_ch.Text = "Фамилия";
            //
            this.last_name_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.last_name_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.last_name_ch.Location = new System.Drawing.Point(Size.Width - 375, height);
            this.last_name_ch.Name = "FIO";
            this.last_name_ch.Size = new System.Drawing.Size(240, 30);
            this.last_name_ch.TabIndex = 1;
            this.last_name_ch.ReadOnly = false;
            // 
            // first_name
            // 
            height += 50;
            this.first_name_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.first_name_label_ch.ForeColor = Color.AntiqueWhite;
            this.first_name_label_ch.Location = new System.Drawing.Point(Size.Width - 500, height);
            this.first_name_label_ch.Name = "first_name";
            this.first_name_label_ch.Text = "Имя";
            //
            this.first_name_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.first_name_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.first_name_ch.Location = new System.Drawing.Point(Size.Width - 375, height);
            this.first_name_ch.Name = "FIO";
            this.first_name_ch.Size = new System.Drawing.Size(240, 30);
            this.first_name_ch.TabIndex = 1;
            this.first_name_ch.ReadOnly = false;
            // 
            // second_name
            // 
            height += 50;
            this.second_name_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.second_name_label_ch.ForeColor = Color.AntiqueWhite;
            this.second_name_label_ch.Location = new System.Drawing.Point(Size.Width - 500, height);
            this.second_name_label_ch.Name = "second_name";
            this.second_name_label_ch.Text = "Отчество ";
            //
            this.second_name_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.second_name_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.second_name_ch.Location = new System.Drawing.Point(Size.Width - 375, height);
            this.second_name_ch.Name = "FIO";
            this.second_name_ch.Size = new System.Drawing.Size(240, 30);
            this.second_name_ch.TabIndex = 1;
            this.second_name_ch.ReadOnly = false;
            // 
            // phone
            // 
            height += 50;
            this.phone_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phone_label_ch.ForeColor = Color.AntiqueWhite;
            this.phone_label_ch.Location = new System.Drawing.Point(Size.Width - 500, height);
            this.phone_label_ch.Name = "id";
            this.phone_label_ch.Text = "Телефон";
            //
            this.phone_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.phone_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phone_ch.Location = new System.Drawing.Point(Size.Width - 375, height);
            this.phone_ch.Name = "phone";
            this.phone_ch.Size = new System.Drawing.Size(240, 30);
            this.phone_ch.TabIndex = 2;
            this.phone_ch.ReadOnly = false;
            this.phone_ch.Mask = "+7(000)000-00-00";
            //
            //
            this.Controls.Add(this.first_name_ch);
            this.Controls.Add(this.second_name_ch);
            this.Controls.Add(this.last_name_ch);
            this.Controls.Add(this.phone_ch);
            //
            this.Controls.Add(this.first_name_label_ch);
            this.Controls.Add(this.second_name_label_ch);
            this.Controls.Add(this.last_name_label_ch);
            this.Controls.Add(this.phone_label_ch);
            //
            //
            this.first_name_ch.Text = "Иван";
            this.second_name_ch.Text = "Иванович";
            this.last_name_ch.Text = "Иванов";
            //
            //
            this.phone_ch.Text = "+7(999)999-99-99";
            //
            this.parent_workplace_ch = new System.Windows.Forms.TextBox();
            //
            this.parent_info_label_ch = new System.Windows.Forms.Label();
            //
            height += 50;
            this.parent_info_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parent_info_label_ch.ForeColor = Color.AntiqueWhite;
            this.parent_info_label_ch.Location = new System.Drawing.Point(Size.Width - 500, height);
            this.parent_info_label_ch.AutoSize = true;
            this.parent_info_label_ch.Name = "Должность";
            this.parent_info_label_ch.Text = "Должность";
            // 
            // parent_workplace
            // 
            this.parent_workplace_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.parent_workplace_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.parent_workplace_ch.Location = new System.Drawing.Point(Size.Width - 375, height);
            this.parent_workplace_ch.Name = "post";
            this.parent_workplace_ch.Size = new System.Drawing.Size(240, 30);
            this.parent_workplace_ch.TabIndex = 1;
            this.parent_workplace_ch.ReadOnly = false;
            //
            //
            this.Controls.Add(this.parent_workplace_ch);
            //
            this.Controls.Add(this.parent_info_label_ch);
            //
            //
            this.parent_workplace_ch.Text = "Преподаватель";
            //
            //
            this.ex_amount_ch = new System.Windows.Forms.TextBox();
            this.age_ch = new System.Windows.Forms.TextBox();
            this.spec_ch = new System.Windows.Forms.TextBox();
            //
            this.ex_amount_label_ch = new System.Windows.Forms.Label();
            this.age_label_ch = new System.Windows.Forms.Label();
            this.spec_label_ch = new System.Windows.Forms.Label();
            // 
            // age
            // 
            height += 50;
            this.age_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.age_label_ch.ForeColor = Color.AntiqueWhite;
            this.age_label_ch.Location = new System.Drawing.Point(Size.Width - 500, height);
            this.age_label_ch.Name = "login";
            this.age_label_ch.Text = "login";
            //
            this.age_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.age_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.age_ch.Location = new System.Drawing.Point(Size.Width - 375, height);
            this.age_ch.Name = "login";
            this.age_ch.Size = new System.Drawing.Size(240, 30);
            this.age_ch.TabIndex = 1;
            this.age_ch.ReadOnly = false;
            // 
            // specialization
            // 
            height += 50;
            this.spec_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spec_label_ch.ForeColor = Color.AntiqueWhite;
            this.spec_label_ch.Location = new System.Drawing.Point(Size.Width - 500, height);
            this.spec_label_ch.Name = "password";
            this.spec_label_ch.AutoSize = true;
            this.spec_label_ch.Text = "password";
            //
            this.spec_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spec_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spec_ch.Location = new System.Drawing.Point(Size.Width - 375, height);
            this.spec_ch.Name = "password";
            this.spec_ch.Size = new System.Drawing.Size(240, 30);
            this.spec_ch.TabIndex = 1;
            this.spec_ch.ReadOnly = false;
            // 
            // ex_amount
            // 
            height += 50;
            this.ex_amount_label_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ex_amount_label_ch.ForeColor = Color.AntiqueWhite;
            this.ex_amount_label_ch.Location = new System.Drawing.Point(Size.Width - 500, height - 10);
            this.ex_amount_label_ch.Name = "role";
            this.ex_amount_label_ch.AutoSize = true;
            this.ex_amount_label_ch.Text = "role";
            //
            this.ex_amount_ch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ex_amount_ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ex_amount_ch.Location = new System.Drawing.Point(Size.Width - 375, height);
            this.ex_amount_ch.Name = "role";
            this.ex_amount_ch.Size = new System.Drawing.Size(240, 30);
            this.ex_amount_ch.TabIndex = 0;
            this.ex_amount_ch.ReadOnly = false;
            //
            //
            this.Controls.Add(this.ex_amount_ch);
            this.Controls.Add(this.age_ch);
            this.Controls.Add(this.spec_ch);
            this.Controls.Add(this.ex_amount_label_ch);
            this.Controls.Add(this.age_label_ch);
            this.Controls.Add(this.spec_label_ch);
            //
            //
            this.ex_amount_ch.Text = "1";
            this.age_ch.Text = "логин";
            this.spec_ch.Text = "пароль".ToString();
        }

        private void apply_user_changes_Button_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "SELECT change_date FROM user_data Where id = @id";
            cmd.Parameters.AddWithValue("@id", this.row_id);
            conn.Open();
            string change_date = cmd.ExecuteScalar().ToString();
            cmd.Parameters.Clear();
            conn.Close();
            cmd.CommandText = "SELECT change_date FROM LoginInfo Where user_data_id = @id";
            cmd.Parameters.AddWithValue("@id", this.row_id);
            conn.Open();
            string change_date_2 = cmd.ExecuteScalar().ToString();
            cmd.Parameters.Clear();
            conn.Close();
            if (dt.Rows[0]["date1"].ToString() == change_date && dt.Rows[0]["date2"].ToString() == change_date_2)
            {
                MessageBox.Show(change_date);
                cmd.CommandText = "UPDATE user_data SET FIO = @FIO, phone = @phone, post = @post WHERE id = @id";
                cmd.Parameters.AddWithValue("@id", this.row_id.ToString());
                cmd.Parameters.AddWithValue("@FIO", (this.last_name_ch.Text.ToString() + " " + this.first_name_ch.Text.ToString() + " " + this.second_name_ch.Text.ToString()));
                cmd.Parameters.AddWithValue("@phone", this.phone_ch.Text.ToString());
                cmd.Parameters.AddWithValue("@post", this.parent_workplace_ch.Text.ToString());
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                cmd.Parameters.Clear();

                cmd.CommandText = "UPDATE LoginInfo SET login = @login, password = @password, role = @role WHERE user_data_id = @id";
                cmd.Parameters.AddWithValue("@id", this.row_id.ToString());
                cmd.Parameters.AddWithValue("@login", this.age_ch.Text.ToString());
                cmd.Parameters.AddWithValue("@password", this.spec_ch.Text.ToString());
                cmd.Parameters.AddWithValue("@role", this.ex_amount_ch.Text.ToString());
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                cmd.Parameters.Clear();
                this.Close();
            }
            else
            {
                MessageBox.Show("Данные устарели! Обновляем...");
                FillForStudentChanges();

            }
        }

        private void apply_user_add_Button_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "INSERT INTO user_data (FIO, phone, post) VALUES (@FIO, @phone, @post)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@FIO", (this.last_name_ch.Text.ToString() + " " + this.first_name_ch.Text.ToString() + " " + this.second_name_ch.Text.ToString()));
            cmd.Parameters.AddWithValue("@phone", this.phone_ch.Text.ToString());
            cmd.Parameters.AddWithValue("@post", this.parent_workplace_ch.Text.ToString());
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Parameters.Clear();
            //
            cmd.CommandText = "Select id from user_data ORDER BY id DESC LIMIT 1";
            conn.Open();
            string user_id = cmd.ExecuteScalar().ToString(); ;
            conn.Close();
            cmd.Parameters.Clear();
            //
            cmd.CommandText = "INSERT INTO LoginInfo (login, password, role, user_data_id) VALUES (@login, @password, @role, @user_data_id)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@user_data_id", user_id);
            cmd.Parameters.AddWithValue("@login", this.age_ch.Text.ToString());
            cmd.Parameters.AddWithValue("@password", this.spec_ch.Text.ToString());
            cmd.Parameters.AddWithValue("@role", this.ex_amount_ch.Text.ToString());
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Parameters.Clear();
            this.Close();
        }
        //
        //user_schedule
        //
        private void FillForUserScheduleDetails()
        {
            this.ClientSize = new System.Drawing.Size(700, 200);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            exit_button_refresh();

            this.grid_view = new System.Windows.Forms.DataGridView();

            GetDailySchedule();

            this.grid_view.AllowUserToAddRows = false;
            this.grid_view.DataSource = dt;

            this.grid_view.Font = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.grid_view.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.grid_view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grid_view.Location = new System.Drawing.Point(this.Size.Width - 675, 10);
            this.grid_view.Size = new System.Drawing.Size(this.Size.Width - 300, this.Size.Height - 150);
            //
            this.Controls.Add(grid_view);
        }

    }
}
