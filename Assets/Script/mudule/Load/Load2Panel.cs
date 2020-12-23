using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Load2Panel : BasePanel
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
        OpenMulti(x);
        Close();
    }

    public void OpenMulti(int x)
    {
        GameObject g;
        switch (x)
        {
            case 1:
                GameObject.Find("Root/Canvas/backgroundfish").SetActive(false);
                GameObject.Find("Root/Canvas/background").SetActive(true);
                g = Instantiate(Resources.Load<GameObject>("multi"));
                g.transform.SetParent(GameObject.Find("Root/Canvas").transform);
                g.transform.localScale = new Vector3(1, 1, 1);
                g.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-679, 186, 0);
                
                MsgEnterRoom msgEnterRoom = new MsgEnterRoom();
                NetManager.Send(msgEnterRoom);
                break;
            case 2:
                GameObject.Find("Root/Canvas/backgroundfish").SetActive(true);
                GameObject.Find("Root/Canvas/background").SetActive(false);
                g = Instantiate(Resources.Load<GameObject>("FishPrefab"));
                g.transform.SetParent(GameObject.Find("Root/Canvas").transform);
                g.transform.localScale = new Vector3(1, 1, 1);
                g.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
                
                MsgEnterFishRoom msgEnterFishRoom = new MsgEnterFishRoom();
                NetManager.Send(msgEnterFishRoom);
                break;
        }
    }
}