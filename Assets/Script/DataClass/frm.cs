using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class frm : MonoBehaviour
{
    // Start is called before the first frame update
    Player currentPlayer;
    Player[] players;
    Text[] texts;
    public Card cardff;
    
    public int firstP;
    List<Card> cards = new List<Card>();
    //Queue<Card> dealCards = new Queue<Card>();
    Sprite[] cardss;
    private int dCount = 44;
    public string[] recvCard;

    private int end;
    private void Awake()
    {
        players = this.GetComponentsInChildren<Player>();
        texts = this.GetComponentsInChildren<Text>();
    }
    public void setCards()
    {
        cardss = this.transform.parent.Find("fishingInit(Clone)").GetComponent<fCardInit>().cardss;
        Text t = this.transform.parent.Find("leftCards").GetComponent<Text>();
        t.text = string.Format("{0:d2}", dCount);
    }
    public void givePlayerCard()
    {
        if (dCount > 0)
        {
            dCount--;
            if (currentPlayer == players[1])
            {
                Card dCard = new Card(int.Parse(recvCard[0]),int.Parse(recvCard[1]),"",null);
                //currentPlayer.CardList.Add(dCard);
                CardUI f = Instantiate(Resources.Load<CardUI>("ClubEight"));
                f.transform.parent = this.transform;
                if (dCard.color < 5)
                {
                    f.GetComponent<SpriteRenderer>().sprite = cardss[13 * dCard.color + dCard.value];
                }
                else
                {
                    if (dCard.value == 14)
                    {
                        f.GetComponent<SpriteRenderer>().sprite = cardss[52];

                    }
                    else
                    {
                        f.GetComponent<SpriteRenderer>().sprite = cardss[53];

                    }
                }
                dCard.UIS = f;
                dCard.host = "player";
                f.card = dCard;
                f.gameObject.SetActive(false);
                dCard.UIS.GetComponent<SpriteRenderer>().sortingOrder = 4;
                dCard.sortOrder = 4;
                dCard.UIS.transform.position = new Vector3((float)0.5 * 8, 6, 0);
                dCard.UIS.host = currentPlayer.GetComponent<Player>();
                List<Card> ts = currentPlayer.GetComponent<Player>().CardList;
                Debug.Log(ts.Count + "test");
                ts.Add(dCard);
                ts.Sort(
                    (Card a, Card b) =>
                    {
                        return -a.value.CompareTo(b.value);
                    });
                Vector3 x = new Vector3(-4, -4, 0);
                Vector3 g = new Vector3((float)0.5, 0, 0);
                for (int i = 0; i < ts.Count; i++)
                {
                    ts[i].UIS.GetComponent<SpriteRenderer>().sortingOrder = i;
                    ts[i].sortOrder = i;
                    ts[i].UIS.transform.position = x + i * g;
                }
                dCard.UIS.gameObject.SetActive(true);
            }
            Text t = this.transform.parent.Find("leftCards").GetComponent<Text>();
            t.text = string.Format("{0:d2}", dCount);
        }
        else
        {
            
        }
    }
    public void turn()
    {
        currentPlayer.GetComponent<PlayCardUIF>().pop.SetActive(false);
        firstP = (firstP + 1) % 2;
        currentPlayer = players[firstP];
        if (players[0].CardList.Count!=0||players[1].CardList.Count!=0)
        {
            if (currentPlayer==players[1])
            {
                currentPlayer.GetComponent<PlayCardUIF>().pop.SetActive(true);
            }
        }
    }
    public void inStart()
    {
        currentPlayer = players[firstP];
    }
    public void fishCard()
    {
        for(int i = 0; i < cards.Count-1; i++)
        {
            if (cards[i].value == cardff.value||cards[i].color==5&&cardff.color==5)
            {
                Debug.Log("currentPlayerInner"+firstP);
                Debug.Log("number"+i);
                //player 加牌
                currentPlayer.intergal += cards.Count - i;
                int y = cards.Count;
                for(int j = 0; j < y-i; j++)
                {
                    Card p = cards[i];
                    p.UIS.gameObject.SetActive(false);
                    Debug.Log(cards.Count+""+p.UIS.gameObject.name);
                    Debug.Log(p.value + "sp" + p.color);
                    cards.Remove(cards[i]);
                    Debug.Log(cards.Count);
                }
                break;
            }
        }
        texts[3].text = string.Format("{0:d2}", players[0].intergal);
        texts[4].text = string.Format("{0:d2}", players[1].intergal);
        //givePlayerCard();
        turn();
    }
    public void showCard(Card card)
    {
        Vector3 init = new Vector3(-5, 0, 0);
        Vector3 f = new Vector3((float)0.5, 0, 0);
        GameObject g = Instantiate(Resources.Load<GameObject>("ClubEight"));
        g.transform.SetParent(GameObject.Find("Root/Canvas/FishPrefab(Clone)").transform);
        g.GetComponent<SpriteRenderer>().sortingOrder = cards.Count;
        cards.Add(card);
        card.UIS = g.GetComponent<CardUI>();
        g.transform.position = init + cards.Count * f;
        if (card.color < 5)
        {
            g.GetComponent<SpriteRenderer>().sprite = cardss[13 * card.color + card.value];
        }
        else
        {
            if (card.value == 14)
            {
                g.GetComponent<SpriteRenderer>().sprite = cardss[52];

            }
            else
            {
                g.GetComponent<SpriteRenderer>().sprite = cardss[53];

            }
        }
        g.SetActive(true);
    }
    public void process(Card card)
    {
        if (dCount == 0)
        {
            if (players[0].intergal > players[1].intergal)
            {
                end = 2;
            }
            else
            {
                end = 1;
            }
            StartCoroutine(EndGame());
        }
        cardff = card;
        showCard(card);
        givePlayerCard();
        currentPlayer.GetComponent<PlayCardUIF>().pop.SetActive(false);
        Debug.Log("currentPlayerOuter"+firstP);
        Invoke("fishCard", (float)1.5);
    }
    
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1f);
        if (end == 1)
        {
            GameObject.Find("Root/Canvas/FishPrefab(Clone)/board2").GetComponent<ServerInterface>().RemoveListener();
            DestroyImmediate(this.transform.parent.parent.gameObject);
            PanelManager.Open<FishS1Panel>();
        }
        else if (end == 2)
        {
            GameObject.Find("Root/Canvas/FishPrefab(Clone)/board2").GetComponent<ServerInterface>().RemoveListener();
            DestroyImmediate(this.transform.parent.parent.gameObject);
            PanelManager.Open<FishS2Panel>();
        }
    }
}
