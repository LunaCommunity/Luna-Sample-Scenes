using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FontChanger : MonoBehaviour
{
    public static FontChanger instance;

    [SerializeField]
    //[LunaPlaygroundField("Fonts", 0, "Font Settings")]
    private FontsTypes Fonts;

    [SerializeField] List<TMP_FontAsset> gameFonts = new List<TMP_FontAsset>();

    private Dictionary<FontsTypes, TMP_FontAsset> fontList = new Dictionary<FontsTypes, TMP_FontAsset>();

    void Awake()
    {
        instance = this;
       for (var i = 0; i < gameFonts.Count; i++)
       {
           fontList.Add((FontsTypes)i, gameFonts[i]);
       }
    }

    public TMP_FontAsset GetFont() => fontList[Fonts];
}
/*
 * The FontTypes enum index should correspond to the order of the fonts you assign to the gameFonts array.
 */
[System.Serializable]
public enum FontsTypes
{
    English = 0,
    Japanese = 1,
    Korean = 2,
    ChineseSC = 3,
    ChineseTC = 4,
}
