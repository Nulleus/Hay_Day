using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterAuthorization : MonoBehaviour
{
    public GameObject FieldLogin; //Объект поле логина
    public GameObject FieldPassword; //Объект поле пароля
    public GameObject ConnectionData; //Объект подключения к базе данных    
    public GameObject TextFailedAuthorization;//Сообщение о неудачной авторизации
    private void OnMouseUp()//Когда отпускаеть мышь
    {
        globals.login_user = FieldLogin.GetComponent<Text>().text; //Получаем введенный логин пользователя
        globals.password_user = FieldPassword.GetComponent<InputField>().text; //Получаем введенный пароль пользователя
        gameObject.GetComponent<Users>().GetInfoUser();
    }
    public void Authorization(string stage)
    {
        switch (stage)
        {
            case "ok":
                TextFailedAuthorization.GetComponent<Text>().text = "Добро пожаловать";
                break;
            case "failed":
                TextFailedAuthorization.GetComponent<Text>().text = "Логин и(или) пароль неверны";
                break;
            default:
                TextFailedAuthorization.GetComponent<Text>().text = "Попробуйте позже";
                break;
        }
        
    }
    //Запускаем запрос с попыткой авторизации
    //В случае удачной авторизации
    //В случае неудачной авторизации
}
