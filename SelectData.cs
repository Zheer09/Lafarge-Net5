using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// I might use these classes to store retrieved data from database for each table temporarily
namespace Lafarge_WPF
{

    class SelectData
    {

        // nothing...

    }

    class SelectVehicle
    {
        public string vehicle_code { get; set; }
        public string vehicle_type { get; set; }
        public string batch_plant { get; set; }

    }

    class SelectAccount
    {
        public string accUsername;
        public string accFullName;
        public string accEmail;
        public string accPhoneNum;
        public string accUserRole;
    }

    class SelectVehicleProperty
    {

        public string vehicle_code;

        public double working_hour;

        public double wh_50h;

        public double wh_300h;

        public DateTime property_date;

    }

    //
    /*
    class SelectVehicleCheck
    {

        public int check_index;

        public bool check_result;

        public string check_name;

        public string check_note;

        public string vehicle_code;

        public string submit_date;

    }


    class SelectWeeklyReports
    {

        public int weekly_index;
        public string vehicle_code;
        public string weekly_note;
        public string weekly_Date;

    }


    class SelectWeeklyChecksSub
    {

        public int check_rep_index;
        public int weekly_index;
        public int false_check_rep;
        public string check_rep_date;

    }


    class SelectMonthlyReports
    {
        public string vehicle_code;
        public bool ten_d;
        public char fifty_hr_w;
        public char three_hr_m;
        public double working_hours;
        public string report_status;
        public string report_mm_yyyy;

    }

    */
    //
    class SelectMaintenanceVehicle
    {
        //public string maintenance_id;
        public string vehicle_code;
        public string Check_type;
        public string vehicle_status;
        public DateTime maintenance_date;
    }



    class WeeklyData
    {
        public string v_codee { get; set; }
        public int P1 { get; set; }
        public int P2 { get; set; }
        public int P3 { get; set; }
        public int P4 { get; set; }
        public int P5 { get; set; }
        public int P6 { get; set; }
        public int P7 { get; set; }
        public int P8 { get; set; }
        public int P9 { get; set; }
        public int P10 { get; set; }
        public int P11 { get; set; }
        public int P12 { get; set; }
        public int P13 { get; set; }
        public int P14 { get; set; }
        public int P15 { get; set; }
        public int P16 { get; set; }
        public string weeklyNote { get; set; }
    }

    class monthlyData
    {

        public int monthly_id { get; set; }
        public string asset { get; set; }
        public string vehicle_code { get; set; }
        public string hr50_w1 { get; set; }
        public string w1_status { get; set; }
        public string hr50_w2 { get; set; }
        public string w2_status { get; set; }
        public string hr50_w3 { get; set; }
        public string w3_status { get; set; }
        public string hr50_w4 { get; set; }
        public string w4_status { get; set; }
        public string hr300_m  { get; set; }
        public string monthly_status { get; set; }
        public float workingHours { get; set; }
        


    }

    /*monthly_id int primary key not null auto_increment,
        vehicle_code varchar(10) references vehicle(vehicle_code),
        50hr_w1 varchar(1),
        w1_status varchar(30),
        50hr_w2 varchar(1),
        w2_status varchar(30),
        50hr_w3 varchar(1),
        w3_status varchar(30),
        50hr_w4 varchar(1),
        w4_status varchar(30),
        300hr_m varchar(1),
        monthly_status varchar(30),
        workingHours float,
        monthly_date timestamp*/

}
