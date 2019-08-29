using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using System.Data;

public class production_building_farm : MonoBehaviour
{
    public int one_star_time;
    public int two_star_time;
    public int three_star_time;
    public int one_star_mastering;
    public int two_star_mastering;
    public int three_star_mastering;
    public int slots;
    public int coins_price;
    public int building_time;
    public int experience_point;
    public int open_lvl;
    // Start is called before the first frame update
    void Start()
    {
        //SQL_Data_PB();//Загрузка свойств в объект из БД
        //Загрузить свойства во все объекты оизводственных зданий
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SQL_Data_PB()
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
                string sql = "select ONE_STAR_TIME, TWO_STAR_TIME, THREE_STAR_TIME, ONE_STAR_MASTERING, TWO_STAR_MASTERING, THREE_STAR_MASTERING, SLOTS, COINS_PRICE, BUILDING_TIME, EXPERIENCE_POINT, OPEN_LVL from TBL_PRODUCTION_BUIDINGS WHERE NAME_PRODUCTION_BUILDING='" + gameObject.name + "'";
                Debug.Log(gameObject.name);
                dbcmd.CommandText = sql;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        one_star_time = (int)reader["ONE_STAR_TIME"];
                        two_star_time = (int)reader["TWO_STAR_TIME"];
                        three_star_time = (int)reader["THREE_STAR_TIME"];
                        one_star_mastering = (int)reader["ONE_STAR_MASTERING"];
                        two_star_mastering = (int)reader["TWO_STAR_MASTERING"];
                        three_star_mastering = (int)reader["THREE_STAR_MASTERING"];
                        slots = (int)reader["SLOTS"];
                        coins_price = (int)reader["COINS_PRICE"];
                        building_time = (int)reader["BUILDING_TIME"];
                        experience_point = (int)reader["EXPERIENCE_POINT"];
                        open_lvl = (int)reader["OPEN_LVL"];

                        Debug.Log("one_star_time:" + one_star_time);
                        Debug.Log("two_star_time:" + two_star_time);
                        Debug.Log("three_star_time:" + three_star_time);
                        Debug.Log("one_star_mastering:" + one_star_mastering);
                        Debug.Log("two_star_mastering:" + two_star_mastering);
                        Debug.Log("three_star_mastering:" + three_star_mastering);
                        Debug.Log("slots:" + slots);
                        Debug.Log("coins_price:" + coins_price);
                        Debug.Log("building_time:" + building_time);
                        Debug.Log("experience_point:" + experience_point);
                        Debug.Log("open_lvl:" + open_lvl);
                    }
                }
            }
        }
    }

}
