using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Const;

/// <summary>
/// 这个类用于出牌显示
/// 例如牌打到桌子上面，牌不对的时候的失败提示
/// </summary>
public class DeskUI : MonoBehaviour
{
    public GameObject player;
    public GameObject oppesite1;
    public GameObject oppesite2;
    public List<Card> displayCard = new List<Card>();

    public void OutCard(List<Card> cards, List<Card> hadCards)
    {
        this.clearDesk();
        Vector3 z = new Vector3(0, 0, 0);
        if (cards[0].host.Equals("player"))
        {
            z = new Vector3((float)(-0.5 * cards.Count / 2.0), (float)-3.5, 0);
            Vector3 zs = new Vector3((float)(-0.5 * hadCards.Count / 2.0), -6, 0);
            Vector3 f = new Vector3((float)0.5, 0, 0);
            cards.Reverse();
            Debug.Log("done");
            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].UIS.transform.position = z + i * f;
                cards[i].host = "";
                displayCard.Add(cards[i]);
            }
            cards.Clear();
            for (int i = 0; i < hadCards.Count; i++)
            {
                hadCards[i].UIS.transform.position = zs + i * f;
            }
        }
        else if (cards[0].host.Equals("other1"))
        {
            z = new Vector3(4 - (float)0.5 * cards.Count, 3, 0);
            Vector3 zs = new Vector3(6, (float)(-0.5 * hadCards.Count / 2.0), 0);
            Vector3 f = new Vector3(0, (float)0.5, 0);
            Vector3 t = new Vector3((float)0.5, 0, 0);
            cards.Reverse();
            Debug.Log("done");
            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].UIS.transform.position = z + i * t;
                cards[i].host = "";
                displayCard.Add(cards[i]);
            }
            cards.Clear();
            for (int i = 0; i < hadCards.Count; i++)
            {
                hadCards[i].UIS.transform.position = zs + i * f;
            }
        }
        else
        {
            z = new Vector3(-4, 3, 0);
            Vector3 zs = new Vector3(-6, (float)(-0.5 * hadCards.Count / 2.0), 0);
            Vector3 f = new Vector3(0, (float)0.5, 0);
            Vector3 t = new Vector3((float)0.5, 0, 0);
            cards.Reverse();
            Debug.Log("done");
            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].UIS.transform.position = z + i * t;
                cards[i].host = "";
                displayCard.Add(cards[i]);
            }
            cards.Clear();
            for (int i = 0; i < hadCards.Count; i++)
            {
                hadCards[i].UIS.transform.position = zs + i * f;
            }
        }
        Debug.Log(hadCards.Count);
    }
    public void clearDesk()
    {
        if (displayCard.Count != 0)
        {
            for (int i = 0; i < displayCard.Count; i++)
            {
                displayCard[i].UIS.gameObject.SetActive(false);
            }
            displayCard.Clear();
        }
    }
    //outcard
    //通过pickedlist 里面的card访问到对应cardui
    //1. 把原有的cardui set active false
    //2. 更改新打出牌的transform
    //3. 要把原有手牌的空位补上
    /*
     public void showOtherCard(List<Card> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            CardUI f = Instantiate(Resources.Load<CardUI>("ClubEight"));
            f.transform.parent = this.transform;
            if (cards[i].color < 5)
            {
                f.GetComponent<SpriteRenderer>().sprite = cardss[13 * cards[i].color + cards[i].value];
            }
            else
            {
                if (cards[i].value == 14)
                {
                    f.GetComponent<SpriteRenderer>().sprite = cardss[52];
                }
                else
                {
                    f.GetComponent<SpriteRenderer>().sprite = cardss[53];
                }
            }
            f.GetComponent<CardUI>().card = cards[i];
            cards[i].UIS = f.GetComponent<CardUI>();
            f.gameObject.SetActive(false);
        }
        if (cards[0].host.Equals("Left"))
        {
            Vector3 z = new Vector3(-4, 3, 0);
            Vector3 f = new Vector3((float)0.5, 0, 0);
            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].UIS.transform.position = z + i * f;
                cards[i].host = "";
                displayCard.Add(cards[i]);
            }
        }
        if (cards[0].host.Equals("Right"))
        {
            Vector3 z = new Vector3(4 - (float)0.5 * cards.Count, 3, 0);
            Vector3 f = new Vector3((float)0.5, 0, 0);
            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].UIS.transform.position = z + i * f;
                cards[i].host = "";
                displayCard.Add(cards[i]);
            }
        }
    }

    public void showMyCard(List<Card> cards)
    {
        this.clearDesk();
        Vector3 z = new Vector3(0, 0, 0);
        z = new Vector3((float)(-0.5 * cards.Count / 2.0), (float)-3.5, 0);
        //Vector3 zs = new Vector3((float)(-0.5 * hadCards.Count / 2.0), -6, 0);
        Vector3 f = new Vector3((float)0.5, 0, 0);
        cards.Reverse();
        Debug.Log("done");
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].UIS.transform.position = z + i * f;
            cards[i].host = "";
            displayCard.Add(cards[i]);
        }
        cards.Clear();
    }

    public void updateHasCard(List<Card> hadCards)
    {
        Vector3 zs = new Vector3((float)(-0.5 * hadCards.Count / 2.0), -6, 0);
        Vector3 f = new Vector3((float)0.5, 0, 0);
        for (int i = 0; i < hadCards.Count; i++)
        {
            hadCards[i].UIS.transform.position = zs + i * f;
        }
    }*/
}

