using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettlementPanel1 : BasePanel
{
	//提示文本
	private static Text Name;
	private static Text Score;
	private static Text Rate;
	private static Text Final;
	//确定按钮
	private Button Continue;
	private Button GoBack;

	//初始化
	public override void OnInit()
	{
		skinPath = "SettlementPanel1";
		layer = PanelManager.Layer.Panel;
	}
	//显示
	public override void OnShow(params object[] args)
	{
		//寻找组件
		Name = skin.transform.Find("name").GetComponent<Text>();
		Score = skin.transform.Find("score").GetComponent<Text>();
		Rate = skin.transform.Find("rate").GetComponent<Text>();
		Final = skin.transform.Find("final").GetComponent<Text>();
		Continue = skin.transform.Find("continue").GetComponent<Button>();
		GoBack = skin.transform.Find("goback").GetComponent<Button>();
		//监听
		Continue.onClick.AddListener(OnConClick);
		GoBack.onClick.AddListener(OnBackClick);
		//文字显示
		// Name.text = (string)args[0];
		// Score.text = (string)args[1];
		// Rate.text = (string)args[2];
		// Final.text = (string)args[3];
		
		MsgBean msgBean = new MsgBean();
		msgBean.beanNum = 400;
		NetManager.Send(msgBean);
	}

	//关闭
	public override void OnClose()
	{

	}

	//按下按钮
	public void OnBackClick()
	{
		PanelManager.Open<Load1Panel>();
		Close();
	}

	public void OnConClick()
	{
		GameObject g = Instantiate(Resources.Load<GameObject>("multi"));
		g.transform.SetParent(GameObject.Find("Root/Canvas").transform);
		g.transform.localScale = new Vector3(1, 1, 1);
		g.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-679, 186, 0);
		

		// enter room
		MsgEnterRoom msgEnterRoom = new MsgEnterRoom();
		NetManager.Send(msgEnterRoom);
		Close();
	}
}
