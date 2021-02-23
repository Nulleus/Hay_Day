using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }
    void ClearAnimation()
    {
        Anim.CrossFade("Empty", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SetAnimation(string stateName)
    {
        Anim.CrossFade(stateName, 0);
    }
}
