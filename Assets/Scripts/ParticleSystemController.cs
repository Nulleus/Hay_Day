using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ParticleSystemController : MonoBehaviour
{
    public GameObject Fireworks;
    [ShowInInspector]

    public void StartParticle()
    {
        Fireworks.SetActive(true);
        Fireworks.GetComponent<ParticleSystem>().Play();      
    }
    [ShowInInspector]
    public void StopParticle()
    {
        Fireworks.GetComponent<ParticleSystem>().Stop();
        Fireworks.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
