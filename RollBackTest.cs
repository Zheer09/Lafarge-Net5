using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Lafarge_WPF
{
    public class RollBackTest
    {

        public void testTransaction1(int onee)
        {
            MySqlTransaction tr = null;
            try
            {
                GlobalClass.con.Open();
                
                tr = GlobalClass.con.BeginTransaction();

                MySqlCommand CMD = new MySqlCommand();
                CMD.Connection = GlobalClass.con;
                CMD.Transaction = tr;

                CMD.CommandText = "insert into testt values (" + onee + ", " + (onee + 1) + "); ";
                CMD.ExecuteNonQuery();

                CMD.CommandText = "insert into testt vjkhghjfgfgaluess (" + onee + ", " + (onee + 1) + "); ";
                CMD.ExecuteNonQuery();


                tr.Commit();
            }catch(MySqlException ex)
            {
                tr.Rollback();
            }
            finally
            {
                GlobalClass.con.Close();
            }



        }


        public void RunTransaction(int x)
        {
            
            GlobalClass.con.Open();

            MySqlCommand myCommand = GlobalClass.con.CreateCommand();
            MySqlTransaction myTrans;

            // Start a local transaction
            myTrans = GlobalClass.con.BeginTransaction();
            // Must assign both transaction object and connection
            // to Command object for a pending local transaction
            myCommand.Connection = GlobalClass.con;
            myCommand.Transaction = myTrans;

            try
            {
                myCommand.CommandText = "insert into testt VALUES (100, 199)";
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = "insert into testt  VALUES (101s, 200d)";
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                Console.WriteLine("Both records are written to database.");
            }
            catch (Exception e)
            {
                try
                {
                    myTrans.Rollback();
                }
                catch (MySqlException ex)
                {
                    if (myTrans.Connection != null)
                    {
                        Console.WriteLine("An exception of type " + ex.GetType() +
                        " was encountered while attempting to roll back the transaction.");
                    }
                }

                Console.WriteLine("An exception of type " + e.GetType() +
                " was encountered while inserting the data.");
                Console.WriteLine("Neither record was written to database.");
            }
            finally
            {
                GlobalClass.con.Close();
            }
        }


    }
}
