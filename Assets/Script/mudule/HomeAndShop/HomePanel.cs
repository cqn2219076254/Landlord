using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class HomePanel : BasePanel
{
	public Button multiplayer;
	public Button challenge;
	public Button shop;
	public static Text beanNum;
	public static Text diamondNum;

	private string bn;
	private string dn;
	//初始化
	public override void OnInit()
	{
		skinPath = "HomePanel";
		layer = PanelManager.Layer.Panel;
	}

	//显示
	public override void OnShow(params object[] args)
	{
		//寻找组件
		multiplayer = skin.transform.Find("Multiplayer").GetComponent<Button>();
		challenge = skin.transform.Find("Challenge").GetComponent<Button>();
		shop = skin.transform.Find("Shop").GetComponent<Button>();
		beanNum = skin.transform.Find("beannum").GetComponent<Text>();
		diamondNum = skin.transform.Find("diamondnum").GetComponent<Text>();

		//监听
		multiplayer.onClick.AddListener(OnMultiClick);
		challenge.onClick.AddListener(OnChallengeClick);
		shop.onClick.AddListener(OnShopClick);

		// 发送查询
		MsgGetPlayerInfo msgGetPlayerInfo = new MsgGetPlayerInfo();
		NetManager.Send(msgGetPlayerInfo);
		// 协议监听
		NetManager.AddMsgListener("MsgGetPlayerInfo", OnGetPlayerInfo);
	}

	//关闭
	public override void OnClose()
	{

	}

	//当按下开始按钮
	public void OnMultiClick()
	{
		PanelManager.Open<GameTypePanel>();
		NetManager.RemoveMsgListener("MsgGetPlayerInfo", OnGetPlayerInfo);
		Close();
	}

	public void OnChallengeClick()
	{
		PanelManager.Open<MapPanel>();
		NetManager.RemoveMsgListener("MsgGetPlayerInfo", OnGetPlayerInfo);
		Close();
	}

	public void OnShopClick()
	{
		//PanelManager.Open<ShopPanel>();
	}

	//收到玩家信息
	public void OnGetPlayerInfo(MsgBase msgBase)
	{
		MsgGetPlayerInfo msg = (MsgGetPlayerInfo)msgBase;
		beanNum.text = msg.bean.ToString();
		diamondNum.text = msg.diamond.ToString();
		Debug.Log(beanNum.text);
		Debug.Log(diamondNum.text);
	}
}