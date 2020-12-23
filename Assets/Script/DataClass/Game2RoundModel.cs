using UnityEngine;
using static Const;
using System.Collections;

/// <summary>
/// 这个类用来存储每轮数据，和三位玩家做网络交互
/// 网络交互可能还需要改这个类，暂且如此
/// </summary>
public class Game2RoundModel : MonoBehaviour
{
    public Game2Player player;
    public Game2Player computer;

    public bool isWin = false;
    public int CPnum = 0;
    public int CurrentWeight = -1;//最大出牌人的出牌大小
    public int CurrentLength = -1;// 出牌长度
    public CardType CurrentType = CardType.None;// 出牌类型
    public Game2Player BiggestCharacter = null;// 最大出牌者
    public Game2Player CurrentCharacter = null;// 现在该谁出牌
    
    private AudioSource NotPop1;
    private AudioSource Pop1;

    public void Start()
    {
        player = this.GetComponentsInChildren<Game2Player>()[0];
        computer = this.GetComponentsInChildren<Game2Player>()[1];
    }

    public void Turn()
    {
        Debug.Log("turn");
        Debug.Log(CurrentCharacter);
        Debug.Log(BiggestCharacter);
        if (CurrentCharacter == player)
        {
            Pop1 = gameObject.AddComponent<AudioSource>();
            AudioClip clip = Resources.Load<AudioClip>("Sound/CPSound/pop1");
            Pop1.volume = 10;
            Pop1.clip = clip;
            Pop1.Play();
        }
        
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
        if (CurrentCharacter == player)
        {
            NotPop1 = gameObject.AddComponent<AudioSource>();
            AudioClip clip = Resources.Load<AudioClip>("Sound/CPSound/notpop1");
            NotPop1.volume = 10;
            NotPop1.clip = clip;
            NotPop1.Play();
        }

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
        }
        if (isWin)
        {
            MsgCPNum msgCPNum = new MsgCPNum();
            msgCPNum.CPNum = CPnum;
            msgCPNum.diamond = 100;
            NetManager.Send(msgCPNum);

            PanelManager.Open<Result1Panel>();
        }
        else
        {
            MsgCPNum msgCPNum = new MsgCPNum();
            NetManager.Send(msgCPNum);

            PanelManager.Open<Result2Panel>();
        }
    }
}

