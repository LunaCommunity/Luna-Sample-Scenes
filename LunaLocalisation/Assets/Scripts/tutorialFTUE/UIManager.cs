using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public ScriptableUIData endData;

    public Animator anim;

    public TextMeshProUGUI start_Text;
    public TextMeshProUGUI winText_TMP;
    public TextMeshProUGUI label_Text_TMP;
    public TextMeshProUGUI install_Btn_Text_TMP;


    public Image profile;
    public Image button_install;

    public GameObject end;
    public GameObject start;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //start
        start_Text.text = endData.startInstruction;

        //Endcard
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