using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class experience_point_ui_experience_point_text : MonoBehaviour
{
    public GameObject GO_experience_point_ui_fill_1;
    public int size_fill = 600;
    // Start is called before the first frame update
    void Start()
    {
        GO_experience_point_ui_fill_1 = GameObject.Find("experience_point_ui_fill_1");
        
        GO_experience_point_ui_fill_1.GetComponent<RectTransform>().offsetMax = new Vector2(-15, GO_experience_point_ui_fill_1.GetComponent<RectTransform>().offsetMax.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (globals.user_experience_point < globals.level_1_experience_point_threshold)
        {
            //GO_experience_point_ui_fill_1.GetComponent<RectTransform>().offsetMax = new Vector2(-()), GO_experience_point_ui_fill_1.GetComponent<RectTransform>().offsetMax.y);
            //Debug.Log("600-((600 / globals.level_1_experience_point_threshold)*globals.user_experience_point=" + (600 - ((600 / globals.level_1_experience_point_threshold) * globals.user_experience_point)));
            GO_experience_point_ui_fill_1.GetComponent<RectTransform>().SetRight(size_fill - ((size_fill / globals.level_1_experience_point_threshold) * globals.user_experience_point));
            gameObject.GetComponent<Text>().text = (globals.user_experience_point).ToString()+"/"+(globals.level_1_experience_point_threshold).ToString();
        }
        if (globals.user_experience_point >= globals.level_1_experience_point_threshold)//Если количество очков превышает порог первого уровня
        {
            globals.user_level = 2;//Уровень
            GO_experience_point_ui_fill_1.GetComponent<RectTransform>().SetRight(size_fill - ((size_fill / globals.level_2_experience_point_threshold) * globals.user_experience_point));//Шкала заливки
            gameObject.GetComponent<Text>().text = (globals.user_experience_point).ToString() + "/" + (globals.level_2_experience_point_threshold - globals.level_1_experience_point_threshold).ToString();
        }
        if (globals.user_experience_point >= globals.level_2_experience_point_threshold)//Если третий уровень
        {
            globals.user_level = 3;
            GO_experience_point_ui_fill_1.GetComponent<RectTransform>().SetRight(size_fill - ((size_fill / globals.level_3_experience_point_threshold) * globals.user_experience_point));//Шкала заливки
            gameObject.GetComponent<Text>().text = (globals.user_experience_point).ToString() + "/" + (globals.level_3_experience_point_threshold - globals.level_2_experience_point_threshold).ToString();
        }
        if (globals.user_experience_point >= globals.level_3_experience_point_threshold)//Если третий уровень
        {
            globals.user_level = 4;
        }
        if (globals.user_experience_point >= globals.level_4_experience_point_threshold)//Если третий уровень
        {
            globals.user_level = 5;
        }
        if (globals.user_experience_point >= globals.level_5_experience_point_threshold)//Если третий уровень
        {
            globals.user_level = 6;
        }
        if (globals.user_experience_point >= globals.level_6_experience_point_threshold)//Если третий уровень
        {
            globals.user_level = 7;
        }
        if (globals.user_experience_point >= globals.level_7_experience_point_threshold)//Если третий уровень
        {
            globals.user_level = 8;
        }
        if (globals.user_experience_point >= globals.level_8_experience_point_threshold)//Если третий уровень
        {
            globals.user_level = 9;
        }
        if (globals.user_experience_point >= globals.level_9_experience_point_threshold)//Если третий уровень
        {
            globals.user_level = 10;
        }
        if (globals.user_experience_point >= globals.level_10_experience_point_threshold)//Если третий уровень
        {
            globals.user_level = 11;
        }
        if (globals.user_experience_point >= globals.level_11_experience_point_threshold)//Если третий уровень
        {
            globals.user_level = 12;
        }
        if (globals.user_experience_point >= globals.level_12_experience_point_threshold)//Если третий уровень
        {
            globals.user_level = 13;
        }
        if (globals.user_experience_point >= globals.level_13_experience_point_threshold)//Если третий уровень
        {
            globals.user_level = 14;
        }
        if (globals.user_experience_point >= globals.level_14_experience_point_threshold)//Если третий уровень
        {
            globals.user_level = 15;
        }
        
    }
}
