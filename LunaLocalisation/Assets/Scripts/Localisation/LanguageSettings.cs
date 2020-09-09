using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSettings : MonoBehaviour
{
    //Add TMP / texts to populate the arrays from inspector you want to change fonts.
   [Header("---- UI TMP Texts ----")]
    public TMP_Text[] UI_TMP;
    
    [Header("---- UI Texts ----")]
    public Text[] UI_Text;

    void Start()
    {
        for (int i = 0; i < UI_TMP.Length; i++)
        {
            UI_TMP[i].font = FontChanger.instance.GetFontTMP();
        }
        for (int i = 0; i < UI_Text.Length; i++)
        {
            UI_Text[i].font = FontChanger.instance.GetFontText();
        }
    }
    
}
