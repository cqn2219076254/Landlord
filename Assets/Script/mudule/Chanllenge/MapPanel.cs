using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MapPanel : BasePanel
{
    public static Button cp1_0;
    public static Button cp2_0;
    public static Button cp3_0;
    public static Button cp4_0;
    public static Button cp1_1;
    public static Button cp2_1;
    public static Button cp3_1;
    public static Button cp4_1;
    public static Button cp1_2;
    public static Button cp2_2;
    public static Button cp3_2;
    public static Button cp4_2;
    public Button gobackhome;

    private int cpNum = 0;

    //初始化
    public override void OnInit()
    {
        skinPath = "MapPanel";
        layer = PanelManager.Layer.Panel;
    }

    //显示
    public override void OnShow(params object[] args)
    {
        //寻找组件
        cp1_0 = skin.transform.Find("Checkpoint1").GetComponent<Button>();
        cp2_0 = skin.transform.Find("Checkpoint2").GetComponent<Button>();
        cp3_0 = skin.transform.Find("Checkpoint3").GetComponent<Button>();
        cp4_0 = skin.transform.Find("Checkpoint4").GetComponent<Button>();
        cp1_1 = skin.transform.Find("Checkpoint1_2").GetComponent<Button>();
        cp2_1 = skin.transform.Find("Checkpoint2_2").GetComponent<Button>();
        cp3_1 = skin.transform.Find("Checkpoint3_2").GetComponent<Button>();
        cp4_1 = skin.transform.Find("Checkpoint4_2").GetComponent<Button>();
        cp1_2 = skin.transform.Find("Checkpoint1_3").GetComponent<Button>();
        cp2_2 = skin.transform.Find("Checkpoint2_3").GetComponent<Button>();
        cp3_2 = skin.transform.Find("Checkpoint3_3").GetComponent<Button>();
        cp4_2 = skin.transform.Find("Checkpoint4_3").GetComponent<Button>();
        gobackhome = skin.transform.Find("gobackhome").GetComponent<Button>();

        //监听
        gobackhome.onClick.AddListener(OnBackClick);
        cp1_0.onClick.AddListener(OnCheck1Click);
        cp2_0.onClick.AddListener(OnCheck2Click);
        cp3_0.onClick.AddListener(OnCheck3Click);
        cp4_0.onClick.AddListener(OnCheck4Click);
        cp1_1.onClick.AddListener(OnCheck1Click);
        cp2_1.onClick.AddListener(OnCheck2Click);
        cp3_1.onClick.AddListener(OnCheck3Click);
        cp4_1.onClick.AddListener(OnCheck4Click);
        cp1_2.onClick.AddListener(OnGreyClick);
        cp2_2.onClick.AddListener(OnGreyClick);
        cp3_2.onClick.AddListener(OnGreyClick);
        cp4_2.onClick.AddListener(OnGreyClick);
        
        // 发送查询
        MsgGetPlayerInfo msgGetPlayerInfo = new MsgGetPlayerInfo();
        NetManager.Send(msgGetPlayerInfo);
        // 协议监听
        NetManager.AddMsgListener("MsgGetPlayerInfo", OnGetPlayerInfo);

    }

    public void ShowButton(int num)
    {
        switch (num)
        {
            case 0:
                cp1_0.gameObject.SetActive(true);
                cp2_2.gameObject.SetActive(true);
                cp3_2.gameObject.SetActive(true);
                cp4_2.gameObject.SetActive(true);
                break;
            case 1:
                cp1_1.gameObject.SetActive(true);
                cp2_0.gameObject.SetActive(true);
                cp3_2.gameObject.SetActive(true);
                cp4_2.gameObject.SetActive(true);
                break;
            case 2:
                cp1_1.gameObject.SetActive(true);
                cp2_1.gameObject.SetActive(true);
                cp3_0.gameObject.SetActive(true);
                cp4_2.gameObject.SetActive(true);
                break;
            case 3:
                cp1_1.gameObject.SetActive(true);
                cp2_1.gameObject.SetActive(true);
                cp3_1.gameObject.SetActive(true);
                cp4_0.gameObject.SetActive(true);
                break;
            case 4:
                cp1_1.gameObject.SetActive(true);
                cp2_1.gameObject.SetActive(true);
                cp3_1.gameObject.SetActive(true);
                cp4_1.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void OnGreyClick()
    {
        PanelManager.Open<TipPanel>("该关卡未解锁");
    }

    public void OnBackClick()
    {
        PanelManager.Open<HomePanel>();
        NetManager.RemoveMsgListener("MsgGetPlayerInfo", OnGetPlayerInfo);
        Close();
    }

    public void OnCheck1Click()
    {
        PanelManager.Open<Load3Panel>(1);
        NetManager.RemoveMsgListener("MsgGetPlayerInfo", OnGetPlayerInfo);
        Close();
    }

    public void OnCheck2Click()
    {
        PanelManager.Open<Load3Panel>(2);
        NetManager.RemoveMsgListener("MsgGetPlayerInfo", OnGetPlayerInfo);
        Close();
    }

    public void OnCheck3Click()
    {
        PanelManager.Open<Load3Panel>(3);
        NetManager.RemoveMsgListener("MsgGetPlayerInfo", OnGetPlayerInfo);
        Close();
    }

    public void OnCheck4Click()
    {
        PanelManager.Open<Load3Panel>(4);
        NetManager.RemoveMsgListener("MsgGetPlayerInfo", OnGetPlayerInfo);
        Close();
    }

    public void OnGetPlayerInfo(MsgBase msgBase)
    {
        MsgGetPlayerInfo msg = (MsgGetPlayerInfo)msgBase;
        cpNum = msg.cpNum;
        Debug.Log(cpNum);
        ShowButton(cpNum);
    }
}
