using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fCardInit : MonoBehaviour
{
    public GameObject player;
    public GameObject player2;
    private List<Card> allcards = new List<Card>();
    public Queue<Card> dealcards = new Queue<Card>();
    public Sprite[] cardss = new Sprite[54];
    public Sprite cardback;
    public string[] fishDeal;
    public void selfDestroy()
    {
        player.GetComponent<Player>().CardList.Clear();
        player.GetComponent<Player>().pickedlist.Clear();
        player2.GetComponent<Player>().CardList.Clear();
        player2.GetComponent<Player>().pickedlist.Clear();
        DestroyImmediate(this.gameObject);
    }
    public void CreateCard2(string[] fishDeal)
    {
        Debug.Log("create");
        for (int i = 0; i < 5; i++)
        {
            CardUI f = Instantiate(Resources.Load<CardUI>("ClubEight"));
            f.transform.parent = this.transform;
            int value = int.Parse(fishDeal[2 * i]);
            int color = int.Parse(fishDeal[2 * i + 1]);
            if (color < 5)
            {
                f.GetComponent<SpriteRenderer>().sprite = cardss[13 * color + value];
            }
            else
            {
                if (value == 14)
                {
                    f.GetComponent<SpriteRenderer>().sprite = cardss[52];
                }
                else
                {
                    f.GetComponent<SpriteRenderer>().sprite = cardss[53];
                }
            }
            CardUI g = Instantiate(Resources.Load<CardUI>("ClubEight"));
            g.transform.parent = this.transform;
            g.GetComponent<SpriteRenderer>().sprite = cardback;
            Card d = g.GetComponent<CardUI>().card = new Card(-1, -1, "", g);
            g.gameObject.SetActive(false);
            Card t = f.GetComponent<CardUI>().card = new Card(value, color, "", f);
            f.gameObject.SetActive(false);
            dealcards.Enqueue(t);
            dealcards.Enqueue(d);
        }
    }

    public int s = 5;
    public void initcards2()
    {
        Debug.Log("instantiate"+s);
        s--;

        Card p = dealcards.Dequeue();
        p.host = "player";
        p.UIS.GetComponent<SpriteRenderer>().sortingOrder = 4 - s;
        p.sortOrder = 4 - s;
        p.UIS.transform.position = new Vector3((float)0.5 * (8 - s), -6, 0);
        p.UIS.host = player.GetComponent<Player>();
        List<Card> tp = player.GetComponent<Player>().CardList;
        tp.Add(p);
        tp.Sort(
            (Card a, Card b) =>
            {
                return -a.value.CompareTo(b.value);
            });
        Vector3 z = new Vector3(-4, -4, 0);
        Vector3 f = new Vector3((float)0.5, 0, 0);
        for (int i = 0; i < tp.Count; i++)
        {
            tp[i].UIS.GetComponent<SpriteRenderer>().sortingOrder = i;
            tp[i].sortOrder = i;
            tp[i].UIS.transform.position = z + i * f;
        }
        p.UIS.gameObject.SetActive(true);
        Card q = dealcards.Dequeue();
        q.host = "opposite";
        q.UIS.GetComponent<SpriteRenderer>().sortingOrder = 4 - s;
        q.sortOrder = 4 - s;
        q.UIS.transform.position = new Vector3((float)0.5 * (8 - s), 6, 0);
        q.UIS.host = player2.GetComponent<Player>();
        List<Card> ts = player2.GetComponent<Player>().CardList;
        ts.Add(q);
        ts.Sort(
            (Card a, Card b) =>
            {
                return -a.value.CompareTo(b.value);
            });
        Vector3 x = new Vector3(-4, 4, 0);
        Vector3 g = new Vector3((float)0.5, 0, 0);
        for (int i = 0; i < tp.Count; i++)
        {
            ts[i].UIS.GetComponent<SpriteRenderer>().sortingOrder = i;
            ts[i].sortOrder = i;
            ts[i].UIS.transform.position = x + i * g;
        }
        q.UIS.gameObject.SetActive(true);
        if (s <= 0)
        {
            CancelInvoke("initcards2");
            this.transform.parent.Find("Desk2").GetComponent<frm>().setCards();
            this.transform.parent.Find("Desk2").GetComponent<frm>().inStart();
            if (this.transform.parent.Find("Desk2").GetComponent<frm>().firstP == 1)
            {
                this.transform.parent.Find("Desk2").Find("me").GetComponent<PlayCardUIF>().pop.SetActive(true);
            }
        }
    }
    public void Start()
    {
        Debug.Log("start");
        player = this.transform.parent.Find("Desk2").Find("me").gameObject;
        player2 = this.transform.parent.Find("Desk2").Find("opposite").gameObject;
        CreateCard2(fishDeal);
        InvokeRepeating("initcards2", (float)1, (float)0.1);
    }
}
