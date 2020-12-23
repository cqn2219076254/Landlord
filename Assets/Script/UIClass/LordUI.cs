using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LordUI : MonoBehaviour
{
    public GameObject call;
    public GameObject notCall;
    public GameObject grab;
    public GameObject notGrab;
    private void Start()
    {
        //添加notpop
        Button cbtn = (Button)call.GetComponent<Button>();
        cbtn.onClick.AddListener(delegate ()
        {
            callLord(call);
        });
        Button ncbtn = (Button)notCall.GetComponent<Button>();
        ncbtn.onClick.AddListener(delegate ()
        {
            notCallLord(notCall);
        });
        Button gbtn = (Button)grab.GetComponent<Button>();
        gbtn.onClick.AddListener(delegate ()
        {
            grabLord(grab);
        });
        Button ngbtn = (Button)notGrab.GetComponent<Button>();
        ngbtn.onClick.AddListener(delegate ()
        {
            notGrabLord(notGrab);
        });
    }
    void callLord(GameObject call)
    {
        GameObject.Find("Root/Canvas/multi(Clone)/board/Desk").GetComponentInParent<Sound>().PlayEffect(Const.CallLord);
        Debug.Log("click succ");
        this.gameObject.GetComponentInParent<LordModel>().callL();
        MsgGrabMsg msg = new MsgGrabMsg();
        msg.roomId = NetManager.GetPlayer().roomId;
        msg.lord = true;
        msg.lordChoice = 1;
        NetManager.Send(msg);
    }
    void notCallLord(GameObject call)
    {
        this.gameObject.GetComponentInParent<LordModel>().notCallL();
        MsgGrabMsg msg = new MsgGrabMsg();
        msg.roomId = NetManager.GetPlayer().roomId;
        msg.lord = true;
        msg.lordChoice = 2;
        NetManager.Send(msg);
        Debug.Log("send msg succ");
        Debug.Log(msg.lord);
    }
    void grabLord(GameObject grab)
    {
        GameObject.Find("Root/Canvas/multi(Clone)/board/Desk").GetComponentInParent<Sound>().PlayEffect(Const.Grab);
        this.gameObject.GetComponentInParent<LordModel>().grabL();
        MsgGrabMsg msg = new MsgGrabMsg();
        msg.roomId = NetManager.GetPlayer().roomId;
        msg.lordChoice = 3;
        msg.lord = true;
        NetManager.Send(msg);
    }
    void notGrabLord(GameObject notGrab)
    {
        GameObject.Find("Root/Canvas/multi(Clone)/board/Desk").GetComponentInParent<Sound>().PlayEffect(Const.DisGrab);
        this.gameObject.GetComponentInParent<LordModel>().notGrabL();
        MsgGrabMsg msg = new MsgGrabMsg();
        msg.roomId = NetManager.GetPlayer().roomId;
        msg.lord = true;
        msg.lordChoice = 4;
        NetManager.Send(msg);
    }
}
