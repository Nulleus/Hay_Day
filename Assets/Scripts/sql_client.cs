using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using System.Data;


using System.Text;

public class sql_client : MonoBehaviour {
    public void SQL_Data_ID()
    {
        //Connection string
        SqlConnection connstr = new SqlConnection();
        string connectionString = "Server = 127.0.0.1; Database = Farm_DB; User ID = farm_test; Password = z173500SS";
        IDbConnection dbcon;
        using (dbcon = new SqlConnection(connectionString))
        {
            dbcon.Open();
            using (IDbCommand dbcmd = dbcon.CreateCommand())
            {
                string sql = "select ID from TBL_USERS WHERE LOGIN='"+globals.login_users+"' AND PASWORD='"+globals.password_users+"'";
                dbcmd.CommandText = sql;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        globals.id_user = (int)reader["ID"];
                        //string LastName = (string)reader["lname"];
                        Debug.Log("ID: " + globals.id_user);
                    }
                }
            }
        }
    }

    
    // Use this for initialization
    void Start () {

    }
    // Update is called once per frame
    void Update()
    {

    }
}
	


