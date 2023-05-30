using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EnglishSchool
{
    partial class LogicForm
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
        /// 
        private void InitializeComponent()
        {
        
            Screen currentScreen = Screen.FromRectangle(Bounds);
            this.exit_button = new System.Windows.Forms.Button();
            
            this.SuspendLayout();
            
            // 
            // LogicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Size = currentScreen.WorkingArea.Size;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ControlBox = false;

            
            this.exit_button.Location = new System.Drawing.Point(Size.Width-90, 10);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(60, 60);
            this.exit_button.TabIndex = 0;
            this.exit_button.Text = "Exit";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);

            
            this.Controls.Add(this.exit_button);
            this.Name = "";
            this.Text = "";
            this.ResumeLayout(false);
            

        }

        

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.DataGridView db_data;
        //
        private System.Windows.Forms.Button all_rows_button;
        private System.Windows.Forms.Button all_debt_students_button;
        private System.Windows.Forms.Button row_detail;
        private System.Windows.Forms.Button row_change;
        private System.Windows.Forms.Button row_add;
        private System.Windows.Forms.TextBox FIO_search;
        private System.Windows.Forms.DataGridView grid_view;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.DateTimePicker date_picker;

    }
}