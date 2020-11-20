using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// 管理两个出牌和不出的按钮，还有计时器显示等等
/// 和unity结合：点击Button以后可以激活出牌判断或者跳过
/// </summary>
public class PlayCardUI : MonoBehaviour
{
    public GameObject notPop;
    public GameObject pop;
    //public PlayCard pycd;
    /*private void Awake()
    {
        pycd = new PlayCard();
        pycd.PCUI = this;
        pycd.host = new Player();
        pycd.host.popcard = pycd;
    }*/
    private void Start()
    {
        //添加notpop
        Button btn = (Button)pop.GetComponent<Button>();
        btn.onClick.AddListener(delegate ()
        {
            onClick(pop);
        });
        Button btnn = (Button)notPop.GetComponent<Button>();
        btnn.onClick.AddListener(delegate ()
        {
            notpop(notPop);
        });
    }
    void onClick(GameObject pop)
    {
        this.GetComponent<PlayCard>().FirstJudge();
        Message msg = new Message();
        msg.pop = true;
        msg.currentType = this.gameObject.GetComponentInParent<RoundModel>().CurrentType;
        msg.currentLength = this.gameObject.GetComponentInParent<RoundModel>().CurrentLength;
        msg.currentWeight = this.gameObject.GetComponentInParent<RoundModel>().CurrentWeight;
    }
    void notpop(GameObject notpop)
    {
        if (this.gameObject.GetComponentInParent<RoundModel>().CurrentType != Const.CardType.None)
        {
            this.gameObject.GetComponentInParent<RoundModel>().Turn();
            Message msg = new Message();
            msg.pop = true;
            msg.currentType = this.gameObject.GetComponentInParent<RoundModel>().CurrentType;
            msg.currentLength = this.gameObject.GetComponentInParent<RoundModel>().CurrentLength;
            msg.currentWeight = this.gameObject.GetComponentInParent<RoundModel>().CurrentWeight;
        }
    }
    /*public void unable()
    {
        Debug.Log("invalid cast");
    }*/
    public void able(List<Card> cards)
    {
        Debug.Log("execute");
        for (int i = 0; i < cards.Count; i++)
        {
            Debug.Log(cards[i].value);
        }
    }
}

