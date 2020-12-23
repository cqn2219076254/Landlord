using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Const;

/// <summary>
///这个类用来SecondJudge比较大小。
///接受PlayCard出牌器传来的CardType，调用RoundModel的状态信息完成判断
///成功后，更改RoundModel的状态信息，例如从CurrentPlayer访问到Pickedlist以后destroy card
///根据出牌成功失败激活DeskUI进行失败提示和成功把牌放到桌子上面
/// </summary>
public class DeskControl:MonoBehaviour
{
    //public RoundModel round;
    //public DeskUI deskUI;

    //缺乏构造器，需要双向绑定


    public bool SecondJudge(CardType cdt,int weight,int length)
    {
        Debug.Log("second judge");
        RoundModel round = this.GetComponent<RoundModel>();
        if(round.CurrentType==cdt && length==round.CurrentLength && weight > round.CurrentWeight)
        {
            return true;
        }else if (cdt == CardType.Boom && round.CurrentType != CardType.Boom)
        {
            return true;
        }else if (cdt == CardType.JokerBoom)
        {
            return true;
        }else if (round.CurrentType == CardType.None)
        {
            return true;
        }
        else
        {
            return false;
        }
        // if 成功
        //    激活CardUI显示，更改round状态ChangeStatus
        // else
        //    激活CardUI显示
    }

    public void ChangeStatus(CardType cst,int weight, int length)
    {
        RoundModel round = this.GetComponent<RoundModel>();
        round.BiggestCharacter = round.CurrentCharacter;
        round.CurrentLength = length;
        round.CurrentType = cst;
        round.CurrentWeight = weight;
        //Debug.Log(round.CurrentCharacter,)
        round.Turn();
        //这个方法访问round中的current Player,更改他的牌信息
        //更改round中其它current信息
    }
    
}