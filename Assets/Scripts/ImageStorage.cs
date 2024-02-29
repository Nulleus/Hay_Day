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
    public void LoadSpriteDict()
    {
            foreach (var s in Sprites)
            {
                if (!SpritesDict.ContainsKey(s.name))
                {
                    SpritesDict.Add(s.name, s);
                }
                else
                {
                    Debug.Log(s.name+" ������� ��� ��������� � ������");
                }
                
            }    
    }

    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public Sprite GetSprite(string key)
    {
        if (key == null) { return null; }
        if (SpritesDict.ContainsKey(key))
        {
            return SpritesDict[key];
        }
        return null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        LoadSpriteDict();
    }
}
