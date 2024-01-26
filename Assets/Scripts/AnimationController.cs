using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class AnimationController : MonoBehaviour
{
    public GameObject Data;
    //public Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.name);
        //Anim = GetComponent<Animator>();
        //SetAnimation("empty");
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
    void SetAnimation(string subjectName)
    {
        if (gameObject.GetComponent<SpriteRenderer>() != null && Data.GetComponent<ImageStorage>() != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Data.GetComponent<ImageStorage>().GetSprite(subjectName);
        }
        if (gameObject.GetComponent<Image>() != null && Data.GetComponent<ImageStorage>() != null)
        {
            gameObject.GetComponent<Image>().sprite = Data.GetComponent<ImageStorage>().GetSprite(subjectName);
        }
        //Anim.CrossFade(subjectName, 0);

    }
}
