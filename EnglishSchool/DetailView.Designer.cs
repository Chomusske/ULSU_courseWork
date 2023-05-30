using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace EnglishSchool
{
    partial class DetailView
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
        private void InitializeComponent()
        {
            this.ControlBox = false;
            this.exit_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            //
            //exit_button
            //
            this.exit_button.Location = new System.Drawing.Point(Size.Width - 90, 10);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(60, 60);
            this.exit_button.TabIndex = 0;
            this.exit_button.Text = "Exit";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);

            this.Controls.Add(this.exit_button);
            this.Name = "DetailView";
            this.Text = "DetailView";
            this.ResumeLayout(false);
            //

        }

        #endregion
        private System.Windows.Forms.Button exit_button;
        //
        //student
        //
        private System.Windows.Forms.CheckBox allow_parent;
        private System.Windows.Forms.Button apply_changes;
        private System.Windows.Forms.Button delete_student;
        private System.Windows.Forms.Button add_ex_amount;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.TextBox first_name;
        private System.Windows.Forms.TextBox second_name;
        private System.Windows.Forms.TextBox last_name;
        private System.Windows.Forms.MaskedTextBox phone;
        private System.Windows.Forms.TextBox parent_first_name;
        private System.Windows.Forms.TextBox parent_second_name;
        private System.Windows.Forms.TextBox parent_last_name;
        private System.Windows.Forms.TextBox parent_workplace;
        private System.Windows.Forms.MaskedTextBox parent_phone;
        private System.Windows.Forms.TextBox ex_amount;
        private System.Windows.Forms.TextBox age;
        private System.Windows.Forms.TextBox spec;
        private System.Windows.Forms.TextBox start_date;
        //
        //
        private System.Windows.Forms.Label id_label;
        private System.Windows.Forms.Label first_name_label;
        private System.Windows.Forms.Label second_name_label;
        private System.Windows.Forms.Label last_name_label;
        private System.Windows.Forms.Label phone_label;
        private System.Windows.Forms.Label parent_info_label;
        private System.Windows.Forms.Label ex_amount_label;
        private System.Windows.Forms.Label age_label;
        private System.Windows.Forms.Label spec_label;
        private System.Windows.Forms.Label start_date_label;
        //
        //
        private System.Windows.Forms.TextBox id_ch;
        private System.Windows.Forms.TextBox first_name_ch;
        private System.Windows.Forms.TextBox second_name_ch;
        private System.Windows.Forms.TextBox last_name_ch;
        private System.Windows.Forms.MaskedTextBox phone_ch;
        private System.Windows.Forms.TextBox parent_first_name_ch;
        private System.Windows.Forms.TextBox parent_second_name_ch;
        private System.Windows.Forms.TextBox parent_last_name_ch;
        private System.Windows.Forms.TextBox parent_workplace_ch;
        private System.Windows.Forms.MaskedTextBox parent_phone_ch;
        private System.Windows.Forms.TextBox ex_amount_ch;
        private System.Windows.Forms.TextBox age_ch;
        private System.Windows.Forms.TextBox spec_ch;
        private System.Windows.Forms.MaskedTextBox start_date_ch;
        //
        //
        private System.Windows.Forms.Label id_label_ch;
        private System.Windows.Forms.Label first_name_label_ch;
        private System.Windows.Forms.Label second_name_label_ch;
        private System.Windows.Forms.Label last_name_label_ch;
        private System.Windows.Forms.Label phone_label_ch;
        private System.Windows.Forms.Label parent_info_label_ch;
        private System.Windows.Forms.Label ex_amount_label_ch;
        private System.Windows.Forms.Label age_label_ch;
        private System.Windows.Forms.Label spec_label_ch;
        private System.Windows.Forms.Label start_date_label_ch;
        //
        //Schedule
        private System.Windows.Forms.Button cansel_button;
        private System.Windows.Forms.DataGridView grid_view;
        private System.Windows.Forms.DataGridView grid_view_2;
        private System.Windows.Forms.GroupBox change_elemtens;
        private System.Windows.Forms.ComboBox teacher_picker;
        private System.Windows.Forms.ComboBox group_picker;
        private System.Windows.Forms.ComboBox day_picker_1;
        private System.Windows.Forms.ComboBox day_picker_2;
        private System.Windows.Forms.DateTimePicker period_picker_11;
        private System.Windows.Forms.DateTimePicker period_picker_12;
        private System.Windows.Forms.DateTimePicker time_picker_11;
        private System.Windows.Forms.DateTimePicker time_picker_12;
        private System.Windows.Forms.DateTimePicker time_picker_21;
        private System.Windows.Forms.DateTimePicker time_picker_22;
    }
}