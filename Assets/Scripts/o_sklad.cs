using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data.SqlClient;
using System.Data;

public class o_sklad : MonoBehaviour //Временный склад, где хранятся готовые объекты, но ещё не перемещенные на основной склад
{
    public string obj;
    public string predmet;
    public DateTime plane_at;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        globals.id_user = 1;//Авторизоваться по первому пользователю
        i = 0;
        SQL_Data_O_Sklad();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SQL_Data_O_Sklad()//Загрузка данных о Поле
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
                string sql = "select PREDMET, PLANE_AT from TBL_O_SKLAD WHERE USER_ID='" + globals.id_user + "' AND OBJECT='" + gameObject.name + "'";
                Debug.Log(gameObject.name);
                dbcmd.CommandText = sql;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        //Тут распределение объектов по слотам
                        i++;



                        //Получаем 
                        obj = gameObject.name;
                        predmet = (string)reader["PREDMET"];
                        plane_at = (DateTime)reader["PLANE_AT"];
                        //if Текущее время => PLANE_AT {тогда загружаем всё это в слоты с готовой продукцией}
                        //if Текущее время <= PLANE_AT {тогда загружаем всё это в слоты с производящейся продукцией}
                        //gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Levels/farm1/" + predmet +"/" +predmet);
                        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("bread");
                        //Тут произвести проверку и загрузку в объекты
                        Debug.Log("obj:" + obj);
                        Debug.Log("predmet:" + predmet);
                        Debug.Log("plane_at:" + plane_at);
                    }


                }
            }
        }
    }
}
