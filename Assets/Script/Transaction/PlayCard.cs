using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Const;

/// <summary>
/// 出牌器
/// 这个类是出牌器的逻辑界面
/// 主要是使用Ruler.CanPop初步判断是否合规，并且生成CardType，发送到DeskControl
/// 这个类有关的函数方法被PlayCardUI的Button激活
/// </summary>
public class PlayCard:MonoBehaviour
{
    //public Player host;
    //public DeskControl deskcontrol;
    //public PlayCardUI PCUI;
    CardType cst;
    //缺乏构造器，需要和Player,DeskControl双向绑定

    public bool FirstJudge()
    {
        List<Card> pickcard = this.GetComponent<Player>().pickedlist;
        pickcard.Sort(
            (Card a, Card b) =>
            {
                return -a.sortOrder.CompareTo(b.sortOrder);

            });
        PlayCardUI PCUI = this.GetComponent<PlayCardUI>();
        PCUI.able(pickcard);
        if (Ruler.CanPop(pickcard,out cst))
        {
            int length = pickcard.Count;
            int weight = pickcard[length/2].value;
            DeskControl dsk = this.gameObject.GetComponentInParent<DeskControl>();
            if (dsk.SecondJudge(cst,weight,length))
            {
                this.gameObject.GetComponentInParent<Sound>().PlayCardEffect(cst, weight );
                List<Card> hadc = this.GetComponent<Player>().CardList;
                for(int i = 0; i < pickcard.Count; i++)
                {
                    hadc.Remove(pickcard[i]);
                }
                dsk.ChangeStatus(cst,weight,length);
                this.gameObject.GetComponentInParent<DeskUI>().OutCard(pickcard,hadc);
                //调用changestatus
                //使用deskui把牌打出去
                return true;
            }
            else
            {
                //使用deskui给错误提示
                Debug.Log("Invalid cast.");
                return false;
            }
        }
        else
        {
            //deskui错误提示
            Debug.Log("Invalid cast 2.");
            //PCUI.unable();
            return false;
        }
        //Ruler.CanPop  使用host.pickedlist生成CardType
        // if 通过测试
        //    DeskControl.SecondJudge(CardType)
        // else
        //    激活UI显示重新选择等信息
    }



}

