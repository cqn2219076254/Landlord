using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettlementPanel3 : BasePanel
{
	//提示文本
	private Text Name;
	private Text Score;
	private Text Rate;
	private Text Final;
	//确定按钮
	private Button Continue;
	private Button GoBack;

	//初始化
	public override void OnInit()
	{
		skinPath = "SettlementPanel3";
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
		Name.text = (string)args[0];
		Score.text = (string)args[1];
		Rate.text = (string)args[2];
		Final.text = (string)args[3];

	}

	//关闭
	public override void OnClose()
	{

	}

	//按下按钮
	public void OnBackClick()
	{
		PanelManager.Open<HomePanel>();
		Close();
	}

	public void OnConClick()
	{
		Close();
	}
}
