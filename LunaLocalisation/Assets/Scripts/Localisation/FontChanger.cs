using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FontChanger : MonoBehaviour
{
    public static FontChanger instance;

    [SerializeField]
    // [LunaPlaygroundField("Fonts", 0, "Font Settings")] //Un-comment once you have Luna installed to make this available in Playground
    private FontsTypes FontSelection;
    
/*
 * The Fonts that relate to both TMP_font and normal texts fonts can be dropped into the lists below through the inspector.
 */
    [Header("---- TMP Font ----")]
    
    [SerializeField] List<TMP_FontAsset> FontsTMP = new List<TMP_FontAsset>();
    private Dictionary<FontsTypes, TMP_FontAsset> fontListTMP = new Dictionary<FontsTypes, TMP_FontAsset>();
    
    [Header("---- Text Font ----")]
    
    [SerializeField] List<Font> FontsText = new List<Font>();
    private Dictionary<FontsTypes, Font> fontList = new Dictionary<FontsTypes, Font>();
    
    
    void Awake()
    {
        instance = this;
        
       for (var i = 0; i < FontsTMP.Count; i++)
       {
           fontListTMP.Add((FontsTypes)i, FontsTMP[i]);
       }
       for (var i = 0; i < FontsText.Count; i++)
       {
           fontList.Add((FontsTypes)i, FontsText[i]);
       }
    }

    public TMP_FontAsset GetFontTMP() => fontListTMP[FontSelection];
    public Font GetFontText() => fontList[FontSelection];
}
/*
 * The FontTypes enum index should correspond to the order of the fonts you assign to the FontsText/FontsTMP array.
 * If you dont have the Fonts in the list to match the languages in FontTypes index, Unity will throw an error.
 */
[System.Serializable]
public enum FontsTypes
{
    English = 0,
    Japanese = 1,
    //Korean = 2,
    //ChineseSC = 3,
    //ChineseTC = 4,
    
}
