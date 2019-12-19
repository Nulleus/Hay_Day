using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldCreation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Создаем объект из пустого объекта
        GameObject clone = (GameObject)Instantiate(Resources.Load("Prefabs/" + "EmptyObject"), new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
        //Добавляем имя объекту
        clone.name = "bakery";
        Debug.Log("gameObject.name: " + gameObject.name);
        var rb2d = new Rigidbody2D();
        Debug.Log(System.Type.GetType("Rigidbody2D"));
        Type type = System.Type.GetType("Rigidbody2D");
        var foo = Activator.CreateInstance(type);
        Debug.Log(foo.GetType());
        //foo.GetType();
        //foo.GetType().GetMethod("bodyType").Invoke(foo, null);
        //foo = RigidbodyType2D.Static;
        //var foo = Activator.CreateInstance(type);
        //foo.GetType().GetMethod("bodyType").Invoke(foo, null);

        clone.AddComponent(foo.GetType());
        //clone.GetComponent(type).Get;
        //clone.GetComponent<Rigidbody2D>();

        //Rigidbody2D RB2D = new Rigidbody2D();
        //Loading(clone, RB2D);
        //Метод
        //Получаем спислк компонентов и создаем их
        //Component comp;
        //Добавляем свойства 
        //clone.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        //clone.GetComponents<ProductionBuildingController>().
        //productionBuilding.Name = "Пекарня";
        //productionBuilding.OpenLevel = 1;
        //productionBuilding.OpenSlots = 9;
        //productionBuilding.CoinPrice = 20;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Loading(GameObject clone, Component component)
    {

    }

}
