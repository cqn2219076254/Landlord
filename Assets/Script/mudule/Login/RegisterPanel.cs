using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : BasePanel
{
    public Text Success;
    public Text Mistake1;
    public Text Mistake2;
    public InputField Account;//账号输入
    public InputField Password;//密码输入
    public InputField Confirm;
    public Button Register;
    public Button Cancel;


    //初始化
    public override void OnInit()
    {
        skinPath = "RegisterPanel";
        layer = PanelManager.Layer.Panel;
    }

    //显示
    public override void OnShow(params object[] args)
    {
        //寻找组件
        Account = skin.transform.Find("Account").GetComponent<InputField>();
        Password = skin.transform.Find("Password").GetComponent<InputField>();
        Confirm = skin.transform.Find("Confirm").GetComponent<InputField>();
        Success = skin.transform.Find("Success").GetComponent<Text>();
        Mistake1 = skin.transform.Find("Mistake1").GetComponent<Text>();
        Mistake2 = skin.transform.Find("Mistake2").GetComponent<Text>();
        Register = skin.transform.Find("Register").GetComponent<Button>();
        Cancel = skin.transform.Find("Cancel").GetComponent<Button>();
        //监听
        Register.onClick.AddListener(OnRegClick);
        Cancel.onClick.AddListener(OnCancelClick);
        //网络协议监听
        NetManager.AddMsgListener("MsgRegister", OnMsgRegister);
    }

    //关闭
    public override void OnClose()
    {
        //网络协议监听
        NetManager.RemoveMsgListener("MsgRegister", OnMsgRegister);
    }

    //当按下注册按钮
    public void OnRegClick()
    {
        //两次密码不同
        if (Password.text != Confirm.text)
        {
            //Mistake2.gameObject.SetActive(true);
            //StartCoroutine(Disappear(2));
            PanelManager.Open<TipPanel>("两次输入密码不一致");
        }
        //发送
        else
        {
            MsgRegister msgReg = new MsgRegister();
            msgReg.id = Account.text;
            msgReg.pw = Password.text;
            NetManager.Send(msgReg);
        }
    }

    //收到注册协议
    public void OnMsgRegister(MsgBase msgBase)
    {
        MsgRegister msg = (MsgRegister)msgBase;
        if (msg.result == 0)
        {
            Debug.Log("注册成功");
            //提示
            Success.gameObject.SetActive(true);
            StartCoroutine(Disappear(1));
        }
        else
        {
            Debug.Log("注册失败");
            //Mistake1.gameObject.SetActive(true);
            //StartCoroutine(Disappear(0));
            PanelManager.Open<TipPanel>("账号已被注册");
        }
    }

    //当按下关闭按钮
    public void OnCancelClick()
    {
        PanelManager.Open<LoginPanel>();
        Close();
    }

    IEnumerator Disappear(int x)
    {
        yield return new WaitForSeconds(1);
        if (x == 0)
        {
            Mistake1.gameObject.SetActive(false);
        }
        else if (x == 1)
        {
            Success.gameObject.SetActive(false);
            PanelManager.Open<LoginPanel>();
            //关闭界面
            Close();
        }
        else
        {
            Mistake2.gameObject.SetActive(false);
        }
    }
}