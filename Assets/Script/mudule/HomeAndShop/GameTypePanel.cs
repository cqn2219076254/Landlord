using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class GameTypePanel : BasePanel
{
	public Button landlord;
	public Button fash;
	public Button goback;
	//初始化
	public override void OnInit()
	{
		skinPath = "GameTypePanel";
		layer = PanelManager.Layer.Panel;
	}

	//显示
	public override void OnShow(params object[] args)
	{
		//寻找组件
		landlord = skin.transform.Find("Landlord").GetComponent<Button>();
		fash = skin.transform.Find("Fash").GetComponent<Button>();
		goback = skin.transform.Find("gobackhome").GetComponent<Button>();

		//监听
		landlord.onClick.AddListener(OnMultiClick);
		fash.onClick.AddListener(OnFashClick);
		goback.onClick.AddListener(OnBackClick);
	}

	//关闭
	public override void OnClose()
	{

	}

	//当按下开始按钮
	public void OnMultiClick()
	{
		PanelManager.Open<Load2Panel>(1);
		Close();
	}

	public void OnFashClick()
	{
		PanelManager.Open<Load2Panel>(2);
		Close();
	}

	public void OnBackClick()
	{
		PanelManager.Open<HomePanel>();
		Close();
	}
	
}