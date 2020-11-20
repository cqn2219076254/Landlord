using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clientCards : MonoBehaviour
{
    Queue<cardData> receive = new Queue<cardData>();
    public GameObject player;
    public GameObject player2;
    public GameObject player3;
    private Queue<Card> dealcards = new Queue<Card>();
    public Sprite[] cardss = new Sprite[54];
    public void CreateCard()
    {
        Debug.Log("create");
        for (int k = 0; k < 54; k++)
        {
            CardUI f = Instantiate(Resources.Load<CardUI>("ClubEight"));
            f.transform.parent = this.transform;
            cardData cur = receive.Dequeue();
            int i = cur.color;
            int j = cur.value;
            f.GetComponent<SpriteRenderer>().sprite = cardss[13 * i + j];
            Card t = f.GetComponent<CardUI>().card = new Card(j, i, "", f);
            dealcards.Enqueue(t);
            f.gameObject.SetActive(false);
        }
    }
    public int s = 17;
    public void initcards()
    {
        Debug.Log("instantiate");
        s--;

        Card p = dealcards.Dequeue();
        p.host = "other1";
        p.UIS.GetComponent<SpriteRenderer>().sortingOrder = 16 - s;
        p.sortOrder = 16 - s;
        p.UIS.transform.position = new Vector3(6, (float)0.5 * (8 - s), 0);
        p.UIS.host = player.GetComponent<Player>();
        List<Card> tp = player.GetComponent<Player>().CardList;
        tp.Add(p);
        tp.Sort(
            (Card a, Card b) =>
            {
                return -a.value.CompareTo(b.value);
            });
        Vector3 x = new Vector3(6, -4, 0);
        Vector3 g = new Vector3(0, (float)0.5, 0);
        for (int i = 0; i < tp.Count; i++)
        {
            tp[i].UIS.GetComponent<SpriteRenderer>().sortingOrder = i;
            tp[i].sortOrder = i;
            tp[i].UIS.transform.position = x + i * g;
        }
        p.UIS.gameObject.SetActive(true);
        Card q = dealcards.Dequeue();
        q.host = "other2";
        q.UIS.transform.position = new Vector3(-6, (float)0.5 * (8 - s), 0);
        q.UIS.GetComponent<SpriteRenderer>().sortingOrder = 16 - s;
        q.sortOrder = 16 - s;
        q.UIS.host = player2.GetComponent<Player>();
        List<Card> tq = player2.GetComponent<Player>().CardList;
        tq.Add(q);
        tq.Sort(
            (Card a, Card b) =>
            {
                return -a.value.CompareTo(b.value);
            });
        Vector3 y = new Vector3(-6, -4, 0);
        for (int i = 0; i < tq.Count; i++)
        {
            tq[i].UIS.GetComponent<SpriteRenderer>().sortingOrder = i;
            tq[i].sortOrder = i;
            tq[i].UIS.transform.position = y + i * g;
        }
        q.UIS.gameObject.SetActive(true);
        Card e = dealcards.Dequeue();
        e.host = "player";
        e.UIS.transform.position = new Vector3((float)0.5 * (8 - s), -6, 0);
        e.UIS.GetComponent<SpriteRenderer>().sortingOrder = 16 - s;
        e.sortOrder = 16 - s;
        e.UIS.host = player3.GetComponent<Player>();
        List<Card> t1 = player3.GetComponent<Player>().CardList;
        t1.Add(e);
        t1.Sort(
            (Card a, Card b) =>
            {
                return -a.value.CompareTo(b.value);

            });
        Vector3 z = new Vector3(-4, -6, 0);
        Vector3 f = new Vector3((float)0.5, 0, 0);
        for (int i = 0; i < t1.Count; i++)
        {
            t1[i].UIS.GetComponent<SpriteRenderer>().sortingOrder = i;
            t1[i].sortOrder = i;
            t1[i].UIS.transform.position = z + i * f;
        }
        e.UIS.gameObject.SetActive(true);
        if (s <= 0)
        {
            /*player3.GetComponent<PlayCardUI>().pop.SetActive(true);
            player3.GetComponent<PlayCardUI>().notPop.SetActive(true);*/
            /////////////////////////////////////////////
            /*LordUI ldui = this.transform.parent.Find("Desk").GetComponent<LordModel>().currentChoice.GetComponent<LordUI>();
            ldui.call.SetActive(true);
            ldui.notCall.SetActive(true);*/
            CancelInvoke("initcards");
            //Destroy(this.gameObject);
        }
    }

    public void AddCard(Player target)
    {
        Card p1 = dealcards.Dequeue();
        Card p2 = dealcards.Dequeue();
        Card p3 = dealcards.Dequeue();
        GameObject po1 = Instantiate(p1.UIS.gameObject);
        po1.transform.position = new Vector3((float)-0.5, 0, 0);
        po1.GetComponent<SpriteRenderer>().sortingOrder = 0;
        po1.GetComponent<CardUI>().enabled = false;
        po1.SetActive(true);
        GameObject po2 = Instantiate(p2.UIS.gameObject);
        po2.transform.position = new Vector3(0, 0, 0);
        po2.GetComponent<SpriteRenderer>().sortingOrder = 1;
        po2.GetComponent<CardUI>().enabled = false;
        po2.SetActive(true);
        GameObject po3 = Instantiate(p3.UIS.gameObject);
        po3.transform.position = new Vector3((float)0.5, 0, 0);
        po3.GetComponent<SpriteRenderer>().sortingOrder = 2;
        po3.GetComponent<CardUI>().enabled = false;
        po3.SetActive(true);
        if (target == player.GetComponent<Player>())
        {
            p1.host = "other1";
            p2.host = "other1";
            p3.host = "other1";
            p1.UIS.GetComponent<SpriteRenderer>().sortingOrder = 17;
            p2.UIS.GetComponent<SpriteRenderer>().sortingOrder = 18;
            p3.UIS.GetComponent<SpriteRenderer>().sortingOrder = 19;
            p1.sortOrder = 17;
            p2.sortOrder = 18;
            p3.sortOrder = 19;
            p1.UIS.transform.position = new Vector3(6, (float)0.5 * 9, 0);
            p2.UIS.transform.position = new Vector3(6, (float)0.5 * 10, 0);
            p3.UIS.transform.position = new Vector3(6, (float)0.5 * 11, 0);
            p1.UIS.host = player.GetComponent<Player>();
            p2.UIS.host = player.GetComponent<Player>();
            p3.UIS.host = player.GetComponent<Player>();
            List<Card> tp = player.GetComponent<Player>().CardList;
            tp.Add(p1);
            tp.Add(p2);
            tp.Add(p3);
            tp.Sort(
                (Card a, Card b) =>
                {
                    return -a.value.CompareTo(b.value);
                });
            Vector3 x = new Vector3(6, -4, 0);
            Vector3 g = new Vector3(0, (float)0.5, 0);
            for (int i = 0; i < tp.Count; i++)
            {
                tp[i].UIS.GetComponent<SpriteRenderer>().sortingOrder = i;
                tp[i].sortOrder = i;
                tp[i].UIS.transform.position = x + i * g;
            }
            p1.UIS.gameObject.SetActive(true);
            p2.UIS.gameObject.SetActive(true);
            p3.UIS.gameObject.SetActive(true);
        }
        else if (target == player2.GetComponent<Player>())
        {
            p1.host = "other2";
            p2.host = "other2";
            p3.host = "other2";
            p1.UIS.transform.position = new Vector3(-6, (float)0.5 * 9, 0);
            p2.UIS.transform.position = new Vector3(-6, (float)0.5 * 10, 0);
            p3.UIS.transform.position = new Vector3(-6, (float)0.5 * 11, 0);
            p1.UIS.GetComponent<SpriteRenderer>().sortingOrder = 17;
            p2.UIS.GetComponent<SpriteRenderer>().sortingOrder = 18;
            p3.UIS.GetComponent<SpriteRenderer>().sortingOrder = 19;
            p1.sortOrder = 17;
            p2.sortOrder = 18;
            p3.sortOrder = 19;
            p1.UIS.host = player2.GetComponent<Player>();
            p2.UIS.host = player2.GetComponent<Player>();
            p3.UIS.host = player2.GetComponent<Player>();
            List<Card> tq = player2.GetComponent<Player>().CardList;
            tq.Add(p1);
            tq.Add(p2);
            tq.Add(p3);
            tq.Sort(
                (Card a, Card b) =>
                {
                    return -a.value.CompareTo(b.value);
                });
            Vector3 y = new Vector3(-6, -4, 0);
            Vector3 g = new Vector3(0, (float)0.5, 0);
            for (int i = 0; i < tq.Count; i++)
            {
                tq[i].UIS.GetComponent<SpriteRenderer>().sortingOrder = i;
                tq[i].sortOrder = i;
                tq[i].UIS.transform.position = y + i * g;
            }
            p1.UIS.gameObject.SetActive(true);
            p2.UIS.gameObject.SetActive(true);
            p3.UIS.gameObject.SetActive(true);
        }
        else
        {
            p1.host = "player";
            p2.host = "player";
            p3.host = "player";
            p1.UIS.transform.position = new Vector3((float)0.5 * (8 - s), -6, 0);
            p2.UIS.transform.position = new Vector3((float)0.5 * (8 - s), -6, 0);
            p3.UIS.transform.position = new Vector3((float)0.5 * (8 - s), -6, 0);
            p1.UIS.GetComponent<SpriteRenderer>().sortingOrder = 16 - s;
            p2.UIS.GetComponent<SpriteRenderer>().sortingOrder = 16 - s;
            p3.UIS.GetComponent<SpriteRenderer>().sortingOrder = 16 - s;
            p1.sortOrder = 16 - s;
            p2.sortOrder = 16 - s;
            p3.sortOrder = 16 - s;
            p1.UIS.host = player3.GetComponent<Player>();
            p2.UIS.host = player3.GetComponent<Player>();
            p3.UIS.host = player3.GetComponent<Player>();
            List<Card> t1 = player3.GetComponent<Player>().CardList;
            t1.Add(p1);
            t1.Add(p2);
            t1.Add(p3);
            t1.Sort(
                (Card a, Card b) =>
                {
                    return -a.value.CompareTo(b.value);

                });
            Vector3 z = new Vector3(-4, -6, 0);
            Vector3 f = new Vector3((float)0.5, 0, 0);
            for (int i = 0; i < t1.Count; i++)
            {
                t1[i].UIS.GetComponent<SpriteRenderer>().sortingOrder = i;
                t1[i].sortOrder = i;
                t1[i].UIS.transform.position = z + i * f;
            }
            p1.UIS.gameObject.SetActive(true);
            p2.UIS.gameObject.SetActive(true);
            p3.UIS.gameObject.SetActive(true);
        }
    }
}
