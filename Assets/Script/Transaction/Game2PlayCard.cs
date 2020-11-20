using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using static Const;

public class Game2PlayCard : MonoBehaviour
{
    CardType cst;
    List<Card> pickcard;

    public void FirstJudge()
    {
        pickcard = this.GetComponent<Player>().pickedlist;
        Debug.Log(pickcard);
        pickcard.Sort(
            (Card a, Card b) =>
            {
                return -a.sortOrder.CompareTo(b.sortOrder);

            });
        Game2PlayCardUI PCUI = this.GetComponent<Game2PlayCardUI>();
        PCUI.able(pickcard);
        if (Ruler.CanPop(pickcard, out cst))
        {
            int length = pickcard.Count;
            int weight = pickcard[length / 2].value;
            //DeskControl dsk = this.gameObject.GetComponentInParent<DeskControl>();
            if (SecondJudge(cst, weight, length))
            {
                List<Card> hadc = this.GetComponent<Player>().CardList;
                for (int i = 0; i < pickcard.Count; i++)
                {
                    hadc.Remove(pickcard[i]);
                }
                this.gameObject.GetComponentInParent<Game2DeskUI>().updateHasCard(hadc);
                this.gameObject.GetComponentInParent<Game2DeskUI>().showMyCard(pickcard);
                ChangeStatus(cst, weight, length);
                //调用changestatus
                //使用deskui把牌打出去
            }
            else
            {
                //使用deskui给错误提示
                Debug.Log("Invalid cast.");
                if (pickcard.Count > 0)
                {
                    CancelPick();
                }
            }
        }
        else
        {
            //deskui错误提示
            Debug.Log("Invalid cast 2.");
            if (pickcard.Count > 0)
            {
                CancelPick();
            }
        }
    }

    public bool SecondJudge(CardType cdt, int weight, int length)
    {
        Debug.Log("second judge");
        Game2RoundModel round = this.gameObject.GetComponentInParent<Game2RoundModel>();
        Debug.Log(round);
        if (round.CurrentType == cdt && length == round.CurrentLength && weight > round.CurrentWeight)
        {
            return true;
        }
        else if (cdt == CardType.Boom && round.CurrentType != CardType.Boom)
        {
            return true;
        }
        else if (cdt == CardType.JokerBoom)
        {
            return true;
        }
        else if (round.CurrentType == CardType.None)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ChangeStatus(CardType cst, int weight, int length)
    {
        Debug.Log("ChangeStatus");
        Game2RoundModel round = this.gameObject.GetComponentInParent<Game2RoundModel>();
        round.BiggestCharacter = round.CurrentCharacter;
        round.CurrentLength = length;
        round.CurrentType = cst;
        round.CurrentWeight = weight;
        round.Turn();
    }

    public void CancelPick()
    {
        int count = pickcard.Count;
        if (pickcard[0].host.Equals("player"))
        {
            for (int i = 0; i < count; i++)
            {
                pickcard[0].picked = false;
                pickcard[0].UIS.transform.position -= (float)0.5 * Vector3.up;
                pickcard.Remove(pickcard[0]);
            }
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                pickcard[0].picked = false;
                pickcard.Remove(pickcard[0]);
            }
        }
    }
}