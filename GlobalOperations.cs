using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Lafarge_WPF
{
    class GlobalOperations
    {

        // this function is used to insert data into vehicle table in our database;
        // it inserts vehicle code, vehicle type and batch plant to the database
        public static void Insert_into_vehicle(string v_c, string v_t, string b_p)
        {


            GlobalClass.con.Open();
            string command_insert = "INSERT INTO vehicle (vehicle_code, vehicle_type, batch_plant) VALUES ('" + v_c + "', '" + v_t + "', '" + b_p + "');";
            MySqlCommand sql_cmd = new MySqlCommand(command_insert, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();
            GlobalClass.con.Close();


        }

        // this function is used to insert data into vehicle property table in our database;
        // it inserts vehicle code that is foreign key, working hour and the date for the inserted working hour
        public static void Insert_into_vehicle_property(string v_c, double w_h, DateTime p_d)
        {


            GlobalClass.con.Open();
            string format = "yyyy-MM-dd";    // modify the format depending upon input required in the column in database 
            string command_insert = "INSERT INTO vehicle_property (vehicle_code, working_hour, property_date) VALUES ('" + v_c + "', " + w_h + ", '" + p_d.ToString(format) + "');";
            MySqlCommand sql_cmd = new MySqlCommand(command_insert, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();
            GlobalClass.con.Close();


        }


        // this function is used to insert data into vehicle check table in our database;
        // it inserts data into all columns for that particular table.
        public static void Insert_into_vehicle_check(int ch_i, bool ch_r, string ch_n, string ch_note, string v_c, DateTime s_d)
        {


            GlobalClass.con.Open();
            string format = "yyyy-MM-dd";    // modify the format depending upon input required in the column in database 
            string command_insert = "INSERT INTO vehicle_check (check_index, check_result, check_name, check_note, vehicle_code, submit_date) VALUES (" + ch_i + ", " + ch_r + ", '" + ch_n + "', '" + ch_note + "', '" + v_c + "',  '" + s_d.ToString(format) + "');";
            MySqlCommand sql_cmd = new MySqlCommand(command_insert, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();
            GlobalClass.con.Close();


        }



        // this function is used to insert data into weeekly reports table in our database;
        // it inserts data into all columns for that particular table.
        public static void Insert_into_weekly_reports(int w_i, string v_c, string w_note, DateTime s_d)
        {


            GlobalClass.con.Open();
            string format = "yyyy-MM-dd";    // modify the format depending upon input required in the column in database 
            string command_insert = "INSERT INTO weekly_reports (weekly_index, vehicle_code, weekly_note, weekly_Date) VALUES (" + w_i + ", '" + v_c + "', '" + w_note + "', '" + s_d.ToString(format) + "');";
            MySqlCommand sql_cmd = new MySqlCommand(command_insert, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();
            GlobalClass.con.Close();


        }



        // this function is used to insert data into weekly checks sub table in our database;
        // it inserts data into all columns for that particular table.
        public static void Insert_into_weekly_checks_sub(int ch_r_i, int w_i, int f_ch_rep)
        {


            GlobalClass.con.Open();
            string command_insert = "INSERT INTO weekly_checks_sub (check_rep_index, weekly_index, false_check_rep) VALUES (" + ch_r_i + ", " + w_i + ", " + f_ch_rep + ");";
            MySqlCommand sql_cmd = new MySqlCommand(command_insert, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();
            GlobalClass.con.Close();


        }


        // this function is used to insert data into weekly checks sub table in our database;
        // it inserts data into all columns for that particular table.
        public static void Insert_into_monthly_reports(string v_c, bool ten_d, char fifty_w, char threeh_m, double w_h, string r_s, DateTime r_m_y)
        {


            GlobalClass.con.Open();
            string format = "yyyy-MM-dd";    // modify the format depending upon input required in the column in database 
            string command_insert =
            "INSERT INTO monthly_reports (vehicle_code, 10hr_d, 50hr_w, 300hr_m, working_hours, report_status, report_mm_yyyy) VALUES ('" + v_c + "', " + ten_d + ", '" + fifty_w + "', '" + threeh_m + "', " + w_h + ", '" + r_s + "', '" + r_m_y.ToString(format) + "');";
            MySqlCommand sql_cmd = new MySqlCommand(command_insert, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();
            GlobalClass.con.Close();


        }


        // this returns the number of vehicles in the database.
        public static int num_of_vehicles()
        {
            GlobalClass.con.Open();
            //SELECT COUNT(*) FROM cities;
            string command_select = "SELECT COUNT(*) FROM vehicle;";
            MySqlCommand sql_cmd = new MySqlCommand(command_select, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();
            GlobalClass.sql_dr.Read();
            int num_of_v = GlobalClass.sql_dr.GetInt32(0);
            GlobalClass.con.Close();
            return num_of_v;
        }


        // this checks if the vehicle exists or not before inserting into vahicles table.
        public static bool doesVehicleExist(string v_c)
        {

            GlobalClass.con.Open();
            string command_select = "SELECT COUNT(*) FROM vehicle where vehicle_code = '" + v_c + "';";
            MySqlCommand sql_cmd = new MySqlCommand(command_select, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();
            GlobalClass.sql_dr.Read();
            int num_of_v = GlobalClass.sql_dr.GetInt32(0);



            GlobalClass.con.Close();

            if (num_of_v == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        // this function selects and returns the data in user_account table
        public static SelectAccount getAccountData(string u_n)
        {
            SelectAccount myAccount = new SelectAccount();

            GlobalClass.con.Open();
            string command_select = "SELECT username, full_name, user_email, phone_num, user_role FROM user_account where username = '" + u_n + "';";
            MySqlCommand sql_cmd = new MySqlCommand(command_select, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();

            while (GlobalClass.sql_dr.Read())
            {
                myAccount.accUsername = GlobalClass.sql_dr.GetString(0);
                myAccount.accFullName = GlobalClass.sql_dr.GetString(1);
                myAccount.accEmail = GlobalClass.sql_dr.GetString(2);
                myAccount.accPhoneNum = GlobalClass.sql_dr.GetString(3);
                myAccount.accUserRole = GlobalClass.sql_dr.GetString(4);

            }

            return myAccount;
        }


        // this function selects and returns data from vehicle table
        public static SelectVehicle getVehicleData(string v_c)
        {
            SelectVehicle myVehicle = new SelectVehicle();

            GlobalClass.con.Open();
            string command_select = "SELECT vehicle_code, vehicle_type, batch_plant FROM vehicle where vehicle_code = '" + v_c + "';";
            MySqlCommand sql_cmd = new MySqlCommand(command_select, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();

            while (GlobalClass.sql_dr.Read())
            {
                myVehicle.vehicle_code = GlobalClass.sql_dr.GetString(0);
                myVehicle.vehicle_type = GlobalClass.sql_dr.GetString(1);
                myVehicle.batch_plant = GlobalClass.sql_dr.GetString(2);

            }

            return myVehicle;
        }



        // this function is used to insert data into maintenance vehicle table in our database;
        // it inserts data into all columns for that particular table.
        public static void insert_maintenance_vehicle(string v_c, DateTime v_d)
        {

            GlobalClass.con.Open();
            string format = "yyyy-MM-dd";    // modify the format depending upon input required in the column in database 
            string command_insert =
            "INSERT INTO maintenance_vehicle (vehicle_code, maintenance_date) VALUES ('" + v_c + "',   '" + v_d.ToString(format) + "');";
            MySqlCommand sql_cmd = new MySqlCommand(command_insert, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();
            GlobalClass.con.Close();

        }


        public static SelectMaintenanceVehicle getMaintenanceVehicleData(string v_c)
        {

            SelectMaintenanceVehicle myVehicle = new SelectMaintenanceVehicle();

            GlobalClass.con.Open();
            string command_select = "SELECT vehicle_code, maintenance_date FROM vehicle where vehicle_code = '" + v_c + "';";
            MySqlCommand sql_cmd = new MySqlCommand(command_select, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();

            while (GlobalClass.sql_dr.Read())
            {
                myVehicle.vehicle_code = GlobalClass.sql_dr.GetString(0);
                myVehicle.maintenance_date = GlobalClass.sql_dr.GetDateTime(1);
                

            }

            return myVehicle;

        }



    }


}
