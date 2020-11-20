using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CP2CardDeal : MonoBehaviour
{
    public Sprite[] cardss = new Sprite[54];
    public int[] mycord = { 26, 14, 27, 30, 18, 31, 19, 32, 23, 36, 37 };
    public int[] cpcord = { 29, 17, 22, 35, 24, 52 };
    public GameObject player;
    public GameObject computer;

    public void selfDestroy()
    {
        player.GetComponent<Player>().CardList.Clear();
        player.GetComponent<Player>().pickedlist.Clear();
        computer.GetComponent<Player>().CardList.Clear();
        computer.GetComponent<Player>().pickedlist.Clear();
        DestroyImmediate(this.gameObject);
    }

    public void CreateCard()
    {
        player = GameObject.Find("Root/Canvas/CP2(Clone)/desk/player");
        computer = GameObject.Find("Root/Canvas/CP2(Clone)/desk/computer");
        Quaternion b = new Quaternion(0, 0, 0, 0);
        Vector3 a;
        Vector3 scale = new Vector3((float)0.75, (float)0.75, (float)0.75);
        for (int i = 0; i < 11; i++)
        {
            a = new Vector3((float)(-2.5 + 0.5 * i), (float)-4.5, 0);//起始位置（牌数-1）/ 4
            CardUI g = Instantiate(Resources.Load<CardUI>("ClubEight"), a, b);
            g.transform.parent = this.transform;
            g.GetComponent<SpriteRenderer>().sprite = cardss[mycord[10 - i]];
            g.GetComponent<SpriteRenderer>().sortingOrder = i;
            g.transform.localScale = scale;
            Card p = g.GetComponent<CardUI>().card = new Card(mycord[10 - i] % 13, mycord[10 - i] / 13, "", g);
            p.host = "player";
            p.sortOrder = i;
            g.host = player.GetComponent<Player>();
            player.GetComponent<Player>().CardList.Add(p);
        }
        for (int i = 0; i < 6; i++)
        {
            a = new Vector3((float)(-1.25 + 0.5 * i), (float)1.7, 0);//起始位置（牌数-1）/ 4
            CardUI g = Instantiate(Resources.Load<CardUI>("ClubEight"), a, b);
            g.transform.parent = this.transform;
            g.GetComponent<SpriteRenderer>().sprite = cardss[cpcord[5 - i]];
            g.GetComponent<SpriteRenderer>().sortingOrder = i;
            g.transform.localScale = scale;
            Card p;
            if (i == 0)
            {
                p = g.GetComponent<CardUI>().card = new Card(14, 5, "", g);
            }
            else
            {
                p = g.GetComponent<CardUI>().card = new Card(cpcord[5 - i] % 13, cpcord[5 - i] / 13, "", g);
            }
            g.GetComponent<CardUI>().card = p;
            p.host = "computer";
            p.sortOrder = i;
            g.host = computer.GetComponent<Player>();
            g.card = p;
            computer.GetComponent<Player>().CardList.Add(p);
        }
    }

    void Start()
    {
        Debug.Log("open2");
        CreateCard();
    }

}
