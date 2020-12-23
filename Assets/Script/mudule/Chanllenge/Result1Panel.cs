using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result1Panel : BasePanel
{
	public Button back1;
	public Button back2;
	
	private AudioSource Vector1;

	//初始化
	public override void OnInit()
	{
		skinPath = "Result1Panel";
		layer = PanelManager.Layer.Panel;
	}

	//显示
	public override void OnShow(params object[] args)
	{
		//寻找组件
		back1 = skin.transform.Find("head").GetComponent<Button>();
		back2 = skin.transform.Find("frame").GetComponent<Button>();
		//监听
		back1.onClick.AddListener(OnBackClick);
		back2.onClick.AddListener(OnBackClick);
		
		Vector1 = gameObject.AddComponent<AudioSource>();
		AudioClip clip = Resources.Load<AudioClip>("Sound/CPSound/vector1");
		Vector1.volume = 10;
		Vector1.clip = clip;
		Vector1.Play();
	}

	//关闭
	public override void OnClose()
	{

	}

	public void OnBackClick()
	{
		PanelManager.Open<MapPanel>();
		DestroyImmediate(GameObject.Find("Root/Canvas/CP1(Clone)"));
		DestroyImmediate(GameObject.Find("Root/Canvas/CP2(Clone)"));
		DestroyImmediate(GameObject.Find("Root/Canvas/CP3(Clone)"));
		DestroyImmediate(GameObject.Find("Root/Canvas/CP4(Clone)"));
		Close();
	}
}