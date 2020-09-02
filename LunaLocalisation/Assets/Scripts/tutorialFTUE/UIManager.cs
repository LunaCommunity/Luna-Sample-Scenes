using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    
    
    public Animator anim;
    
    [Header("---- Data Container ----")]
    public ScriptableUIData endData;

    [Header("---- Texts ----")]
    public Text greet_Text;
    
    [Header("---- TMP Texts ----")]
    public TextMeshProUGUI start_Text;
    public TextMeshProUGUI winText_TMP;
    public TextMeshProUGUI label_Text_TMP;
    public TextMeshProUGUI install_Btn_Text_TMP;
    
    [Header("---- Image/Sprites ----")]
    public Image profile;
    public Image button_install;
    
    [Header("---- Other ----")]
    public GameObject end;
    public GameObject start;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //StartPanel data assignment 
        greet_Text.text = endData.greetingText;
        start_Text.text = endData.startInstruction;

        //EndPanel data assignment
        winText_TMP.text = endData.endCardWin_Text;
        label_Text_TMP.text = endData.endCardLabel_text;

        install_Btn_Text_TMP.text = endData.install_CTA_BTN;
        profile.sprite = endData.endcard_IMG;
        button_install.sprite = endData.Install_BTN_Img;

        anim.Play("TapScreen");
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SwitchPanel();
        }
    }

    public void SwitchPanel()
    {
        start.SetActive(false);
        end.SetActive(true);
    }
}