using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginPanel : BasePanel
{
	public Image title;
	public Button start;

	//初始化
	public override void OnInit()
	{
		skinPath = "BeginPanel";
		layer = PanelManager.Layer.Panel;
	}

	//显示
	public override void OnShow(params object[] args)
	{
		//寻找组件
		title = skin.transform.Find("title").GetComponent<Image>();
		start = skin.transform.Find("start").GetComponent<Button>();
		//监听
		start.onClick.AddListener(OnBeginClick);
	}

	//关闭
	public override void OnClose()
	{
		//网络事件监听
		NetManager.RemoveEventListener(NetManager.NetEvent.ConnectSucc, OnConnectSucc);
		NetManager.RemoveEventListener(NetManager.NetEvent.ConnectFail, OnConnectFail);
	}


	//连接成功回调
	void OnConnectSucc(string err)
	{
		Debug.Log("OnConnectSucc");
	}

	//连接失败回调
	void OnConnectFail(string err)
	{
		Debug.Log("OnConnectFail " + err);
	}



	//当按下开始按钮
	public void OnBeginClick()
	{
		NetManager.Connect("10.21.49.19", 8888);
		if (NetManager.getConnecting() == true)
		{
			title.gameObject.SetActive(false);
			start.gameObject.SetActive(false);
			PanelManager.Open<LoginPanel>();
		}
		//       title.gameObject.SetActive(false);
		//       start.gameObject.SetActive(false);
		// PanelManager.Open<LoginPanel>();
	}
}