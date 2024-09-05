using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class LightsController : MonoBehaviour
{
    public GameObject[] Light;
    private IEnumerator coroutine;
    //Анимация элемента по номеру
    private int number;
    //Скорость анимации
    private float speedAnimation = 0.5f;
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void StartAnimation()
    {
        number = 0;
        coroutine = WaitAndPrint(speedAnimation);
        StartCoroutine(coroutine);
    }
    // yield is causing WaitAndPrint to pause every 3 seconds
    public IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            //print("WaitAndPrint " + Time.time);
            Light[0].GetComponent<SpriteController>().SetSprite("lightOffRedLeft");
            Light[1].GetComponent<SpriteController>().SetSprite("lightOffYellowLeft");
            Light[2].GetComponent<SpriteController>().SetSprite("lightOffYellowRight");
            Light[3].GetComponent<SpriteController>().SetSprite("lightOffRedRight");
            switch (number)
            {
                case 0:
                    Light[0].GetComponent<SpriteController>().SetSprite("lightOnRedLeft");
                    break;
                case 1:
                    Light[1].GetComponent<SpriteController>().SetSprite("lightOnYellowLeft");
                    break;
                case 2:
                    Light[2].GetComponent<SpriteController>().SetSprite("lightOnYellowRight");
                    break;
                case 3:
                    Light[3].GetComponent<SpriteController>().SetSprite("lightOnRedRight");
                    break;
                default:
                    number = 0;
                    Light[0].GetComponent<SpriteController>().SetSprite("lightOnRedLeft");
                    break;
            }
            number++;
            //Номер анимированного объекта
        }
    }
    public void StopAnimation()
    {
        StopCoroutine(coroutine);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartAnimation();
    }
    private void OnDisable()
    {
        StopAnimation();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
