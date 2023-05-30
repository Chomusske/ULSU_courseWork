using System.Windows.Forms;

namespace EnglishSchool
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(int role)
        {
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            if (role == 2)
            { 
            this.exit_button = new System.Windows.Forms.Button();
            this.students_button = new System.Windows.Forms.Button();
            this.schedule_button = new System.Windows.Forms.Button();
            this.groups_button = new System.Windows.Forms.Button();
            this.users_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(722, 13);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(75, 60);
            this.exit_button.TabIndex = 0;
            this.exit_button.Text = "Выход";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // students_button
            // 
            this.students_button.Location = new System.Drawing.Point(50, 43);
            this.students_button.Name = "students_button";
            this.students_button.Size = new System.Drawing.Size(600, 60);
            this.students_button.TabIndex = 0;
            this.students_button.Text = "Студенты";
            this.students_button.UseVisualStyleBackColor = true;
            this.students_button.Click += new System.EventHandler(this.students_button_Click);
            // 
            // schedule_button
            // 
            this.schedule_button.Location = new System.Drawing.Point(50, 123);
            this.schedule_button.Name = "schedule_button";
            this.schedule_button.Size = new System.Drawing.Size(600, 60);
            this.schedule_button.TabIndex = 0;
            this.schedule_button.Text = "Расписания";
            this.schedule_button.UseVisualStyleBackColor = true;
            this.schedule_button.Click += new System.EventHandler(this.schedule_button_Click);
            // 
            // groups_button
            // 
            this.groups_button.Location = new System.Drawing.Point(50, 203);
            this.groups_button.Name = "groups_button";
            this.groups_button.Size = new System.Drawing.Size(600, 60);
            this.groups_button.TabIndex = 0;
            this.groups_button.Text = "Группы";
            this.groups_button.UseVisualStyleBackColor = true;
            this.groups_button.Click += new System.EventHandler(this.groups_button_Click);
            // 
            // users_button
            // 
            this.users_button.Location = new System.Drawing.Point(50, 283);
            this.users_button.Name = "users_button";
            this.users_button.Size = new System.Drawing.Size(600, 60);
            this.users_button.TabIndex = 0;
            this.users_button.Text = "Пользователи Системы";
            this.users_button.UseVisualStyleBackColor = true;
            this.users_button.Click += new System.EventHandler(this.users_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.students_button);
            this.Controls.Add(this.schedule_button);
            this.Controls.Add(this.groups_button);
            this.Controls.Add(this.users_button);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            }
            else if (role == 1)
            {
                this.exit_button = new System.Windows.Forms.Button();
                this.exircise_button = new System.Windows.Forms.Button();
                this.user_schedule_button = new System.Windows.Forms.Button();
                this.user_groups_button = new System.Windows.Forms.Button();
                this.SuspendLayout();
                // 
                // exit_button
                // 
                this.exit_button.Location = new System.Drawing.Point(722, 13);
                this.exit_button.Name = "exit_button";
                this.exit_button.Size = new System.Drawing.Size(75, 60);
                this.exit_button.TabIndex = 0;
                this.exit_button.Text = "Выход";
                this.exit_button.UseVisualStyleBackColor = true;
                this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
                // 
                // students_button
                // 
                this.exircise_button.Location = new System.Drawing.Point(50, 43);
                this.exircise_button.Name = "exircise";
                this.exircise_button.Size = new System.Drawing.Size(600, 80);
                this.exircise_button.TabIndex = 0;
                this.exircise_button.Text = "Занятие";
                this.exircise_button.UseVisualStyleBackColor = true;
                this.exircise_button.Click += new System.EventHandler(this.exircise_button_Click);
                // 
                // schedule_button
                // 
                this.user_schedule_button.Location = new System.Drawing.Point(50, 173);
                this.user_schedule_button.Name = "user_schedule_button";
                this.user_schedule_button.Size = new System.Drawing.Size(600, 80);
                this.user_schedule_button.TabIndex = 0;
                this.user_schedule_button.Text = "Ваше Расписания";
                this.user_schedule_button.UseVisualStyleBackColor = true;
                this.user_schedule_button.Click += new System.EventHandler(this.user_schedule_button_Click);
                // 
                // groups_button
                // 
                this.user_groups_button.Location = new System.Drawing.Point(50, 293);
                this.user_groups_button.Name = "user_groups_button";
                this.user_groups_button.Size = new System.Drawing.Size(600, 80);
                this.user_groups_button.TabIndex = 0;
                this.user_groups_button.Text = "Ваши Группы";
                this.user_groups_button.UseVisualStyleBackColor = true;
                this.user_groups_button.Click += new System.EventHandler(this.user_groups_button_Click);
               
                // 
                // MainForm
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(800, 450);
                this.Controls.Add(this.exit_button);
                this.Controls.Add(this.exircise_button);
                this.Controls.Add(this.user_schedule_button);
                this.Controls.Add(this.user_groups_button);
                this.Name = "MainForm";
                this.Text = "MainForm";
                this.ResumeLayout(false);
            }
            else
            {
                MessageBox.Show("Invalid User Role! Pls don't hack this App :*");
                Application.Exit();
            }
        }
        private void InitializeComponent()
        {
            this.exit_button = new System.Windows.Forms.Button();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.SuspendLayout();
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(722, 13);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(75, 23);
            this.exit_button.TabIndex = 0;
            this.exit_button.Text = "Exit";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.exit_button);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Button students_button;
        private System.Windows.Forms.Button schedule_button;
        private System.Windows.Forms.Button groups_button;
        private System.Windows.Forms.Button users_button;
        private System.Windows.Forms.Button exircise_button;
        private System.Windows.Forms.Button user_schedule_button;
        private System.Windows.Forms.Button user_groups_button;
    }
}