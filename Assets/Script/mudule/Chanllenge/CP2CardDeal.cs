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
        player = GameObject.Find("Root/Canvas/CP2(Clone)/desk/player");
        computer = GameObject.Find("Root/Canvas/CP2(Clone)/desk/computer");
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
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(0.1f);
            a = new Vector3((float)(-1.25 + 0.5 * i), (float)1.7, 0);//起始位置（牌数-1）/ 4
            Game2CardUI g = Instantiate(Resources.Load<Game2CardUI>("CPCard"), a, b);
            g.transform.parent = this.transform;
            g.GetComponent<SpriteRenderer>().sprite = cardss[cpcord[5 - i]];
            g.GetComponent<SpriteRenderer>().sortingOrder = i;
            g.transform.localScale = scale;
            Game2Card p;
            if (i == 0)
            {
                p = g.GetComponent<Game2CardUI>().card = new Game2Card(14, 5, "", g);
            }
            else
            {
                p = g.GetComponent<Game2CardUI>().card = new Game2Card(cpcord[5 - i] % 13, cpcord[5 - i] / 13, "", g);
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
