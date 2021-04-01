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

        public string property_date;

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

#pragma warning disable CS0649 // Field 'SelectWeeklyReports.weekly_index' is never assigned to, and will always have its default value 0
        public int weekly_index;
#pragma warning restore CS0649 // Field 'SelectWeeklyReports.weekly_index' is never assigned to, and will always have its default value 0
#pragma warning disable CS0649 // Field 'SelectWeeklyReports.vehicle_code' is never assigned to, and will always have its default value null
        public string vehicle_code;
#pragma warning restore CS0649 // Field 'SelectWeeklyReports.vehicle_code' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'SelectWeeklyReports.weekly_note' is never assigned to, and will always have its default value null
        public string weekly_note;
#pragma warning restore CS0649 // Field 'SelectWeeklyReports.weekly_note' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'SelectWeeklyReports.weekly_Date' is never assigned to, and will always have its default value null
        public string weekly_Date;
#pragma warning restore CS0649 // Field 'SelectWeeklyReports.weekly_Date' is never assigned to, and will always have its default value null

    }


    class SelectWeeklyChecksSub
    {

#pragma warning disable CS0649 // Field 'SelectWeeklyChecksSub.check_rep_index' is never assigned to, and will always have its default value 0
        public int check_rep_index;
#pragma warning restore CS0649 // Field 'SelectWeeklyChecksSub.check_rep_index' is never assigned to, and will always have its default value 0
#pragma warning disable CS0649 // Field 'SelectWeeklyChecksSub.weekly_index' is never assigned to, and will always have its default value 0
        public int weekly_index;
#pragma warning restore CS0649 // Field 'SelectWeeklyChecksSub.weekly_index' is never assigned to, and will always have its default value 0
#pragma warning disable CS0649 // Field 'SelectWeeklyChecksSub.false_check_rep' is never assigned to, and will always have its default value 0
        public int false_check_rep;
#pragma warning restore CS0649 // Field 'SelectWeeklyChecksSub.false_check_rep' is never assigned to, and will always have its default value 0

    }


    class SelectMonthlyReports
    {

#pragma warning disable CS0649 // Field 'SelectMonthlyReports.vehicle_code' is never assigned to, and will always have its default value null
        public string vehicle_code;
#pragma warning restore CS0649 // Field 'SelectMonthlyReports.vehicle_code' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'SelectMonthlyReports.ten_d' is never assigned to, and will always have its default value false
        public bool ten_d;
#pragma warning restore CS0649 // Field 'SelectMonthlyReports.ten_d' is never assigned to, and will always have its default value false
#pragma warning disable CS0649 // Field 'SelectMonthlyReports.fifty_hr_w' is never assigned to, and will always have its default value
        public char fifty_hr_w;
#pragma warning restore CS0649 // Field 'SelectMonthlyReports.fifty_hr_w' is never assigned to, and will always have its default value
#pragma warning disable CS0649 // Field 'SelectMonthlyReports.three_hr_m' is never assigned to, and will always have its default value
        public char three_hr_m;
#pragma warning restore CS0649 // Field 'SelectMonthlyReports.three_hr_m' is never assigned to, and will always have its default value
#pragma warning disable CS0649 // Field 'SelectMonthlyReports.working_hours' is never assigned to, and will always have its default value 0
        public double working_hours;
#pragma warning restore CS0649 // Field 'SelectMonthlyReports.working_hours' is never assigned to, and will always have its default value 0
#pragma warning disable CS0649 // Field 'SelectMonthlyReports.report_status' is never assigned to, and will always have its default value null
        public string report_status;
#pragma warning restore CS0649 // Field 'SelectMonthlyReports.report_status' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'SelectMonthlyReports.report_mm_yyyy' is never assigned to, and will always have its default value null
        public string report_mm_yyyy;
#pragma warning restore CS0649 // Field 'SelectMonthlyReports.report_mm_yyyy' is never assigned to, and will always have its default value null

    }

    class SelectMaintenanceVehicle
    {
        public string vehicle_code;
        public DateTime maintenance_date;
    }


}
