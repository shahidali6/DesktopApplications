using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeSnippetCSharp
{
    class MySQL
    {
        #region Properties connections
        public static string connectionString { get; set; } = "Server=127.0.0.1; Port=3306;Database=ci4041b;Uid=root;Pwd=''";
        public static string exceptionString1 { get; set; } = string.Empty;
        public static string exceptionString2 { get; set; } = string.Empty;
        public static bool connectionStatus { get; set; } = false;
        public static int exceptionNumber { get; set; } = -1;
        #endregion

        #region MySQL QUERIES
        public static string MySQLQuery { get; set; } = string.Empty;
        public List<string> returnedList = new List<string>();
        #endregion

        #region Connection Functions

        public static bool CheckDBConnection()
        {
            //List<ReturnStatus> DBStatus = new List<ReturnStatus>();
            bool isConnected = false;
            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                isConnected = true;

                connectionStatus = isConnected;
            }
            catch (ArgumentException a_ex)
            {
                exceptionString1 = "Message: " + a_ex;
            }
            catch (MySqlException ex)
            {
                exceptionString2 = "Message: " + ex;

                isConnected = false;
                connectionStatus = isConnected;
                exceptionNumber = ex.Number;
                switch (ex.Number)
                {
                    //http://dev.mysql.com/doc/refman/5.0/en/error-messages-server.html
                    case 1042: // Unable to connect to any of the specified MySQL hosts (Check Server,Port)
                        break;
                    case 0: // Access denied (Check DB name,username,password)
                        break;
                    default:
                        break;
                }
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return isConnected;
        }

        public static List<string> GetMySQLData(string columnName)
        {
            DataTable dTable = new DataTable();
            try
            {
                //Display query  
                //string Query = "select id,name from unityassetlink_real_filesize_test;";
                MySqlConnection MySQLConnection = new MySqlConnection(MySQL.connectionString);
                MySqlCommand MySQLCommand = new MySqlCommand(MySQLQuery, MySQLConnection);
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MySQLAdapter = new MySqlDataAdapter();
                MySQLAdapter.SelectCommand = MySQLCommand;

                MySQLAdapter.Fill(dTable);

                List<string> resultList = new List<string>();

                int loopCounter = 0;
                foreach (var item in dTable.Rows)
                {
                    //MessageBox.Show(dTable.Rows[loopCounter]["name"].ToString());
                    string resultttt = dTable.Rows[loopCounter][columnName].ToString();
                    //MessageBox.Show(resultttt);
                    resultList.Add(resultttt);
                    loopCounter++;
                }
                return resultList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        #endregion
    }
}
