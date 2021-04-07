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
        public string vehicle_code;
        public string vehicle_type;
        public string batch_plant;

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

    class SelectMaintenanceVehicle
    {
        public string maintenance_id;
        public string vehicle_code;
        public string Check_type;
        public string vehicle_status;
        public DateTime maintenance_date;
    }


}
