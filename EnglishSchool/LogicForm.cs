using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EnglishSchool
{
    public partial class LogicForm : Form
    {
        MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        MySqlConnection conn;
        MySqlCommand cmd;
        Size form_size;
        string user_id;

        int logic_variant;

        public LogicForm()
        {
            InitializeComponent();
        }
        public LogicForm(MySqlConnectionStringBuilder conn_string, int logic_variant, string user_id)
        {
            MessageBox.Show(user_id);
            this.logic_variant = logic_variant;
            this.conn_string = conn_string;
            this.user_id = user_id;
            conn = new MySqlConnection(conn_string.ToString());
            cmd = (MySqlCommand)conn.CreateCommand();
            InitializeComponent();
            FillFromVariant(logic_variant);


        }
        private void exit_button_Click(object sender, EventArgs e)//Кнопка выхода
        {
            this.Close();
        }

        private void FillFromVariant(int logic_variant)
        {
            this.label1 = new System.Windows.Forms.Label();
            this.db_data = new System.Windows.Forms.DataGridView();
            this.db_data.ReadOnly = true;
            if (logic_variant == 0) //students
            {


                this.all_rows_button = new System.Windows.Forms.Button();
                this.all_debt_students_button = new System.Windows.Forms.Button();
                this.row_change = new System.Windows.Forms.Button();
                this.row_detail = new System.Windows.Forms.Button();
                this.row_add = new System.Windows.Forms.Button();
                this.FIO_search = new System.Windows.Forms.TextBox();
                //
                //bd_gridview
                this.db_data.DataSource = GetAllStudents();
                this.db_data.DefaultCellStyle.Font = new Font("Arial", 12);
                this.db_data.Width = Size.Width - 400;
                this.db_data.Height = Size.Height-50;
                this.db_data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                this.db_data.ScrollBars = ScrollBars.Both;
                this.db_data.AllowUserToAddRows = false;
                this.db_data.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DB_student_DoubleClick);

                this.Controls.Add(this.db_data);
                //
                //all_rows_button
                this.all_rows_button.Location = new System.Drawing.Point(Size.Width - 150, 163);
                this.all_rows_button.Name = "all_students";
                this.all_rows_button.Size = new System.Drawing.Size(100, 100);
                this.all_rows_button.TabIndex = 1;
                this.all_rows_button.Text = "Все студенты";
                this.all_rows_button.UseVisualStyleBackColor = true;
                this.all_rows_button.Click += new System.EventHandler(this.all_students_button_Click);
                this.Controls.Add(this.all_rows_button);
                //
                //all_debt_students_button  all_debt_students_button_Click
                this.all_debt_students_button.Location = new System.Drawing.Point(Size.Width - 150, 263);
                this.all_debt_students_button.Name = "all_debt_students";
                this.all_debt_students_button.Size = new System.Drawing.Size(100, 100);
                this.all_debt_students_button.TabIndex = 2;
                this.all_debt_students_button.Text = "Студенты без занятий";
                this.all_debt_students_button.UseVisualStyleBackColor = true;
                this.all_debt_students_button.Click += new System.EventHandler(this.all_debt_students_button_Click);
                this.Controls.Add(this.all_debt_students_button);
                //
                //this.FIO_search
                this.label1.Text = "Поиск по ФИО";
                this.label1.Location = new System.Drawing.Point(Size.Width - 395, 113);
                this.FIO_search.Location = new System.Drawing.Point(Size.Width - 300, 113);
                this.FIO_search.Name = "FIO_search";
                this.FIO_search.Size = new System.Drawing.Size(300, 50);
                this.FIO_search.Font = new Font("Arial", 12);
                this.FIO_search.TextChanged += new System.EventHandler(this.FIO_search_TextChanged);
                this.Controls.Add(this.FIO_search);
                this.Controls.Add(this.label1);
                //
                //
                this.row_detail.Location = new System.Drawing.Point(Size.Width - 300, 163);
                this.row_detail.Name = "row_detail";
                this.row_detail.Size = new System.Drawing.Size(100, 100);
                this.row_detail.TabIndex = 0;
                this.row_detail.Text = "Подробнее о \nвыбранном \nстуденте";
                this.row_detail.UseVisualStyleBackColor = true;
                this.row_detail.Click += new System.EventHandler(this.detail_student_button_Click);
                //
                //
                this.row_change.Location = new System.Drawing.Point(Size.Width - 300, 263);
                this.row_change.Name = "row_change";
                this.row_change.Size = new System.Drawing.Size(100, 100);
                this.row_change.TabIndex = 0;
                this.row_change.Text = "изменить инф-у \nо студенте";
                this.row_change.UseVisualStyleBackColor = true;
                this.row_change.Click += new System.EventHandler(this.students_change_button_Click);
                //
                //
                this.row_add.Location = new System.Drawing.Point(Size.Width - 300, 363);
                this.row_add.Name = "row_add";
                this.row_add.Size = new System.Drawing.Size(250, 100);
                this.row_add.TabIndex = 0;
                this.row_add.Text = "Добавить нового \nстудента";
                this.row_add.UseVisualStyleBackColor = true;
                this.row_add.Click += new System.EventHandler(this.row_add_button_Click);
                //
                //
                this.Controls.Add(this.row_change);
                this.Controls.Add(this.row_detail);
                this.Controls.Add(this.row_add);

            }
            if (logic_variant == 1)
            {
                this.all_rows_button = new System.Windows.Forms.Button();
                this.row_change = new System.Windows.Forms.Button();
                this.row_detail = new System.Windows.Forms.Button();
                this.row_add = new System.Windows.Forms.Button();
                this.FIO_search = new System.Windows.Forms.TextBox();
                this.Size = new System.Drawing.Size(1000, 450);
                exit_button_refresh();
                //
                //bd_gridview
                //
                this.db_data.DataSource = GetAllSchedule();
                this.db_data.DefaultCellStyle.Font = new Font("Arial", 12);
                this.db_data.Width = Size.Width - 300;
                this.db_data.Height = Size.Height - 20;
                this.db_data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                this.db_data.ScrollBars = ScrollBars.Both;
                this.db_data.AllowUserToAddRows = false;

                //this.db_data.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DB_schedule_DoubleClick);

                this.Controls.Add(this.db_data);
                //
                //all_rows_button
                this.all_rows_button.Location = new System.Drawing.Point(Size.Width - 130, 73);
                this.all_rows_button.Name = "all_schedule";
                this.all_rows_button.Size = new System.Drawing.Size(100, 100);
                this.all_rows_button.TabIndex = 1;
                this.all_rows_button.Text = "Обновить список \nрасписаний";
                this.all_rows_button.UseVisualStyleBackColor = true;
                this.all_rows_button.Click += new System.EventHandler(this.all_schedule_button_Click);
                this.Controls.Add(this.all_rows_button);
                //
                //
                this.row_detail.Location = new System.Drawing.Point(Size.Width - 280, 73);
                this.row_detail.Name = "row_detail";
                this.row_detail.Size = new System.Drawing.Size(100, 100);
                this.row_detail.TabIndex = 0;
                this.row_detail.Text = "Просмотреть \nрасписание";
                this.row_detail.UseVisualStyleBackColor = true;
                this.row_detail.Click += new System.EventHandler(this.detail_schedule_button_Click);
                //
                //
                this.row_change.Location = new System.Drawing.Point(Size.Width - 280, 173);
                this.row_change.Name = "row_change";
                this.row_change.Size = new System.Drawing.Size(250, 100);
                this.row_change.TabIndex = 0;
                this.row_change.Text = "продлить/сократить \nрасписание";
                this.row_change.UseVisualStyleBackColor = true;
                this.row_change.Click += new System.EventHandler(this.schedule_change_button_Click);
                //
                //
                this.row_add.Location = new System.Drawing.Point(Size.Width - 280, 273);
                this.row_add.Name = "row_add";
                this.row_add.Size = new System.Drawing.Size(250, 100);
                this.row_add.TabIndex = 0;
                this.row_add.Text = "Добавить новое \nрасписание";
                this.row_add.UseVisualStyleBackColor = true;
                this.row_add.Click += new System.EventHandler(this.row_add_button_Click);
                //
                //
                this.Controls.Add(this.row_change);
                this.Controls.Add(this.row_detail);
                this.Controls.Add(this.row_add);
            }
            if (logic_variant == 2)
            {
                this.Size = new System.Drawing.Size(280, 280);
                exit_button_refresh();

                this.db_data.DataSource = GetallGroups();
                this.db_data.DefaultCellStyle.Font = new Font("Arial", 12);
                this.db_data.Width = Size.Width - 100;
                this.db_data.Height = Size.Height - 100;
                this.db_data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                this.db_data.ScrollBars = ScrollBars.Vertical;
                this.db_data.AllowUserToAddRows = false;
                this.db_data.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DB_groups_DoubleClick);
                this.Controls.Add(this.db_data);

            }
            if (logic_variant == 3)
            {
                this.Height = 580;
                this.Width = 1024;
                exit_button_refresh();
                this.all_rows_button = new System.Windows.Forms.Button();
                this.row_change = new System.Windows.Forms.Button();
                this.row_detail = new System.Windows.Forms.Button();
                this.row_add = new System.Windows.Forms.Button();
                this.FIO_search = new System.Windows.Forms.TextBox();
                //
                //bd_gridview
                this.db_data.DataSource = GetAllUsers();
                this.db_data.DefaultCellStyle.Font = new Font("Arial", 12);
                this.db_data.Width = Size.Width - 400;
                this.db_data.Height = Size.Height-50;
                this.db_data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                this.db_data.ScrollBars = ScrollBars.Both;
                this.db_data.AllowUserToAddRows = false;
                this.db_data.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DB_user_DoubleClick);
                this.Controls.Add(this.db_data);
                //
                //all_rows_button
                this.all_rows_button.Location = new System.Drawing.Point(Size.Width - 150, 163);
                this.all_rows_button.Name = "all_students";
                this.all_rows_button.Size = new System.Drawing.Size(100, 100);
                this.all_rows_button.TabIndex = 1;
                this.all_rows_button.Text = "Все пользователи";
                this.all_rows_button.UseVisualStyleBackColor = true;
                this.all_rows_button.Click += new System.EventHandler(this.all_users_button_Click);
                this.Controls.Add(this.all_rows_button);
                //
                //this.FIO_search
                this.label1.Text = "Поиск по ФИО";
                this.label1.Location = new System.Drawing.Point(Size.Width - 395, 113);
                this.FIO_search.Location = new System.Drawing.Point(Size.Width - 300, 113);
                this.FIO_search.Name = "FIO_search";
                this.FIO_search.Size = new System.Drawing.Size(300, 50);
                this.FIO_search.Font = new Font("Arial", 12);
                this.FIO_search.TextChanged += new System.EventHandler(this.FIO_user_search_TextChanged);
                this.Controls.Add(this.FIO_search);
                this.Controls.Add(this.label1);
                //
                //
                this.row_detail.Location = new System.Drawing.Point(Size.Width - 300, 163);
                this.row_detail.Name = "row_detail";
                this.row_detail.Size = new System.Drawing.Size(100, 100);
                this.row_detail.TabIndex = 0;
                this.row_detail.Text = "Подробнее о \nпользователе";
                this.row_detail.UseVisualStyleBackColor = true;
                this.row_detail.Click += new System.EventHandler(this.detail_user_button_Click);
                //
                //
                this.row_change.Location = new System.Drawing.Point(Size.Width - 300, 263);
                this.row_change.Name = "row_change";
                this.row_change.Size = new System.Drawing.Size(100, 100);
                this.row_change.TabIndex = 0;
                this.row_change.Text = "изменить инф-у \nо пользователе";
                this.row_change.UseVisualStyleBackColor = true;
                this.row_change.Click += new System.EventHandler(this.user_change_button_Click);
                //
                //
                this.row_add.Location = new System.Drawing.Point(Size.Width - 300, 363);
                this.row_add.Name = "row_add";
                this.row_add.Size = new System.Drawing.Size(250, 100);
                this.row_add.TabIndex = 0;
                this.row_add.Text = "Добавить нового \nпользователя";
                this.row_add.UseVisualStyleBackColor = true;
                this.row_add.Click += new System.EventHandler(this.row_add_button_Click);
                //
                //
                this.Controls.Add(this.row_change);
                this.Controls.Add(this.row_detail);
                this.Controls.Add(this.row_add);
            }
            if (logic_variant == 4)
            {
                this.Size = new System.Drawing.Size(610, 540);
                exit_button_refresh();
                //
                //bd_gridview
                //
                this.db_data.DataSource = GetUserSchedule();
                this.db_data.DefaultCellStyle.Font = new Font("Arial", 12);
                this.db_data.Width = Size.Width - 150;
                this.db_data.Height = Size.Height - 20;
                this.db_data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                this.db_data.ScrollBars = ScrollBars.Both;
                this.db_data.AllowUserToAddRows = false;

                this.db_data.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DB_schedule_DoubleClick);

                this.Controls.Add(this.db_data);
            }
            if (logic_variant == 5)
            {
                this.Size = new System.Drawing.Size(280, 280);
                form_size = this.Size;
                exit_button_refresh();

                this.db_data.DataSource = GetUserGroups();
                this.db_data.DefaultCellStyle.Font = new Font("Arial", 12);
                this.db_data.Width = Size.Width - 100;
                this.db_data.Height = Size.Height - 100;
                this.db_data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                this.db_data.ScrollBars = ScrollBars.Vertical;
                this.db_data.AllowUserToAddRows = false;
                this.db_data.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DB_groups_DoubleClick);
                this.Controls.Add(this.db_data);
            }
            if (logic_variant == 6)
            {

                this.Size = new System.Drawing.Size(this.Size.Width, this.Size.Height);
                exit_button_refresh();
                date_picker = new DateTimePicker();
                date_picker.Size = new Size(300, 25);
                date_picker.Location = new Point(10, 10);
                date_picker.Font = new Font("Arial", 20);
                date_picker.Format = DateTimePickerFormat.Custom;
                date_picker.CustomFormat = "yyyy/MM/dd HH:mm:ss";
                date_picker.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                date_picker.TextChanged += new EventHandler(dateChanged); 
                this.Controls.Add(date_picker);
                this.row_add = new System.Windows.Forms.Button();
                this.row_add.Location = new System.Drawing.Point(Size.Width - 300, 363);
                this.row_add.Name = "ex-write";
                this.row_add.Size = new System.Drawing.Size(250, 100);
                this.row_add.TabIndex = 0;
                this.row_add.Text = "Провести";
                this.row_add.UseVisualStyleBackColor = true;
                this.row_add.Click += new System.EventHandler(this.ex_write_button);
                this.Controls.Add(row_add);
                displayEx(DateTime.Now);
                this.Controls.Add(this.db_data);
                this.Load += new EventHandler(exforuser_load);
                
            }
        }

        private void exit_button_refresh()
        {
            this.exit_button.Location = new System.Drawing.Point(Size.Width - 90, 10);
        }

        //students

        private void all_students_button_Click(object sender, EventArgs e)//Кнопка выхода
        {
            this.db_data.DataSource = GetAllStudents();
            this.db_data.Refresh();
            //this.db_data.Columns[this.db_data.Columns.Count - 1].Visible = false;
        }

        private void all_debt_students_button_Click(object sender, EventArgs e)//Кнопка выхода
        {
            this.db_data.DataSource = GetDebtorStudents();
            this.db_data.Refresh();
            //this.db_data.Columns[this.db_data.Columns.Count - 1].Visible = false;
        }

        private DataTable GetAllStudents()
        {

            cmd.CommandText = "SELECT * FROM students WHERE status = 1";
            conn.Open();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                dt2.Clear();
                if (dr.HasRows)
                {
                    dt2.Load(dr);
                }
            }
            conn.Close();
            cmd.Parameters.Clear();
            return dt2;
        }

        private DataTable GetDebtorStudents()
        {

            cmd.CommandText = "SELECT * FROM students Where exercise_amount <= 0";
            conn.Open();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                dt2.Clear();
                if (dr.HasRows)
                {
                    dt2.Load(dr);
                }
            }
            conn.Close();
            return dt2;
        }

        private void students_change_button_Click(object sender, EventArgs e)
        {
            int rowindex = db_data.CurrentRow.Index;
            Show_student_variant(rowindex, 0);
        }

        private void detail_student_button_Click(object sender, EventArgs e)
        {
            int rowindex = db_data.CurrentRow.Index;
            Show_student_variant(rowindex, 1);
        }

        private void Show_student_variant(int rowindex, int variant)
        {
            //e.RowIndex
            if (variant == 0 || variant == 1)
            {
                try
                {
                    int detail_subject_id = (int)dt2.Rows[rowindex][0];
                    DetailView detail_view = new DetailView(conn_string, detail_subject_id, variant);

                    detail_view.ShowDialog();

                    detail_view.Closed += (o, args) =>
                    {
                        dt.Clear();
                        this.db_data.DataSource = GetAllStudents();
                        this.Refresh();
                    };
                }
                catch (Exception ex) { MessageBox.Show("Выберите строку, а не оглавление"); }
            }
            if (variant == 2)
            {
                try
                {
                    DetailView detail_view = new DetailView(conn_string, variant);

                    detail_view.ShowDialog();

                    detail_view.Closed += (o, args) =>
                    {
                        dt.Clear();
                        this.db_data.DataSource = GetAllStudents();
                        this.db_data.Refresh();
                    };
                }
                catch (Exception ex) { MessageBox.Show("ошибка"); }
            }
        }
        string FIO_text;

        private void FIO_search_TextChanged(object sender, EventArgs e)
        {
            FIO_text = FIO_search.Text.ToString();
            if (FIO_text.Length >= 3)
            {
                cmd.CommandText = "SELECT * FROM students Where LOCATE (@value,FIO) > 0";

                cmd.Parameters.AddWithValue("@value", FIO_text);
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
                this.db_data.DataSource = dt;
                this.db_data.Refresh();
                cmd.Parameters.Clear();
            }
            else
            {
                this.db_data.DataSource = GetAllStudents();
                this.db_data.Refresh();
            }
        }

        private void DB_student_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (logic_variant == 0)
            {
                int rowindex = db_data.CurrentRow.Index;
                Show_student_variant(rowindex, 1);
            }
            if (logic_variant == 5)
            {
                int rowindex = grid_view.CurrentRow.Index;
                Show_student_variant(rowindex, 1);
            }
        }

        //schedule

        private DataTable GetAllSchedule()
        {

            cmd.CommandText = "SELECT schedule.id, user_data.FIO as 'ФИО учителя', groups.group_name AS группа, schedule.start_date as начало, " +
                "schedule.end_date as конец, schedule.change_date FROM schedule " +
                "JOIN user_data ON schedule.teacher_id = user_data.id JOIN groups ON schedule.group_id = groups.id WHERE schedule.end_date > @current_date";
            conn.Open();
            string today = DateTime.Today.ToString("yyyy:MM:dd");
            cmd.Parameters.AddWithValue("@current_date", today);
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

        private void all_schedule_button_Click(object sender, EventArgs e)
        {
            this.db_data.DataSource = GetAllSchedule();
            this.db_data.Refresh();
            //this.db_data.Columns[this.db_data.Columns.Count - 1].Visible = false;
        }

        private void detail_schedule_button_Click(object sender, EventArgs e)
        {
            int rowindex = db_data.CurrentRow.Index;
            Show_schedule_variant(rowindex, 3);
        }

        private void schedule_change_button_Click(Object sender, EventArgs e)
        {
            int rowindex = db_data.CurrentRow.Index;
            Show_schedule_variant(rowindex, 4);
        }

        private void Show_schedule_variant(int rowindex, int variant)
        {
            if (variant == 3 || variant == 4)
            {
                try
                {
                    int detail_subject_id = dt.Rows[rowindex].Field<int>("id");
                    DetailView detail_view = new DetailView(conn_string, detail_subject_id, variant);

                    detail_view.ShowDialog();

                    detail_view.Closed += (o, args) =>
                    {
                        dt.Clear();
                        this.db_data.DataSource = GetAllSchedule();
                        this.db_data.Refresh();
                    };
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            if (variant == 5)
            {
                try
                {
                    DetailView detail_view = new DetailView(conn_string, variant);

                    detail_view.ShowDialog();

                    detail_view.Closed += (o, args) =>
                    {
                        dt.Clear();
                        this.db_data.DataSource = GetAllSchedule();
                        this.db_data.Refresh();
                    };
                }
                catch (Exception ex) { MessageBox.Show("ошибка"); }
            }
        }

        private void row_add_button_Click(object sender, EventArgs e)
        {
            int rowindex = -1;
            if (logic_variant == 0)
                Show_student_variant(rowindex, 2);
            else if (logic_variant == 1)
                Show_schedule_variant(rowindex, 5);
            else if (logic_variant == 3)
                Show_user_variant(rowindex, 9);
        }

        //Groups

        private DataTable GetallGroups()
        {
            //select * from student_division join students on student_division.student_id = students.id where student_division.group_id = 1
            //select student_division.group_id as 'jija',students.FIO as 'FIO' from student_division join students on student_division.student_id = students.id where student_division.group_id = 1
            cmd.CommandText = "SELECT groups.id, groups.group_name as 'группа' FROM groups";
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
            return dt;
        }

        private void DB_groups_DoubleClick(object sender, EventArgs e)
        {
            if (logic_variant == 2)
            {
                int rowindex = db_data.CurrentRow.Index;
                Show_group_variant(rowindex, 6);
            }
            else
            {
                int rowindex = db_data.CurrentRow.Index;
                Show_group_variant(rowindex, 11);
            }
        }

        private void Show_group_variant(int rowindex, int variant)
        {
            if (logic_variant == 2)
            {
                try
                {
                    int detail_subject_id = dt.Rows[rowindex].Field<int>("id");
                    DetailView detail_view = new DetailView(conn_string, detail_subject_id, variant);

                    detail_view.ShowDialog();

                    detail_view.Closed += (o, args) =>
                    {
                        dt.Clear();
                        this.db_data.DataSource = GetAllStudents();
                        this.Refresh();
                    };
                }
                catch (Exception ex) { MessageBox.Show("Выберите строку, а не оглавление"); }
            }
            else
            {
                int detail_subject_id = dt.Rows[rowindex].Field<int>("id");
                FillForGroupDetails(detail_subject_id);
            }

        }

        //users
        private DataTable GetAllUsers()
        {

            cmd.CommandText = "SELECT * FROM user_data";
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
            return dt;
        }

        private void FIO_user_search_TextChanged(object sender, EventArgs e)
        {
            FIO_text = FIO_search.Text.ToString();
            if (FIO_text.Length >= 3)
            {
                cmd.CommandText = "SELECT * FROM user_data Where LOCATE (@value,FIO) > 0";

                cmd.Parameters.AddWithValue("@value", FIO_text);
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
                this.db_data.DataSource = dt;
                this.db_data.Refresh();
                cmd.Parameters.Clear();
            }
            else
            {
                this.db_data.DataSource = GetAllUsers();
                this.db_data.Refresh();
            }
        }

        private void all_users_button_Click(object sender, EventArgs e)//Кнопка выхода
        {
            this.db_data.DataSource = GetAllUsers();
            this.db_data.Refresh();
            //this.db_data.Columns[this.db_data.Columns.Count - 1].Visible = false;
        }

        private void DB_user_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = db_data.CurrentRow.Index;
            Show_user_variant(rowindex, 7);
        }

        private void detail_user_button_Click(object sender, EventArgs e)
        {
            int rowindex = db_data.CurrentRow.Index;
            Show_user_variant(rowindex, 7);
        }

        private void user_change_button_Click(object sender, EventArgs e)
        {
            int rowindex = db_data.CurrentRow.Index;
            Show_user_variant(rowindex, 8);
        }

        private void Show_user_variant(int rowindex, int variant)
        {
            //e.RowIndex
            if (variant == 7 || variant == 8)
            {
                try
                {
                    int detail_subject_id = dt.Rows[rowindex].Field<int>("id");
                    DetailView detail_view = new DetailView(conn_string, detail_subject_id, variant);

                    detail_view.ShowDialog();

                    detail_view.Closed += (o, args) =>
                    {
                        dt.Clear();
                        this.db_data.DataSource = GetAllUsers();
                        this.Refresh();
                    };
                }
                catch (Exception ex) { MessageBox.Show("Выберите строку, а не оглавление"); }
            }
            if (variant == 9)
            {
                try
                {
                    DetailView detail_view = new DetailView(conn_string, variant);

                    detail_view.ShowDialog();

                    detail_view.Closed += (o, args) =>
                    {
                        dt.Clear();
                        this.db_data.DataSource = GetAllUsers();
                        this.db_data.Refresh();
                    };
                }
                catch (Exception ex) { MessageBox.Show("ошибка"); }
            }
        }

        //user_schedule

        private DataTable GetUserSchedule()
        {

            cmd.CommandText = "SELECT schedule.id, groups.group_name AS группа, schedule.start_date as начало, " +
                "schedule.end_date as конец, schedule.change_date FROM schedule " +
                "JOIN groups ON schedule.group_id = groups.id WHERE schedule.end_date > @current_date AND schedule.teacher_id = @user_id";
            conn.Open();
            string today = DateTime.Today.ToString("yyyy:MM:dd");
            cmd.Parameters.AddWithValue("@current_date", today);
            cmd.Parameters.AddWithValue("@user_id", user_id);
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
        private void DB_schedule_DoubleClick(object sender, EventArgs e)
        {
            int rowindex = db_data.CurrentRow.Index;
            try
            {
                int detail_subject_id = dt.Rows[rowindex].Field<int>("id");
                DetailView detail_view = new DetailView(conn_string, detail_subject_id, 10);

                detail_view.ShowDialog();

                detail_view.Closed += (o, args) =>
                {
                    dt.Clear();
                    this.db_data.DataSource = GetAllSchedule();
                    this.db_data.Refresh();
                };
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        //user_groups

        private DataTable GetUserGroups()
        {
            DataTable rdt = new DataTable();

            cmd.CommandText = "SELECT schedule.group_id FROM schedule " +
                "WHERE schedule.end_date > @current_date AND schedule.teacher_id = @user_id";
            conn.Open();
            string today = DateTime.Today.ToString("yyyy:MM:dd");
            cmd.Parameters.AddWithValue("@current_date", today);
            cmd.Parameters.AddWithValue("@user_id", user_id);
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                dt.Clear();
                if (dr.HasRows)
                {
                    rdt.Load(dr);
                }
            }
            conn.Close();
            cmd.Parameters.Clear();

            cmd.CommandText = "SELECT groups.id, groups.group_name as 'группа' FROM groups WHERE ";

            cmd.CommandText += ("groups.id = " + rdt.Rows[0][0].ToString());

            for (int i = 1; i < rdt.Rows.Count; i++)
            {
                cmd.CommandText += (" OR groups.id = " + rdt.Rows[i][0].ToString());
            }

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
            return dt;
        }

        private void FillForGroupDetails(int row_id)
        {
            this.Size = new Size(form_size.Width * 3, form_size.Height * 3);
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.exit_button.Hide();
            this.db_data.Hide();
            this.grid_view = new System.Windows.Forms.DataGridView();
            //
            this.grid_view.DataSource = GetallStudentFromGroup(row_id);
            this.grid_view.DefaultCellStyle.Font = new Font("Arial", 12);
            this.grid_view.Width = 700;
            this.grid_view.Height = Size.Height - 50;
            this.grid_view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grid_view.ScrollBars = ScrollBars.Both;
            this.grid_view.AllowUserToAddRows = false;
            this.grid_view.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DB_student_DoubleClick);
            this.Controls.Add(this.grid_view);

            this.back = new System.Windows.Forms.Button();

            this.back.Location = new System.Drawing.Point(Size.Width - 90, 10);
            this.back.Name = "exit_button";
            this.back.Size = new System.Drawing.Size(60, 60);
            this.back.TabIndex = 0;
            this.back.Text = "Назад";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_button_Click);

            this.Controls.Add(this.back);

        }

        private DataTable GetallStudentFromGroup(int row_id)
        {
            //select * from student_division join students on student_division.student_id = students.id where student_division.group_id = 1
            //select student_division.group_id as 'jija',students.FIO as 'FIO' from student_division join students on student_division.student_id = students.id where student_division.group_id = 1
            cmd.Parameters.Clear();
            cmd.CommandText = "select students.id as 'student_id', student_division.group_id as 'группа',students.FIO as 'FIO', student_division.change_date, student_division.id from student_division " +
                "join students on student_division.student_id = students.id where student_division.group_id = @id";
            conn.Open();

            cmd.Parameters.AddWithValue("@id", row_id.ToString());
            dt2.Clear();
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                dt2.Clear();
                if (dr.HasRows)
                {
                    dt2.Load(dr);
                }
            }
            conn.Close();
            cmd.Parameters.Clear();
            return dt2;
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Size = form_size;
            this.CenterToScreen();
            exit_button_refresh();
            grid_view.Hide();
            this.back.Hide();
            this.db_data.Show();
            this.exit_button.Show();
        }

        //user_exes

        private DataTable user_ex(DateTime now)
        {
            try
            {
                this.db_data.DataSource = null;
                DataTable rdt = new DataTable();
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT id from schedule WHERE teacher_id = @te_id";
                conn.Open();
                cmd.Parameters.AddWithValue("@te_id", user_id);
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    rdt.Clear();
                    if (dr.HasRows)
                    {
                        rdt.Load(dr);
                    }
                }
                conn.Close();
                cmd.Parameters.Clear();
                
                // получение id группы из таблицы "расписания"
                int groupId = 0;
                // получение текущей даты и времени
                int dayOfWeek = (int)now.DayOfWeek;
                conn.Open();

                // формирование SQL-запроса для выборки записей из таблицы "дневное расписание"
                cmd.CommandText = "SELECT * FROM daily_schedule WHERE (schedule_id = ";
                cmd.CommandText += (rdt.Rows[0][0].ToString());
                for (int i = 1; i < rdt.Rows.Count; i++)
                {
                    cmd.CommandText += (" OR schedule_id = " + rdt.Rows[i][0].ToString());
                }
                cmd.CommandText += ")" + " AND day = " + dayOfWeek.ToString() + " AND start_time >= " + "'" + now.ToString("HH:mm:ss") + "'" + " ORDER BY start_time";
                // выполнение запроса и получение списка записей

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
                
                conn.Open();
                cmd.CommandText = "SELECT schedule.group_id FROM schedule WHERE schedule.id = @scheduleId";
                cmd.Parameters.AddWithValue("@scheduleId", dt.Rows[0][1].ToString());

                groupId = Convert.ToInt16(cmd.ExecuteScalar());

                // закрытие соединения с базой данных
                conn.Close();

                cmd.Parameters.Clear();

                this.row_add.Show();

                return GetallStudentFromGroup(groupId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сейчас занятий у вас нет. Выберите дату сами, если считаете иначе   "+ ex.Message.ToString());
                conn.Close();
                this.row_add.Hide();
                return null;
            }
        }

        private void displayEx(DateTime now)
        {
            this.db_data.DataSource = user_ex(now);
            this.db_data.DefaultCellStyle.Font = new Font("Arial", 20);
            this.db_data.Location = new System.Drawing.Point(0, 100);
            this.db_data.Width = Size.Width - 500;
            this.db_data.Height = Size.Height - 200;
            this.db_data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.db_data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.db_data.ScrollBars = ScrollBars.Both;
            this.db_data.AllowUserToAddRows = false;
            
            this.db_data.Refresh();

        }

        private void dateChanged(object sender, EventArgs e)
        {
            this.db_data.Columns.Clear();
            this.db_data.ReadOnly= false;
            DateTime date = DateTime.Parse(date_picker.Text);
            MessageBox.Show(date.ToString());
            displayEx(date);
            

        }

        private void ex_write_button(object sender, EventArgs e)
        {
            this.row_add.Hide();

            //	id	student_id	teacher_id	ex_date	status	change_date	

            DateTime date = DateTime.Parse(date_picker.Text);
            try
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    if (db_data.Rows[i].Cells[5].Value.ToString() == "Б" || db_data.Rows[i].Cells[5].Value.ToString() == "Н")
                    {
                        conn.Open();
                        cmd.Parameters.Clear();
                        cmd.CommandText = "UPDATE students SET exercise_amount = exercise_amount-1 WHERE id = @student_id";
                        cmd.Parameters.AddWithValue("@student_id", dt2.Rows[i][0].ToString());
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    conn.Open();
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT exircise (student_id, teacher_id, ex_date, status) VALUES (@student_id, @teacher_id, '" + date.Date.ToString("yyyy-MM-dd") + "', @status)";
                    cmd.Parameters.AddWithValue("@student_id", dt2.Rows[i][0].ToString());
                    cmd.Parameters.AddWithValue("@teacher_id", user_id.ToString());

                    switch (db_data.Rows[i].Cells[5].Value.ToString())
                    {
                        case "Б":
                            cmd.Parameters.AddWithValue("@status", '1');
                            break;
                        case "Н":
                            cmd.Parameters.AddWithValue("@status", '2');
                            break;
                        case "У":
                            cmd.Parameters.AddWithValue("@status", '3');
                            break;

                    }
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
                MessageBox.Show("succes!");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void exforuser_load(object sender, EventArgs e)
        {
            this.db_data.ReadOnly = false;
            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.Name = "Статус";

            comboBoxColumn.HeaderText = "Статус";

            comboBoxColumn.DataSource = new string[] { "Б", "Н", "У" };

            comboBoxColumn.DataPropertyName = "Статус";

            comboBoxColumn.ReadOnly = false;

            this.db_data.Columns.Add(comboBoxColumn);

            for (int i = 0; i < db_data.ColumnCount - 1; i++)
            {
                this.db_data.Columns[i].ReadOnly = true;
            }
        }
    }
    
}

