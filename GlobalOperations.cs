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
        public static void Insert_into_vehicle_property(string v_c, double w_h, double wh_50h, double wh_300h, DateTime p_d)
        {


            GlobalClass.con.Open();
            string format = "yyyy-MM-dd HH:mm:ss";    // modify the format depending upon input required in the column in database  "yyyy-MM-dd HH:mm:ss"
            string command_insert = "INSERT INTO vehicle_property (vehicle_code, working_hour, wh_50h, wh_300h, property_date) VALUES ('" + v_c + "', " + w_h + ", "+ wh_50h +", "+ wh_300h +", '" + p_d.ToString(format) + "');";
            MySqlCommand sql_cmd = new MySqlCommand(command_insert, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();
            GlobalClass.con.Close();


        }


        // this function is used to insert data into vehicle check table in our database;
        // it inserts data into all columns for that particular table.
        public static void Insert_into_vehicle_check(int ch_id, int ch_i, bool ch_r, string ch_note, string v_c, DateTime s_d)
        {


            GlobalClass.con.Open();
            string format = "yyyy-MM-dd HH:mm:ss";    // modify the format depending upon input required in the column in database 
            string command_insert = "INSERT INTO vehicle_check (check_id, check_index, check_result, check_note, vehicle_code, submit_date) VALUES ( "+ ch_id +"  " + ch_i + ", " + ch_r + ", '" + ch_note + "', '" + v_c + "',  '" + s_d.ToString(format) + "');";
            MySqlCommand sql_cmd = new MySqlCommand(command_insert, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();
            GlobalClass.con.Close();


        }



        // this function is used to insert data into weeekly reports table in our database;
        // it inserts data into all columns for that particular table.
        public static void Insert_into_weekly_reports(int w_i, string v_c, string w_note, DateTime s_d)
        {


            GlobalClass.con.Open();
            string format = "yyyy-MM-dd HH:mm:ss";    // modify the format depending upon input required in the column in database 
            string command_insert = "INSERT INTO weekly_reports (weekly_index, vehicle_code, weekly_note, weekly_Date) VALUES (" + w_i + ", '" + v_c + "', '" + w_note + "', '" + s_d.ToString(format) + "');";
            MySqlCommand sql_cmd = new MySqlCommand(command_insert, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();
            GlobalClass.con.Close();


        }



        // this function is used to insert data into weekly checks sub table in our database;
        // it inserts data into all columns for that particular table.
        public static void Insert_into_weekly_checks_sub(string v_c, int ch_r_i, int w_i, int f_ch_rep, DateTime sub_date)
        {

            string format = "yyyy-MM-dd HH:mm:ss";
            GlobalClass.con.Open();
            
            string command_insert = "INSERT INTO weekly_checks_sub ( vehicle_code ,check_rep_index, weekly_index, false_check_rep, check_rep_date) VALUES ( '"+ v_c +"', " + ch_r_i + ", " + w_i + ", " + f_ch_rep + ",  '"+ sub_date.ToString(format) +"' );";
            MySqlCommand sql_cmd = new MySqlCommand(command_insert, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();
            GlobalClass.con.Close();


        }


        // this function is used to insert data into weekly checks sub table in our database;
        // it inserts data into all columns for that particular table.
        public static void Insert_into_monthly_reports(string v_c, bool ten_d, char fifty_w, char threeh_m, double w_h, string r_s, DateTime r_m_y)
        {


            GlobalClass.con.Open();
            string format = "yyyy-MM-dd HH:mm:ss";    // modify the format depending upon input required in the column in database 
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
            GlobalClass.con.Close();

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
        public static void insert_maintenance_vehicle( string v_c, int w_i, string ch_t, string v_s, DateTime v_d)
        {

            GlobalClass.con.Open();
            string format = "yyyy-MM-dd HH:mm:ss";    // modify the format depending upon input required in the column in database 
            string command_insert =
            "INSERT INTO maintenance_vehicle (vehicle_code, weekly_index, Check_type, vehicle_status, maintenance_date) VALUES " +
            " ('" + v_c + "',  "+ w_i +", '"+ ch_t +"', '"+ v_s +"', '" + v_d.ToString(format) + "');";
            MySqlCommand sql_cmd = new MySqlCommand(command_insert, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();
            GlobalClass.con.Close();


        }


        public static SelectMaintenanceVehicle getMaintenanceVehicleData(string v_c)
        {

            SelectMaintenanceVehicle myVehicle = new SelectMaintenanceVehicle();

            GlobalClass.con.Open();
            string command_select = "SELECT vehicle_code, vehicle_status, maintenance_date FROM vehicle where vehicle_code = '" + v_c + "';";
            MySqlCommand sql_cmd = new MySqlCommand(command_select, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();

            while (GlobalClass.sql_dr.Read())
            {
                myVehicle.vehicle_code = GlobalClass.sql_dr.GetString(0);
                myVehicle.vehicle_status = GlobalClass.sql_dr.GetString(1);
                myVehicle.maintenance_date = GlobalClass.sql_dr.GetDateTime(2);
                
            }

            return myVehicle;

        }

        public static SelectVehicleProperty getVehicleProperty(string v_c)
        {



            SelectVehicleProperty myVehicleProperty = new SelectVehicleProperty();

            GlobalClass.con.Open();
            string command_select = "SELECT a.vehicle_code, a.working_hour, a.wh_50h, a.wh_300h, a.property_date FROM vehicle_property as a"
                + " where a.vehicle_code = '"+ v_c + "' and  a.property_date = "
                + "( select max(b.property_date) from vehicle_property as b where a.vehicle_code = b.vehicle_code ); ";
            MySqlCommand sql_cmd = new MySqlCommand(command_select, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();

            while (GlobalClass.sql_dr.Read())
            {
                myVehicleProperty.vehicle_code = GlobalClass.sql_dr.GetString(0);
                myVehicleProperty.working_hour = GlobalClass.sql_dr.GetDouble(1);
                myVehicleProperty.wh_50h = GlobalClass.sql_dr.GetDouble(2);
                myVehicleProperty.wh_300h = GlobalClass.sql_dr.GetDouble(3);
                myVehicleProperty.property_date = GlobalClass.sql_dr.GetDateTime(4);

            }

            GlobalClass.con.Close();

            return myVehicleProperty;

        }

        public static int GetIndexNumber_v_ch()
        {
            GlobalClass.con.Open();
            string command_select = "SELECT COUNT(*) FROM vehicle_check;";
            MySqlCommand sql_cmd = new MySqlCommand(command_select, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();
            GlobalClass.sql_dr.Read();
            int index_num = GlobalClass.sql_dr.GetInt32(0);
            GlobalClass.con.Close();
            return index_num;

        }


        public static int GetIndexNumber_w_r()
        {
            GlobalClass.con.Open();
            string command_select = "SELECT COUNT(*) FROM weekly_reports;";
            MySqlCommand sql_cmd = new MySqlCommand(command_select, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();
            GlobalClass.sql_dr.Read();
            int index_num = GlobalClass.sql_dr.GetInt32(0);
            GlobalClass.con.Close();
            return index_num;

        }


        public static int GetLastNumber_w_r(string v_c)
        {
            GlobalClass.con.Open();
            string command_select = " SELECT a.weekly_index FROM weekly_reports as a where a.vehicle_code = '" + v_c + "' " +
                                    " and a.weekly_Date = (select max(b.weekly_Date) from weekly_reports as b) " +
                                    " order by weekly_index desc limit 1; ";

            MySqlCommand sql_cmd = new MySqlCommand(command_select, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();
            GlobalClass.sql_dr.Read();
            int index_num = GlobalClass.sql_dr.GetInt32(0);
            GlobalClass.con.Close();
            return index_num;

        }



        // according to max date
        // also according to weekly index and check rep index, 
        // so it means according to 3 parameters
        public static int getLastFalseCheck(int ch_r_i, int w_i, string v_c)
        {

            GlobalClass.con.Open();


            string command_select = "select a.false_check_rep from weekly_checks_sub as a where "
                + " a.check_rep_index = "+ ch_r_i + " and a.weekly_index = " + w_i +
                " and a.vehicle_code = '" + v_c + "' " +
                " order by a.check_rep_date desc " + 
                " limit 1; ";


            MySqlCommand sql_cmd = new MySqlCommand(command_select, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();
            GlobalClass.sql_dr.Read();
            int lastFalse = GlobalClass.sql_dr.GetInt32(0);

            GlobalClass.con.Close();

            return lastFalse;
        }


        // this returns the last week for such vehicle
        public static int getLastWeeklyIndex(string v_c, int new_w_i)
        {

            GlobalClass.con.Open();

            /*
             select a.weekly_index from weekly_reports as a where
                             weekly_index < 2
                             and a.vehicle_code = 'M62'
                             order by weekly_index desc
                             limit 1;
             */

            string command_select = "select a.weekly_index from weekly_reports as a where" +
                " weekly_index < "+ new_w_i +" " +
                " and a.vehicle_code = '"+ v_c +"' " +
                " order by weekly_index desc  " +
                " limit 1;  "  ;

            MySqlCommand sql_cmd = new MySqlCommand(command_select, GlobalClass.con);
            GlobalClass.sql_dr = sql_cmd.ExecuteReader();
            GlobalClass.sql_dr.Read();
            int lastFalse = GlobalClass.sql_dr.GetInt32(0);

            GlobalClass.con.Close();

            return lastFalse;
        }





    }

                                                                // 'YYYY-MM-DD hh:mm:ss'
}
