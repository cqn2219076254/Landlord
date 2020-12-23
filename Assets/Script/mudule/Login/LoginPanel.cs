using System.Collections;
using System.Collections.Generic;
using Script.DataClass;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{
    public Text Success;
    public Text Mistake;
    public InputField Account;//账号输入
    public InputField Password;//密码输入
    public Button Register;
    public Button Login;

    //初始化
    public override void OnInit()
    {
        skinPath = "LoginPanel";
        layer = PanelManager.Layer.Panel;
    }

    //显示
    public override void OnShow(params object[] args)
    {
        ////寻找组件
        Account = skin.transform.Find("Account").GetComponent<InputField>();
        Password = skin.transform.Find("Password").GetComponent<InputField>();
        Register = skin.transform.Find("Register").GetComponent<Button>();
        Login = skin.transform.Find("Login").GetComponent<Button>();
        Success = skin.transform.Find("Success").GetComponent<Text>();
        Mistake = skin.transform.Find("Mistake").GetComponent<Text>();

        ////监听
        Login.onClick.AddListener(OnLoginClick);
        Register.onClick.AddListener(OnRegClick);
        //网络协议监听
        NetManager.AddMsgListener("MsgLogin", OnMsgLogin);
    }

    //当按下注册按钮
    public void OnRegClick()
    {
        PanelManager.Open<RegisterPanel>();
        Close();
    }

    //当按下登陆按钮
    public void OnLoginClick()
    {
        MsgLogin msgLogin = new MsgLogin();
        msgLogin.id = Account.text;
        msgLogin.pw = Password.text;
        NetManager.Send(msgLogin);

        // PanelManager.Close("BeginPanel");
        // PanelManager.Open<Load1Panel>();
        // Close();
    }

    //收到登陆协议
    //收到登陆协议
    public void OnMsgLogin(MsgBase msgBase)
    {
        MsgLogin msg = (MsgLogin)msgBase;
        if (msg.result == 0)
        {
            Debug.Log("登陆成功");
            //初始化player，id
            NetManager.SetPlayer(new NewPlayer(msg.id));
            //打开房间列表界面
            PanelManager.Close("BeginPanel");
            PanelManager.Open<Load1Panel>();
            //关闭界面
            Close();
        }
        else
        {
            PanelManager.Open<TipPanel>("账号或密码错误");
        }
    }


}