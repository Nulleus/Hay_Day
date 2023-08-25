using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using System.Data;

public class predmet_farm : MonoBehaviour
{
    public string name_predmet;//Имя предмета
    public int c_p_max;//Максимальное число монет за одну единицу
    public int building_time;//Время посторойки 
    public int ep;//Очков опыта за единицу
    // Start is called before the first frame update
    void Start()
    {
        //SQL_Data_Predmet();//Загрузка свойств в объект из БД
        //Загрузить свойства во все объекты предметы
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SQL_Data_Predmet()
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
                string sql = "select C_P_MAX, BUILDING_TIME, EP from TBL_OBJECTS WHERE OBJECT='" + gameObject.name + "'";
                Debug.Log(gameObject.name);
                dbcmd.CommandText = sql;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        c_p_max = (int)reader["C_P_MAX"];
                        building_time = (int)reader["BUILDING_TIME"];
                        ep = (int)reader["EP"];
                        Debug.Log("c_p_max:"+ c_p_max);
                        Debug.Log("building_time:" + building_time);
                        Debug.Log("ep:" + ep);
                    }
                }
            }
        }
    }
}
