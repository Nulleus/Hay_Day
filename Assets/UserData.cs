using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
    public int IDUser;
    public string Server;
    public string DataBase;
    public string UserName;
    public string UserPassword;
    public string ConnectionString;
    // Start is called before the first frame update
    void Start()
    {
        //Строка пдключения к БД
        ConnectionString = 
            "Server=" + Server + ";" + 
            "DataBase=" + DataBase + ";" + 
            "USER=" + UserName + ";" + 
            "PASSWORD=" + UserPassword + ";";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
