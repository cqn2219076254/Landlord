using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayCardUIF : MonoBehaviour
{
    public GameObject pop;
    public string[] Out;
    void Start()
    {
        Button btn = (Button)pop.GetComponent<Button>();
        btn.onClick.AddListener(delegate ()
        {
            onClick(pop);
        });
    }

    // Update is called once per frame
    void onClick(GameObject pop)
    {
        Player hostP = this.GetComponent<Player>();
        if (hostP.pickedlist.Count == 1)
        {
            hostP.CardList.Remove(hostP.pickedlist[0]);
            Debug.Log(hostP.pickedlist[0].value+"sp"+hostP.CardList.Count);
            Card outC = hostP.pickedlist[0];
            hostP.pickedlist.Remove(outC);
            outC.UIS.gameObject.SetActive(false);
            this.transform.parent.GetComponent<frm>().process(outC);
            
            MsgGrabMsg msgPop = new MsgGrabMsg();
            Debug.Log(NetManager.GetPlayer().roomId);
            msgPop.roomId = NetManager.GetPlayer().roomId;
            msgPop.fishPop = true;
            Out = new string[2];
            Out[0] = outC.value.ToString();
            Out[1] = outC.color.ToString();
            msgPop.fishOCard = Out[0] + "," + Out[1] + ",";
            NetManager.Send(msgPop);
        }
        else if (hostP.pickedlist.Count == 0)
        {

        }
    }
}
