using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DataBlock", menuName = "data")]
public class ScriptableUIData : ScriptableObject
{
    
    [Header(("Game start UI settings"))]
    public string greetingText;
    public string startInstruction;
    
    
    [Header(("End Card UI Settings"))]
    public string install_CTA_BTN;
    public string endCardWin_Text;
    public string endCardLabel_text;
    
    public Sprite endcard_IMG;
    public Sprite Install_BTN_Img;

}
/*
Add and remove fields from here to be referenced in the UI Manager.
The fields can be assigned from the inspector.
*/