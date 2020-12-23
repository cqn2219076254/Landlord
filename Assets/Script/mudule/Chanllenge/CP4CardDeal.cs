using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CP4CardDeal : MonoBehaviour
{
    public Sprite[] cardss = new Sprite[54];
    public int[] mycord = { 26, 40, 1, 14, 27, 28, 29, 30, 22, 35, 36 };
    public int[] cpcord = { 13, 42, 16, 17, 45, 19, 32, 34, 48, 23, 37, 25, 38, 52 };
    public GameObject player;
    public GameObject computer;
    
    private Quaternion b = new Quaternion(0, 0, 0, 0);
    private Vector3 scale = new Vector3((float)0.75, (float)0.75, (float)0.75);
    private AudioSource Start1;

    public void selfDestroy()
    {
        player.GetComponent<Game2Player>().CardList.Clear();
        player.GetComponent<Game2Player>().pickedlist.Clear();
        computer.GetComponent<Game2Player>().CardList.Clear();
        computer.GetComponent<Game2Player>().pickedlist.Clear();
        DestroyImmediate(this.gameObject);
    }

    IEnumerator CreateCard()
    {
        player = GameObject.Find("Root/Canvas/CP4(Clone)/desk/player");
        computer = GameObject.Find("Root/Canvas/CP4(Clone)/desk/computer");
        Vector3 a;
        for (int i = 0; i < 11; i++)
        {
            yield return new WaitForSeconds(0.1f);
            a = new Vector3((float)(-2.5 + 0.5 * i), (float)-4.5, 0);//起始位置（牌数-1）/ 4
            Game2CardUI g = Instantiate(Resources.Load<Game2CardUI>("CPCard"), a, b);
            g.transform.parent = this.transform;
            g.GetComponent<SpriteRenderer>().sprite = cardss[mycord[10 - i]];
            g.GetComponent<SpriteRenderer>().sortingOrder = i;
            g.transform.localScale = scale;
            Game2Card p = g.GetComponent<Game2CardUI>().card = new Game2Card(mycord[10 - i] % 13, mycord[10 - i] / 13, "", g);
            p.host = "player";
            p.sortOrder = i;
            g.host = player.GetComponent<Game2Player>();
            player.GetComponent<Game2Player>().CardList.Add(p);
        }
        for (int i = 0; i < 13; i++)
        {
            yield return new WaitForSeconds(0.1f);
            a = new Vector3((float)(-3 + 0.5 * i), (float)1.7, 0);//起始位置（牌数-1）/ 4
            Game2CardUI g = Instantiate(Resources.Load<Game2CardUI>("CPCard"), a, b);
            g.transform.parent = this.transform;
            g.GetComponent<SpriteRenderer>().sprite = cardss[cpcord[12 - i]];
            g.GetComponent<SpriteRenderer>().sortingOrder = i;
            g.transform.localScale = scale;
            Game2Card p;
            if(i == 0)
            {
                p = g.GetComponent<Game2CardUI>().card = new Game2Card(14, 5, "", g);
            }
            else
            {
                p = g.GetComponent<Game2CardUI>().card = new Game2Card(cpcord[12 - i] % 13, cpcord[12 - i] / 13, "", g);
            }
            g.GetComponent<Game2CardUI>().card = p;
            p.host = "computer";
            p.sortOrder = i;
            g.host = computer.GetComponent<Game2Player>();
            g.card = p;
            computer.GetComponent<Game2Player>().CardList.Add(p);
        }
    }

    void Start()
    {
        Debug.Log("open2");
        StartCoroutine(CreateCard());
        StartCoroutine(Music());
    }

    IEnumerator Music()
    {
        yield return new WaitForSeconds(0);
        Start1 = gameObject.AddComponent<AudioSource>();
        AudioClip start1 = Resources.Load<AudioClip>("Sound/CPSound/start1");
        Start1.volume = 10;
        Start1.clip = start1;
        Start1.Play();
        Debug.Log("load it");
    }
}
