using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CP3CardDeal : MonoBehaviour
{
    public Sprite[] cardss = new Sprite[54];
    public int[] mycord = { 13, 26, 15, 28, 29, 17, 30, 34, 36, 38};
    public int[] cpcord = { 20, 33, 35, 37 };
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
        player = GameObject.Find("Root/Canvas/CP3(Clone)/desk/player");
        computer = GameObject.Find("Root/Canvas/CP3(Clone)/desk/computer");
        Quaternion b = new Quaternion(0, 0, 0, 0);
        Vector3 a;
        Vector3 scale = new Vector3((float)0.75, (float)0.75, (float)0.75);
        for (int i = 0; i < 10; i++)
        {
            a = new Vector3((float)(-2.25 + 0.5 * i), (float)-4.5, 0);//起始位置（牌数-1）/ 4
            CardUI g = Instantiate(Resources.Load<CardUI>("ClubEight"), a, b);
            g.transform.parent = this.transform;
            g.GetComponent<SpriteRenderer>().sprite = cardss[mycord[9 - i]];
            g.GetComponent<SpriteRenderer>().sortingOrder = i;
            g.transform.localScale = scale;
            Card p = g.GetComponent<CardUI>().card = new Card(mycord[9 - i] % 13, mycord[9 - i] / 13, "", g);
            p.host = "player";
            p.sortOrder = i;
            g.host = player.GetComponent<Player>();
            player.GetComponent<Player>().CardList.Add(p);
        }
        for (int i = 0; i < 4; i++)
        {
            a = new Vector3((float)(-0.75 + 0.5 * i), (float)1.7, 0);//起始位置（牌数-1）/ 4
            CardUI g = Instantiate(Resources.Load<CardUI>("ClubEight"), a, b);
            g.transform.parent = this.transform;
            g.GetComponent<SpriteRenderer>().sprite = cardss[cpcord[3 - i]];
            g.GetComponent<SpriteRenderer>().sortingOrder = i;
            g.transform.localScale = scale;
            Card p = g.GetComponent<CardUI>().card = new Card(cpcord[3 - i] % 13, cpcord[3 - i] / 13, "", g);
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
