using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Const;

public class Sound : MonoBehaviour
{
    public AudioSource BG;
    public AudioSource Effect;
    public static string rscdir = "Sound/";
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("sound start");
        BG = gameObject.AddComponent<AudioSource>();
        Effect = gameObject.AddComponent<AudioSource>();
        BG.loop = true;
        BG.volume = 0.25f;
        AudioClip clip = Resources.Load<AudioClip>(rscdir + Const.Bg);
        BG.clip = clip;
        BG.Play();
        Effect.volume = 1.75f;
        //PlayEffect("9");
    }

    public void stopBG()
    {
        BG.Stop();
    }

    public void PlayEffect(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>(rscdir + name);
        Effect.PlayOneShot(clip);
    }

    public void PlayCardEffect(CardType e, int weight)
    {
        string name = "win";
        switch (e)
        {
            case CardType.None:
                break;
            case CardType.Single:
                Debug.Log("weight:" + weight);
                if (weight == 14)//小王修正
                    weight = 13;
                if (weight == 15)//大王修正
                    weight = 14;
                name = Const.Single[weight];
                break;
            case CardType.Double:
                name = Const.Double[weight];
                break;
            case CardType.Straight:
                name = Const.Straight;
                break;
            case CardType.DoubleStraight:
                name = Const.DoubleStraight;
                break;
            case CardType.TripleStraight:
                name = Const.TripleStraight;
                GameObject fly = Instantiate(Resources.Load<GameObject>("FlyEffect"));
                fly.transform.SetParent(GameObject.Find("Root/Canvas").transform);
                fly.GetComponent<SpriteRenderer>().sortingOrder = 10;
                fly.transform.localScale = new Vector3(1,1,1);
                break;
            case CardType.Three:
                GameObject bomb = Instantiate(Resources.Load<GameObject>("BombEffect"));
                bomb.transform.SetParent(GameObject.Find("Root/Canvas").transform);
                bomb.GetComponent<SpriteRenderer>().sortingOrder = 10;
                bomb.transform.localScale = new Vector3(1,1,1);
                name = Const.Three;
                break;
            case CardType.ThreeAndOne:
                name = Const.ThreeAndOne;
                break;
            case CardType.ThreeAndTwo:
                name = Const.ThreeAndTwo;
                break;
            case CardType.Boom:
                name = Const.Boom;
                GameObject bomb2 = Instantiate(Resources.Load<GameObject>("BombEffect"));
                bomb2.transform.SetParent(GameObject.Find("Root/Canvas").transform);
                bomb2.GetComponent<SpriteRenderer>().sortingOrder = 10;
                bomb2.transform.localScale = new Vector3(1,1,1);
                //这里实例了一个特效预制体,2s后它会自毁
                //Instantiate(Resources.Load("BombEffect"));
                break;
            case CardType.JokerBoom:
                name = Const.JokerBoom;
                break;
            default:
                name = Const.PlayCard[UnityEngine.Random.Range(0, 3)];
                break;
        }
        AudioClip clip = Resources.Load<AudioClip>(rscdir + name);
        Effect.PlayOneShot(clip);
    }

}

