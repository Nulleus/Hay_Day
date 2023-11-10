using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class AnimationController : MonoBehaviour
{
    public Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        SetAnimation("empty");
    }
    void ClearAnimation()
    {
        Anim.CrossFade("Empty", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    void SetAnimation(string subjectName)
    {
        Anim.CrossFade(subjectName, 0);
    }
}
