using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class MessageUI : MonoBehaviour
{
    [SerializeField] private float stepForAlpha = 0.01f;
    [SerializeField] private float timeUpdateAlpha = 0.02f;
    private void OnEnable()
    {
        
        
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void ShowMessage(string textUI)
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = textUI;
        StartCoroutine(TransparencyCoroutine());
    }
    private void OnDisable()
    {
        //gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Не Гринберг";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator TransparencyCoroutine()
    {
        Debug.Log("Example");
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(1f, 1f, 1f, 255f);
        float alpha = 1f;
        while(gameObject.GetComponent<TMPro.TextMeshProUGUI>().color.a >= 0)
        {
            alpha -= stepForAlpha;
            gameObject.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(1f, 1f, 1f, alpha);
            yield return new WaitForSeconds(timeUpdateAlpha);
            if (gameObject.GetComponent<TMPro.TextMeshProUGUI>().color.a <= 0)
            {
                gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            }
        }
    }
}
