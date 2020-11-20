using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardinit : MonoBehaviour
{
    /*public GameObject right;
    public GameObject left;
    public GameObject player;
    private List<Card> allcards = new List<Card>();
    private Queue<Card> dealcards = new Queue<Card>();
    public Sprite[] cardss = new Sprite[54];
    public Sprite cardBack;*/
    public void selfDestroy()
    {
        right.GetComponent<Player>().CardList.Clear();
        right.GetComponent<Player>().pickedlist.Clear();
        left.GetComponent<Player>().CardList.Clear();
        left.GetComponent<Player>().pickedlist.Clear();
        player.GetComponent<Player>().CardList.Clear();
        player.GetComponent<Player>().pickedlist.Clear();
        DestroyImmediate(this.gameObject);
    }
    /*public void CreateCard()
    {
        Debug.Log("create");
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                CardUI f = Instantiate(Resources.Load<CardUI>("ClubEight"));
                f.transform.parent = this.transform;
                f.GetComponent<SpriteRenderer>().sprite = cardss[13 * i + j];
                Card t = f.GetComponent<CardUI>().card = new Card(j, i, "", f);
                allcards.Add(t);
                f.gameObject.SetActive(false);
            }
        }
        CardUI g = Instantiate(Resources.Load<CardUI>("ClubEight"));
        g.transform.parent = this.transform;
        g.GetComponent<SpriteRenderer>().sprite = cardss[52];
        Card y = g.GetComponent<CardUI>().card = new Card(14, 5, "", g);
        allcards.Add(y);
        g.gameObject.SetActive(false);
        CardUI e = Instantiate(Resources.Load<CardUI>("ClubEight"));
        e.transform.parent = this.transform;
        e.GetComponent<SpriteRenderer>().sprite = cardss[53];
        Card d = e.GetComponent<CardUI>().card = new Card(15, 5, "", e);
        allcards.Add(d);
        e.gameObject.SetActive(false);
    }
    public void Shuffle()
    {
        Debug.Log("shuffle");
        List<Card> shuffle = new List<Card>();
        foreach (Card crd in allcards)
        {
            int index = Random.Range(0, shuffle.Count + 1);
            shuffle.Insert(index, crd);
        }
        foreach (Card crd in shuffle)
        {
            dealcards.Enqueue(crd);
        }
        shuffle.Clear();
        allcards.Clear();
    }

    public int s = 17;
    public void initcards()
    {
        Debug.Log("instantiate");
        s--;

        Card p = dealcards.Dequeue();
        p.host = "other1";
        p.UIS.GetComponent<SpriteRenderer>().sortingOrder = 16 - s;
        p.UIS.GetComponent<SpriteRenderer>().sprite = cardBack;
        p.sortOrder = 16 - s;
        p.UIS.transform.position = new Vector3(6, (float)0.5 * (8 - s), 0);
        p.UIS.host = right.GetComponent<Player>();
        List<Card> tp = right.GetComponent<Player>().CardList;
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
        //p.UIS.gameObject.SetActive(true);
        Card q = dealcards.Dequeue();
        q.host = "other2";
        q.UIS.transform.position = new Vector3(-6, (float)0.5 * (8 - s), 0);
        q.UIS.GetComponent<SpriteRenderer>().sortingOrder = 16 - s;
        q.UIS.GetComponent<SpriteRenderer>().sprite = cardBack;
        q.sortOrder = 16 - s;
        q.UIS.host = left.GetComponent<Player>();
        List<Card> tq=left.GetComponent<Player>().CardList;
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
        //q.UIS.gameObject.SetActive(true);
        Card e = dealcards.Dequeue();
        e.host = "player";
        e.UIS.transform.position = new Vector3((float)0.5 * (8 - s), -6, 0);
        e.UIS.GetComponent<SpriteRenderer>().sortingOrder = 16 - s;
        e.sortOrder = 16 - s;
        e.UIS.host = player.GetComponent<Player>();
        List<Card> t1 = player.GetComponent<Player>().CardList;
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
            /*player.GetComponent<PlayCardUI>().pop.SetActive(true);
            player.GetComponent<PlayCardUI>().notPop.SetActive(true);
            LordUI ldui = this.transform.parent.Find("Desk").GetComponent<LordModel>().currentChoice.GetComponent<LordUI>();
            ldui.call.SetActive(true);
            ldui.notCall.SetActive(true);
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
        po1.transform.position = new Vector3((float)-0.5, 3, 0);
        po1.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        po1.GetComponent<SpriteRenderer>().sortingOrder = 0;
        //po1.GetComponent<CardUI>().enabled = false;
        Destroy(po1.GetComponent<CardUI>());
        po1.SetActive(true);
        GameObject po2 = Instantiate(p2.UIS.gameObject);
        po2.transform.position = new Vector3(0, 3, 0);
        po2.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        po2.GetComponent<SpriteRenderer>().sortingOrder = 1;
        //po2.GetComponent<CardUI>().enabled = false;
        Destroy(po2.GetComponent<CardUI>());
        po2.SetActive(true);
        GameObject po3 = Instantiate(p3.UIS.gameObject);
        po3.transform.position = new Vector3((float)0.5, 3, 0);
        po3.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        po3.GetComponent<SpriteRenderer>().sortingOrder = 2;
        //po3.GetComponent<CardUI>().enabled = false;
        Destroy(po3.GetComponent<CardUI>());
        po3.SetActive(true);
        if (target == right.GetComponent<Player>())
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
            p1.UIS.host = right.GetComponent<Player>();
            p2.UIS.host = right.GetComponent<Player>();
            p3.UIS.host = right.GetComponent<Player>();
            List<Card> tp = right.GetComponent<Player>().CardList;
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
            //p1.UIS.gameObject.SetActive(true);
            //p2.UIS.gameObject.SetActive(true);
            //p3.UIS.gameObject.SetActive(true);
        }
        else if (target == left.GetComponent<Player>())
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
            p1.UIS.host = left.GetComponent<Player>();
            p2.UIS.host = left.GetComponent<Player>();
            p3.UIS.host = left.GetComponent<Player>();
            List<Card> tq = left.GetComponent<Player>().CardList;
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
            //p1.UIS.gameObject.SetActive(true);
            //p2.UIS.gameObject.SetActive(true);
            //p3.UIS.gameObject.SetActive(true);
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
            p1.UIS.host = player.GetComponent<Player>();
            p2.UIS.host = player.GetComponent<Player>();
            p3.UIS.host = player.GetComponent<Player>();
            List<Card> t1 = player.GetComponent<Player>().CardList;
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
    public void Start()
    {
        Debug.Log("start");
        right = this.transform.parent.Find("Desk").Find("right").gameObject;
        left = this.transform.parent.Find("Desk").Find("left").gameObject;
        player = this.transform.parent.Find("Desk").Find("player").gameObject;
        CreateCard();
        Shuffle();
        InvokeRepeating("initcards", (float)1, (float)0.1);
    }*/
    public GameObject right;
    public GameObject left;
    public GameObject player;
    private List<Card> allcards = new List<Card>();
    private Queue<Card> dealcardst = new Queue<Card>();
    public Sprite[] cardss = new Sprite[54];
    public Sprite cardBack;
    public int s = 17;
    public string[] dealcards = { "1", "1", "2", "1", "3", "1", "4", "1", "5", "1", "6", "1", "7", "1", "8", "1", "9", "1", "10", "1", "11", "1", "12", "1", "14", "5", "15", "5", "1", "2", "2", "2", "3", "2", "4", "2", "5", "2", "6", "2" };
    public void CreateCard(string[] dealcards)
    {
        for (int i = 0; i < 20; i++)
        {
            CardUI f = Instantiate(Resources.Load<CardUI>("ClubEight"));
            f.transform.parent = this.transform;
            int value = int.Parse(dealcards[2 * i]);
            int color = int.Parse(dealcards[2 * i + 1]);
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
            g.GetComponent<SpriteRenderer>().sprite = cardBack;
            g.GetComponent<SpriteRenderer>().flipX = true;
            Card d = g.GetComponent<CardUI>().card = new Card(-1, -1, "", g);
            g.gameObject.SetActive(false);
            CardUI asd = Instantiate(Resources.Load<CardUI>("ClubEight"));
            asd.transform.parent = this.transform;
            asd.GetComponent<SpriteRenderer>().sprite = cardBack;
            Card sd = asd.GetComponent<CardUI>().card = new Card(-1, -1, "", asd);
            asd.gameObject.SetActive(false);
            Card t = f.GetComponent<CardUI>().card = new Card(value, color, "", f);
            if (i < 17)
            {
                dealcardst.Enqueue(d);
                dealcardst.Enqueue(sd);
            }
            dealcardst.Enqueue(t);
            f.gameObject.SetActive(false);
        }
    }
    public void initcards()
    {
        Debug.Log("instantiate");
        s--;
        Card p = dealcardst.Dequeue();
        p.host = "other1";
        p.UIS.GetComponent<SpriteRenderer>().sortingOrder = 16 - s;
        p.UIS.GetComponent<SpriteRenderer>().sprite = cardBack;
        p.sortOrder = 16 - s;
        p.UIS.transform.position = new Vector3(6, (float)0.5 * (8 - s), 0);
        p.UIS.host = right.GetComponent<Player>();
        List<Card> tp = right.GetComponent<Player>().CardList;
        tp.Add(p);
        tp.Sort(
            (Card a, Card b) =>
            {
                return -a.value.CompareTo(b.value);
            });
        Vector3 x = new Vector3(6, -2, 0);
        Vector3 g = new Vector3((float)-0.08, (float)0.1, 0);
        for (int i = 0; i < tp.Count; i++)
        {
            tp[i].UIS.GetComponent<SpriteRenderer>().sortingOrder = i;
            tp[i].sortOrder = i;
            tp[i].UIS.transform.position = x + i * g;
        }
        p.UIS.gameObject.SetActive(true);
        Card q = dealcardst.Dequeue();
        q.host = "other2";
        q.UIS.transform.position = new Vector3(-6, (float)0.5 * (8 - s), 0);
        q.UIS.GetComponent<SpriteRenderer>().sortingOrder = 16 - s;
        q.UIS.GetComponent<SpriteRenderer>().sprite = cardBack;
        q.sortOrder = 16 - s;
        q.UIS.host = left.GetComponent<Player>();
        List<Card> tq = left.GetComponent<Player>().CardList;
        tq.Add(q);
        tq.Sort(
            (Card a, Card b) =>
            {
                return -a.value.CompareTo(b.value);
            });
        Vector3 y = new Vector3(-6, -2, 0);
        Vector3 gs = new Vector3((float)0.08, (float)0.1, 0);
        for (int i = 0; i < tq.Count; i++)
        {
            tq[i].UIS.GetComponent<SpriteRenderer>().sortingOrder = i;
            tq[i].sortOrder = i;
            tq[i].UIS.transform.position = y + i * gs;
        }
        q.UIS.gameObject.SetActive(true);
        Card e = dealcardst.Dequeue();
        e.host = "player";
        e.UIS.transform.position = new Vector3((float)0.5 * (8 - s), -6, 0);
        e.UIS.GetComponent<SpriteRenderer>().sortingOrder = 16 - s;
        e.sortOrder = 16 - s;
        e.UIS.host = player.GetComponent<Player>();
        List<Card> t1 = player.GetComponent<Player>().CardList;
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
            LordUI ldui = this.transform.parent.Find("Desk").GetComponent<LordModel>().currentChoice.GetComponent<LordUI>();
            if (this.transform.parent.Find("Desk").GetComponent<LordModel>().currentChoice == player.GetComponent<Player>())
            {
                ldui.call.SetActive(true);
                ldui.notCall.SetActive(true);
            }
            CancelInvoke("initcards");
            //Destroy(this.gameObject);
        }
    }
    public void AddCard(Player target)
    {
        Card p1 = dealcardst.Dequeue();
        Card p2 = dealcardst.Dequeue();
        Card p3 = dealcardst.Dequeue();
        GameObject po1 = Instantiate(p1.UIS.gameObject);
        po1.transform.position = new Vector3((float)-0.5, 3, 0);
        po1.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        po1.GetComponent<SpriteRenderer>().sortingOrder = 0;
        //po1.GetComponent<CardUI>().enabled = false;
        po1.SetActive(true);
        Destroy(po1.GetComponent<CardUI>());
        GameObject po2 = Instantiate(p2.UIS.gameObject);
        po2.transform.position = new Vector3(0, 3, 0);
        po2.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        po2.GetComponent<SpriteRenderer>().sortingOrder = 1;
        //po2.GetComponent<CardUI>().enabled = false;
        po2.SetActive(true);
        Destroy(po2.GetComponent<CardUI>());
        GameObject po3 = Instantiate(p3.UIS.gameObject);
        po3.transform.position = new Vector3((float)0.5, 3, 0);
        po3.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        po3.GetComponent<SpriteRenderer>().sortingOrder = 2;
        //po3.GetComponent<CardUI>().enabled = false;
        po3.SetActive(true);
        Destroy(po3.GetComponent<CardUI>());
        if (target == right.GetComponent<Player>())
        {
            p1.host = "other1";
            p2.host = "other1";
            p3.host = "other1";
            p1.UIS.GetComponent<SpriteRenderer>().sortingOrder = 17;
            p2.UIS.GetComponent<SpriteRenderer>().sortingOrder = 18;
            p3.UIS.GetComponent<SpriteRenderer>().sortingOrder = 19;
            p1.UIS.GetComponent<SpriteRenderer>().sprite = cardBack;
            p2.UIS.GetComponent<SpriteRenderer>().sprite = cardBack;
            p3.UIS.GetComponent<SpriteRenderer>().sprite = cardBack;
            p1.sortOrder = 17;
            p2.sortOrder = 18;
            p3.sortOrder = 19;
            p1.UIS.transform.position = new Vector3(6, (float)0.5 * 9, 0);
            p2.UIS.transform.position = new Vector3(6, (float)0.5 * 10, 0);
            p3.UIS.transform.position = new Vector3(6, (float)0.5 * 11, 0);
            p1.UIS.host = right.GetComponent<Player>();
            p2.UIS.host = right.GetComponent<Player>();
            p3.UIS.host = right.GetComponent<Player>();
            List<Card> tp = right.GetComponent<Player>().CardList;
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
            /*p1.UIS.gameObject.SetActive(true);
            p2.UIS.gameObject.SetActive(true);
            p3.UIS.gameObject.SetActive(true);*/
        }
        else if (target == left.GetComponent<Player>())
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
            p1.UIS.GetComponent<SpriteRenderer>().sprite = cardBack;
            p2.UIS.GetComponent<SpriteRenderer>().sprite = cardBack;
            p3.UIS.GetComponent<SpriteRenderer>().sprite = cardBack;
            p1.sortOrder = 17;
            p2.sortOrder = 18;
            p3.sortOrder = 19;
            p1.UIS.host = left.GetComponent<Player>();
            p2.UIS.host = left.GetComponent<Player>();
            p3.UIS.host = left.GetComponent<Player>();
            List<Card> tq = left.GetComponent<Player>().CardList;
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
            /*p1.UIS.gameObject.SetActive(true);
            p2.UIS.gameObject.SetActive(true);
            p3.UIS.gameObject.SetActive(true);*/
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
            p1.UIS.host = player.GetComponent<Player>();
            p2.UIS.host = player.GetComponent<Player>();
            p3.UIS.host = player.GetComponent<Player>();
            List<Card> t1 = player.GetComponent<Player>().CardList;
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
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        right = this.transform.parent.Find("Desk").Find("right").gameObject;
        left = this.transform.parent.Find("Desk").Find("left").gameObject;
        player = this.transform.parent.Find("Desk").Find("player").gameObject;
        CreateCard(dealcards);
        InvokeRepeating("initcards", (float)1, (float)0.1);
    }
}
