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
        player = GameObject.Find("Root/Canvas/CP3(Clone)/desk/player");
        computer = GameObject.Find("Root/Canvas/CP3(Clone)/desk/computer");
        Vector3 a;
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.1f);
            a = new Vector3((float)(-2.25 + 0.5 * i), (float)-4.5, 0);//起始位置（牌数-1）/ 4
            Game2CardUI g = Instantiate(Resources.Load<Game2CardUI>("CPCard"), a, b);
            g.transform.parent = this.transform;
            g.GetComponent<SpriteRenderer>().sprite = cardss[mycord[9 - i]];
            g.GetComponent<SpriteRenderer>().sortingOrder = i;
            g.transform.localScale = scale;
            Game2Card p = g.GetComponent<Game2CardUI>().card = new Game2Card(mycord[9 - i] % 13, mycord[9 - i] / 13, "", g);
            p.host = "player";
            p.sortOrder = i;
            g.host = player.GetComponent<Game2Player>();
            player.GetComponent<Game2Player>().CardList.Add(p);
        }
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.1f);
            a = new Vector3((float)(-0.75 + 0.5 * i), (float)1.7, 0);//起始位置（牌数-1）/ 4
            Game2CardUI g = Instantiate(Resources.Load<Game2CardUI>("CPCard"), a, b);
            g.transform.parent = this.transform;
            g.GetComponent<SpriteRenderer>().sprite = cardss[cpcord[3 - i]];
            g.GetComponent<SpriteRenderer>().sortingOrder = i;
            g.transform.localScale = scale;
            Game2Card p = g.GetComponent<Game2CardUI>().card = new Game2Card(cpcord[3 - i] % 13, cpcord[3 - i] / 13, "", g);
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
