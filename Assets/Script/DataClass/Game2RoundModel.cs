using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using static Const;
using System.Collections;

/// <summary>
/// 这个类用来存储每轮数据，和三位玩家做网络交互
/// 网络交互可能还需要改这个类，暂且如此
/// </summary>
public class Game2RoundModel : MonoBehaviour
{
    public Player player;
    public Player computer;

    public bool isWin = false;
    public int CPnum = 0;
    public int CurrentWeight = -1;//最大出牌人的出牌大小
    public int CurrentLength = -1;// 出牌长度
    public CardType CurrentType = CardType.None;// 出牌类型
    public Player BiggestCharacter = null;// 最大出牌者
    public Player CurrentCharacter = null;// 现在该谁出牌

    public void Start()
    {
        player = this.GetComponentsInChildren<Player>()[0];
        computer = this.GetComponentsInChildren<Player>()[1];
    }

    public void Turn()
    {
        Debug.Log("turn");
        //玩家轮换，更改状态
        Debug.Log(CurrentCharacter);
        Debug.Log(BiggestCharacter);
        if (CurrentCharacter.CardList.Count == 0)
        {
            if(CurrentCharacter == player)
            {
                isWin = true;
            }
            StartCoroutine(ShowResult());
        }
        else
        {   
            if (CurrentCharacter == player)
            {
                player.gameObject.GetComponent<Game2PlayCardUI>().pop.gameObject.SetActive(false);
                player.gameObject.GetComponent<Game2PlayCardUI>().notpop.gameObject.SetActive(false);
                CurrentCharacter = computer;
                switch (CPnum)
                {
                    case 1:
                        this.GetComponentsInChildren<CP1AI>()[0].Action();
                        break;
                    case 2:
                        this.GetComponentsInChildren<CP2AI>()[0].Action();
                        break;
                    case 3:
                        this.GetComponentsInChildren<CP3AI>()[0].Action();
                        break;
                    case 4:
                        this.GetComponentsInChildren<CP4AI>()[0].Action();
                        break;
                    //case 5:
                    //    this.GetComponentsInChildren<CP5AI>()[0].Action();
                    //    break;
                }
            }

            else if (CurrentCharacter == computer)
            {
                CurrentCharacter = player;
                player.gameObject.GetComponent<Game2PlayCardUI>().pop.gameObject.SetActive(true);
                player.gameObject.GetComponent<Game2PlayCardUI>().notpop.gameObject.SetActive(true);
            }
        }
    }

    public void NotPop()
    {
        Debug.Log("NotPop");
        CurrentLength = -1;
        CurrentWeight = -1;
        CurrentType = CardType.None;
        this.GetComponent<Game2DeskUI>().clearDesk();
        if (CurrentCharacter == player)
        {
            player.gameObject.GetComponent<Game2PlayCardUI>().pop.gameObject.SetActive(false);
            player.gameObject.GetComponent<Game2PlayCardUI>().notpop.gameObject.SetActive(false);
            CurrentCharacter = computer;
            switch (CPnum)
            {
                case 1:
                    this.GetComponentsInChildren<CP1AI>()[0].Action();
                    break;
                case 2:
                    this.GetComponentsInChildren<CP2AI>()[0].Action();
                    break;
                case 3:
                    this.GetComponentsInChildren<CP3AI>()[0].Action();
                    break;
                case 4:
                    this.GetComponentsInChildren<CP4AI>()[0].Action();
                    break;
                //case 5:
                //    this.GetComponentsInChildren<CP5AI>()[0].Action();
                //    break;
            }
        }
        else{
            CurrentCharacter = player;
            player.gameObject.GetComponent<Game2PlayCardUI>().pop.gameObject.SetActive(true);
            player.gameObject.GetComponent<Game2PlayCardUI>().notpop.gameObject.SetActive(true);
        }
    }

    IEnumerator ShowResult()
    {
        yield return new WaitForSeconds(1f);
        switch (CPnum)
        {
            case 1:
                GameObject.Find("Root/Canvas/CP1(Clone)/CP1CardDealing(Clone)").GetComponent<CP1CardDeal>().selfDestroy();
                break;
            case 2:
                GameObject.Find("Root/Canvas/CP2(Clone)/CP2CardDealing(Clone)").GetComponent<CP2CardDeal>().selfDestroy();
                break;
            case 3:
                GameObject.Find("Root/Canvas/CP3(Clone)/CP3CardDealing(Clone)").GetComponent<CP3CardDeal>().selfDestroy();
                break;
            case 4:
                GameObject.Find("Root/Canvas/CP4(Clone)/CP4CardDealing(Clone)").GetComponent<CP4CardDeal>().selfDestroy();
                break;
            //case 5:
            //    GameObject.Find("Root/Canvas/CP5(Clone)/CP5CardDealing(Clone)").GetComponent<CP5CardDeal>().selfDestroy();
            //    break;
        }
        if (isWin)
        {
            PanelManager.Open<Result1Panel>();
        }
        else
        {
            PanelManager.Open<Result2Panel>();
        }
    }
}

