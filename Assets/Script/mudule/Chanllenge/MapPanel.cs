using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MapPanel : BasePanel
{
    public Button cp1_0;
    public Button cp2_0;
    public Button cp3_0;
    public Button cp4_0;
    public Button cp1_1;
    public Button cp2_1;
    public Button cp3_1;
    public Button cp4_1;
    public Button cp1_2;
    public Button cp2_2;
    public Button cp3_2;
    public Button cp4_2;
    public Button gobackhome;

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

        ShowButton((int)args[0]);
        //网络协议监听
        //NetManager.AddMsgListener("MsgLogin", OnMsgLogin);
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
        Close();
    }

    public void OnCheck1Click()
    {
        GameObject CP1 = Instantiate(Resources.Load<GameObject>("CP1"));
        CP1.transform.SetParent(GameObject.Find("Root/Canvas").transform);
        CP1.transform.localScale = new Vector3(1, 1, 1);
        CP1.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-512, (float)133.6, 0);
        GameObject.Find("Root/Canvas/CP1(Clone)/desk").GetComponent<Game2RoundModel>().CPnum = 1;
        GameObject CardDeal = Instantiate(Resources.Load<GameObject>("CP1CardDealing"));
        CardDeal.transform.SetParent(GameObject.Find("Root/Canvas/CP1(Clone)").transform);
        Close();
    }

    public void OnCheck2Click()
    {
        GameObject CP2 = Instantiate(Resources.Load<GameObject>("CP2"));
        CP2.transform.SetParent(GameObject.Find("Root/Canvas").transform);
        CP2.transform.localScale = new Vector3(1, 1, 1);
        CP2.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-512, (float)133.6, 0);
        GameObject.Find("Root/Canvas/CP2(Clone)/desk").GetComponent<Game2RoundModel>().CPnum = 2;
        GameObject CardDeal = Instantiate(Resources.Load<GameObject>("CP2CardDealing"));
        CardDeal.transform.SetParent(GameObject.Find("Root/Canvas/CP2(Clone)").transform);
        Close();
    }

    public void OnCheck3Click()
    {
        GameObject CP3 = Instantiate(Resources.Load<GameObject>("CP3"));
        CP3.transform.SetParent(GameObject.Find("Root/Canvas").transform);
        CP3.transform.localScale = new Vector3(1, 1, 1);
        CP3.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-512, (float)133.6, 0);
        GameObject.Find("Root/Canvas/CP3(Clone)/desk").GetComponent<Game2RoundModel>().CPnum = 3;
        GameObject CardDeal = Instantiate(Resources.Load<GameObject>("CP3CardDealing"));
        CardDeal.transform.SetParent(GameObject.Find("Root/Canvas/CP3(Clone)").transform);
        Close();
    }

    public void OnCheck4Click()
    {
        GameObject CP4 = Instantiate(Resources.Load<GameObject>("CP4"));
        CP4.transform.SetParent(GameObject.Find("Root/Canvas").transform);
        CP4.transform.localScale = new Vector3(1, 1, 1);
        CP4.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-512, (float)133.6, 0);
        GameObject.Find("Root/Canvas/CP4(Clone)/desk").GetComponent<Game2RoundModel>().CPnum = 4;
        GameObject CardDeal = Instantiate(Resources.Load<GameObject>("CP4CardDealing"));
        CardDeal.transform.SetParent(GameObject.Find("Root/Canvas/CP4(Clone)").transform);
        Close();
    }
}
