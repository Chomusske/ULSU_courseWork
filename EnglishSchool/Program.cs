using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EnglishSchool
{
    internal static class Program
    {
        public static ApplicationContext Context { get; set; }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /// Строка длял подключения к бд
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "37.140.192.62";
            conn_string.UserID = "u2044278_mainuse";
            conn_string.Password = "sav20062002";
            conn_string.Database = "u2044278_englishschoolmain";
            conn_string.CharacterSet = "utf8mb4";
            MySqlConnection conn = new MySqlConnection(conn_string.ToString());
            MySqlCommand cmd = (MySqlCommand)conn.CreateCommand();
            ///
            try
            {    

                conn.Open();
                MessageBox.Show("Успешное подключение");

                conn.Close();
                Context = new ApplicationContext(new EnterForm(conn_string));
                Application.Run(Context);
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message);
                Application.Exit();
            }

        }
        public enum week_days
        {
            Понедельник = DayOfWeek.Monday,
            Вторник = DayOfWeek.Tuesday,
            Среда = DayOfWeek.Wednesday,
            Четверг = DayOfWeek.Thursday,
            Пятница = DayOfWeek.Friday,
            Суббота = DayOfWeek.Saturday,
        }
    }
}
