using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;


namespace Lafarge_WPF
{
    class GlobalClass
    {
        public GlobalClass()
        {

            // constructor
            // nice
        }


        public static string EncryptDecrypt(string szPlainText, int szEncryptionKey)
        {

            StringBuilder szInputStringBuild = new StringBuilder(szPlainText);
            StringBuilder szOutStringBuild = new StringBuilder(szPlainText.Length);
            char Textch;
            for (int iCount = 0; iCount < szPlainText.Length; iCount++)
            {
                Textch = szInputStringBuild[iCount];
                Textch = (char)(Textch ^ szEncryptionKey);
                szOutStringBuild.Append(Textch);
            }
            return szOutStringBuild.ToString();

        }

        public static void readFromFile()
        {

            string[] line = new string[5];
            string[] unencted = new string[5];

            try
            {
                StreamReader sr = new StreamReader("/WriteFile/writefile.txt");

                for (int i = 0; i < 5; i++)
                    line[i] = sr.ReadLine();

                Account_username = line[3];
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            for (int i = 0; i < 5; i++)
            {
                unencted[i] = EncryptDecrypt(line[i], 200);
            }

            con_str = "Server=" + unencted[0] + "; Port=" + unencted[1] + "; Database=" + unencted[2] + "; Uid=" + unencted[3] + "; Pwd=" + unencted[4] + "";


        }


        public static void setCon()
        {

            readFromFile();
            con = new MySqlConnection(con_str);
            Account_username = "";
            login_status = false;

        }




        public static String con_str;
        public static MySqlConnection con;
        public static MySqlDataReader sql_dr;
        public static bool login_status;

        public static String Account_username;





    }
}
