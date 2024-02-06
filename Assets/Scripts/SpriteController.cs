using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class SpriteController : MonoBehaviour
{
    public GameObject Data;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SpriteController" + gameObject.name);
    }
    void ClearSprite()
    {
        if (gameObject.GetComponent<SpriteRenderer>() != null && Data.GetComponent<ImageStorage>() != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Data.GetComponent<ImageStorage>().GetSprite("empty");
        }
        if (gameObject.GetComponent<Image>() != null && Data.GetComponent<ImageStorage>() != null)
        {
            gameObject.GetComponent<Image>().sprite = Data.GetComponent<ImageStorage>().GetSprite("empty");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetSprite(string subjectName)
    {
        //Debug.Log("SetSprite(" + subjectName + ")");
        //Если компонент присутствует
        if (gameObject.GetComponent<SpriteRenderer>() != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = GetSprite(subjectName);
        }
        if (gameObject.GetComponent<Image>() != null)
        {
            gameObject.GetComponent<Image>().sprite = GetSprite(subjectName);
        }
        //Anim.CrossFade(subjectName, 0);
    }
    public Sprite GetSprite(string spriteName)
    {
        if (Data.GetComponent<ImageStorage>() != null)
        {
            return Data.GetComponent<ImageStorage>().GetSprite(spriteName);
        }
        return null;
    }
}
