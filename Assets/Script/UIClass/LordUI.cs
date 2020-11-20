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
        this.gameObject.GetComponentInParent<LordModel>().callL();
        Message message = new Message();
        message.lordChoice = 1;
        message.lord = true;
    }
    void notCallLord(GameObject call)
    {
        this.gameObject.GetComponentInParent<LordModel>().notCallL();
        Message message = new Message();
        message.lordChoice = 2;
        message.lord = true;
    }
    void grabLord(GameObject grab)
    {
        this.gameObject.GetComponentInParent<LordModel>().grabL();
        Message message = new Message();
        message.lordChoice = 3;
        message.lord = true;
    }
    void notGrabLord(GameObject notGrab)
    {
        this.gameObject.GetComponentInParent<LordModel>().notGrabL();
        Message message = new Message();
        message.lordChoice = 4;
        message.lord = true;
    }
}
