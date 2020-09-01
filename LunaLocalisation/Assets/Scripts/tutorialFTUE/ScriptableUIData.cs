using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DataBlock", menuName = "data")]
public class ScriptableUIData : ScriptableObject
{
    
    [Header(("Game start UI settings"), order = 0 )]
    public string startInstruction;
    
    [Header(("End Card UI Settings"), order = 1)]
    public string install_CTA_BTN;
    public string endCardWin_Text;
    public string endCardLabel_text;
    
    public Sprite endcard_IMG;
    public Sprite Install_BTN_Img;

}
/*
Add and remove data from here to be referenced in the UI Manager.
The data can be initialised from the inspector.
*/