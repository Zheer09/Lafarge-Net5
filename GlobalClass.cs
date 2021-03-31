using System;
using System.Text;
using MySql.Data.MySqlClient;
using System.IO;



namespace Lafarge_WPF
{


    class GlobalClass
    {


        public static String con_str;
        public static MySqlConnection con;
        public static MySqlDataReader sql_dr;
        public static bool login_status;

        public static String Account_username;


        public GlobalClass()
        {

            // constructor
            // nice
        }



        public static string EncryptDecrypt(string szPlainText, int szEncryptionKey)
        {
            if(szPlainText == "")
            {
                return "";
            }
            try
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
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }


            return "";
        }

        public static void readFromFile()
        {

            string[] line = new string[5];
            string[] unencted = new string[5];

      

                line[0] = "¼­»¼ùæ«°ð±¹¾ª­¸¸½¯æ½»å­©»¼åúæº¬»æ©¥©²§¦©¿»æ«§¥";
                line[1] = "ûûøþ";
                line[2] = "¤©®©º¯­";
                line[3] = "©¬¥¡¦";
                line[4] = "¹¿­º¼±½¡§¸";



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




     




    }
}
