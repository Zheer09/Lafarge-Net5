using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Lafarge_WPF
{
    /// <summary>
    /// Interaction logic for ShowNotes.xaml
    /// </summary>
    public partial class ShowNotes : Window
    {

        public static string v_code;
        public static DateTime maintenance_last_date;
        public static List<int> shownIndex = new List<int>();

        public ShowNotes(string v, DateTime m_date, List<int> si  )
        {

            InitializeComponent();
            v_code = v;
            maintenance_last_date = m_date;
            shownIndex = si;
            refreshData();

        }

        void refreshData()
        {

            /*
             select * from vehicle_check as a
             where a.vehicle_code = 'L99' and a.check_index = 4 and a.submit_date >= 
             (select b.check_rep_date from weekly_checks_sub as b  where b.vehicle_code = 'L99' and b.check_rep_index = 4 and b.false_check_rep = 1   )
             and a.submit_date <= '2021-05-28';
             */
            List<NotesData> containedNotes = new List<NotesData>();
            string commandQuery = "";
            MySqlCommand sql_cmd;

            string[] checkName2 = {

                        "Check engine oil level", "Check hydraulic oil level",
                        "Check water level", "Check tires",
                        "Check lights", "Check seat belt",
                        "Chech front and back alarms", "Check fire extinguisher",
                        "Check mirrors", "Check windshield and its scrapers",
                        "Check brake", "Check legs movement, whole body and stairs, bucket.",
                        "Check all leakages", "Check batteries and charging",
                        "Check fuel level", "Check all booms movement, water tank, bucket cylinder jack"
                        
            };

     



            for (int i = 0; i < shownIndex.Count(); i++)
            {


                commandQuery = " select  a.check_note, a.submit_date from vehicle_check as a " +
                    " where a.vehicle_code = '" + v_code + "' and a.check_index = " + shownIndex[i] + " and a.submit_date >= " +
                    " (select b.check_rep_date from weekly_checks_sub as b  where b.vehicle_code = '" + v_code + "' and b.check_rep_index = " + shownIndex[i] + " and b.false_check_rep = 1   ) " +
                    " and a.submit_date <= '"+maintenance_last_date.ToString("yyyy-MM-dd") +"'; ";

                GlobalClass.con.Open();


                sql_cmd = new MySqlCommand(commandQuery, GlobalClass.con);
                GlobalClass.sql_dr = sql_cmd.ExecuteReader();

                while (GlobalClass.sql_dr.Read())
                {
                    containedNotes.Add(new NotesData()
                    {
                        // if checkIndex which is shownIndex[i] in here is any number you have to choose the problem name in an array string
                        checkName = checkName2[shownIndex[i]-1],
                        noteContent = GlobalClass.sql_dr.GetString(0),
                        noteDate = GlobalClass.sql_dr.GetDateTime(1).ToString("yyyy-MM-dd"),



                    });
                }


                containedNotes.Add(new NotesData()
                {
                    // if checkIndex which is shownIndex[i] in here is any number you have to choose the problem name in an array string
                    checkName = "  ",
                    noteContent = "  ",
                    noteDate = "  "


                }); ;

                GlobalClass.con.Close();



            }

            VC_label.Content = v_code;
             notes_dataGrid.ItemsSource = containedNotes;


        }



    }
}
