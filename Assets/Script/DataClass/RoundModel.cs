using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Const;

/// <summary>
/// 这个类用来存储每轮数据，和三位玩家做网络交互
/// 网络交互可能还需要改这个类，暂且如此
/// </summary>
public class RoundModel : MonoBehaviour
{
    public List<Player> PlayerList;
    public Player LandLord = null;

    public bool isWin = false; //判定对局情况
    public Player Winner = null; //赢家：这里的数据会用于胜利界面，积分结算等等的显示
    public int CurrentWeight = -1;//最大出牌人的出牌大小
    public int CurrentLength = -1;// 出牌长度
    public CardType CurrentType = CardType.None;// 出牌类型
    public Player BiggestCharacter = null;// 最大出牌者
    public Player CurrentCharacter = null;// 现在该谁出牌

    private void Awake()
    {
        PlayerList = this.GetComponentsInChildren<Player>().ToList<Player>();
    }
    public void Turn()
    {
        //玩家轮换，更改状态
        int t = PlayerList.FindIndex(ind => ind.Equals(CurrentCharacter));
        print(CurrentCharacter + "" + t);
        if (CurrentCharacter == PlayerList[0])
        {
            CurrentCharacter.gameObject.GetComponent<PlayCardUI>().pop.SetActive(false);      //禁用当前角色按钮
            CurrentCharacter.gameObject.GetComponent<PlayCardUI>().notPop.SetActive(false);      //禁用当前角色按钮
        }
        CurrentCharacter = PlayerList[(t + 1) % 3];
        if (CurrentCharacter == PlayerList[0])
        {
            CurrentCharacter.gameObject.GetComponent<PlayCardUI>().pop.SetActive(true);       //启用当前角色按钮
            CurrentCharacter.gameObject.GetComponent<PlayCardUI>().notPop.SetActive(true);       //启用当前角色按钮
        }
        if (BiggestCharacter == CurrentCharacter)
        {
            CurrentLength = -1;
            CurrentWeight = -1;
            CurrentType = CardType.None;
            this.GetComponent<DeskUI>().clearDesk();
        }

        //推动游戏焦点到下一个玩家、
        //CurretPlayer开始PLayCard事件
        //Playcardui: set button true
        //其他人 set button false
    }
}

