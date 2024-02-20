using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class ScrollRectSetting : MonoBehaviour
{
    ScrollRect _scrollRect;
    //1-означает что он будет в начале, 0 в конце
    // Start is called before the first frame update
    void Start()
    {

    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetStartPoint()
    {
        _scrollRect = GetComponent<ScrollRect>();
        _scrollRect.normalizedPosition = new Vector2(_scrollRect.normalizedPosition.x, 1);
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetEndPoint()
    {
        _scrollRect = GetComponent<ScrollRect>();
        _scrollRect.normalizedPosition = new Vector2(_scrollRect.normalizedPosition.x, 0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
