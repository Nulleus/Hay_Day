using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ImageStorage : MonoBehaviour
{
    [ShowInInspector]
    public Dictionary<string, Sprite> SpritesDict = new Dictionary<string, Sprite>();
    public Sprite[] Sprites;
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void LoadDict()
    {
        foreach (var s in Sprites)
        {
            SpritesDict.Add(s.name, s);
        }         
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
