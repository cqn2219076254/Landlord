using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishS2Panel : BasePanel
{
    //确定按钮
    private Button Continue;
    private Button GoBack;

    //初始化
    public override void OnInit()
    {
        skinPath = "FishS2Panel";
        layer = PanelManager.Layer.Panel;
    }
    //显示
    public override void OnShow(params object[] args)
    {
        Continue = skin.transform.Find("continue").GetComponent<Button>();
        GoBack = skin.transform.Find("goback").GetComponent<Button>();
        //监听
        Continue.onClick.AddListener(OnConClick);
        GoBack.onClick.AddListener(OnBackClick);
    }

    //关闭
    public override void OnClose()
    {

    }

    //按下按钮
    public void OnBackClick()
    {
        PanelManager.Open<Load1Panel>();
        Close();
    }

    public void OnConClick()
    {
        
    }
}