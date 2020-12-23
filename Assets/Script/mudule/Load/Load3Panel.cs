using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Load3Panel : BasePanel
{
    public Image load1;
    public Image load2;
    public Image load3;
    public Image load4;
    public Image load5;
    public Image load6;

    
    public override void OnInit()
    {
        skinPath = "Load1Panel";
        layer = PanelManager.Layer.Panel;
    }
    
    public override void OnShow(params object[] args)
    {
        //寻找组件
        load1 = skin.transform.Find("load1").GetComponent<Image>();
        load2 = skin.transform.Find("load2").GetComponent<Image>();
        load3 = skin.transform.Find("load3").GetComponent<Image>();
        load4 = skin.transform.Find("load4").GetComponent<Image>();
        load5 = skin.transform.Find("load5").GetComponent<Image>();
        load6 = skin.transform.Find("load6").GetComponent<Image>();

        StartCoroutine(Load((int)args[0]));
    }
    
    public override void OnClose()
    {

    }

    IEnumerator Load(int x)
    {
        load1.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        load1.gameObject.SetActive(false);
        load2.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        load2.gameObject.SetActive(false);
        load3.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        load3.gameObject.SetActive(false);
        load4.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        load4.gameObject.SetActive(false);
        load5.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        load5.gameObject.SetActive(false);
        load6.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        OpenCP(x);
        Close();
    }

    public void OpenCP(int x)
    {
        GameObject CardDeal;
        switch (x)
        {
            case 1:
                GameObject CP1 = Instantiate(Resources.Load<GameObject>("CP1"));
                CP1.transform.SetParent(GameObject.Find("Root/Canvas").transform);
                CP1.transform.localScale = new Vector3(1, 1, 1);
                CP1.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-512, (float)133.6, 0);
                GameObject.Find("Root/Canvas/CP1(Clone)/desk").GetComponent<Game2RoundModel>().CPnum = 1;
                CardDeal = Instantiate(Resources.Load<GameObject>("CP1CardDealing"));
                CardDeal.transform.SetParent(GameObject.Find("Root/Canvas/CP1(Clone)").transform);
                break;
            case 2:
                GameObject CP2 = Instantiate(Resources.Load<GameObject>("CP2"));
                CP2.transform.SetParent(GameObject.Find("Root/Canvas").transform);
                CP2.transform.localScale = new Vector3(1, 1, 1);
                CP2.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-512, (float)133.6, 0);
                GameObject.Find("Root/Canvas/CP2(Clone)/desk").GetComponent<Game2RoundModel>().CPnum = 2;
                CardDeal = Instantiate(Resources.Load<GameObject>("CP2CardDealing"));
                CardDeal.transform.SetParent(GameObject.Find("Root/Canvas/CP2(Clone)").transform);
                break;
            case 3:
                GameObject CP3 = Instantiate(Resources.Load<GameObject>("CP3"));
                CP3.transform.SetParent(GameObject.Find("Root/Canvas").transform);
                CP3.transform.localScale = new Vector3(1, 1, 1);
                CP3.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-512, (float)133.6, 0);
                GameObject.Find("Root/Canvas/CP3(Clone)/desk").GetComponent<Game2RoundModel>().CPnum = 3;
                CardDeal = Instantiate(Resources.Load<GameObject>("CP3CardDealing"));
                CardDeal.transform.SetParent(GameObject.Find("Root/Canvas/CP3(Clone)").transform);
                break;
            case 4:
                GameObject CP4 = Instantiate(Resources.Load<GameObject>("CP4"));
                CP4.transform.SetParent(GameObject.Find("Root/Canvas").transform);
                CP4.transform.localScale = new Vector3(1, 1, 1);
                CP4.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-512, (float)133.6, 0);
                GameObject.Find("Root/Canvas/CP4(Clone)/desk").GetComponent<Game2RoundModel>().CPnum = 4;
                CardDeal = Instantiate(Resources.Load<GameObject>("CP4CardDealing"));
                CardDeal.transform.SetParent(GameObject.Find("Root/Canvas/CP4(Clone)").transform);
                break;
        }
    }
}