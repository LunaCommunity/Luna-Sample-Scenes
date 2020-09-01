using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSettings : MonoBehaviour
{
    //Add any texts from inspector you want the fonts for changed.
    public TextMeshProUGUI[] endCardTexts;

    void Start()
    {
        for (int i = 0; i < endCardTexts.Length; i++)
        {
            endCardTexts[i].font = FontChanger.instance.GetFont();
        }
    }
    
}
