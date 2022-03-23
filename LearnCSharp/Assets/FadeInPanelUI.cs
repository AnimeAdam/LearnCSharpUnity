using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInPanelUI : MonoBehaviour
{
    [SerializeField] float fadeInTime;

    Image fadePanel;
    Color currentColour = Color.black;

    // Start is called before the first frame update
    void Start()
    {
        fadePanel = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad < fadeInTime)
        {
            float alphaChange = Time.deltaTime / fadeInTime;
            currentColour.a -= alphaChange;
            fadePanel.color = currentColour;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
