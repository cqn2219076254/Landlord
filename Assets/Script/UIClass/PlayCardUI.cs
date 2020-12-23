using System.Collections.Generic;
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
    public GameObject prompt;
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
        Button btnnn = (Button)prompt.GetComponent<Button>();
        btnnn.onClick.AddListener(delegate ()
        {
            hint(prompt);
        });

    }
    void onClick(GameObject pop)
    {
        Debug.Log("current weight before pop:" + this.GetComponentInParent<RoundModel>().CurrentWeight);
        bool send = this.GetComponent<PlayCard>().FirstJudge();
        if (send)
        {
            MsgGrabMsg msgPop = new MsgGrabMsg();
            msgPop.roomId = NetManager.GetPlayer().roomId;
            msgPop.pop = true;
            msgPop.popChoice = 1;
            Const.CardType currentType = this.gameObject.GetComponentInParent<RoundModel>().CurrentType;
            msgPop.currentLength = this.gameObject.GetComponentInParent<RoundModel>().CurrentLength;
            msgPop.currentWeight = this.gameObject.GetComponentInParent<RoundModel>().CurrentWeight;
            List<Card> deskui = this.GetComponentInParent<DeskUI>().displayCard;
            string[] showcards = new string[deskui.Count * 2];
            for (int i = 0; i < deskui.Count; i++)
            {
                showcards[2 * i] = deskui[i].value.ToString();
                showcards[2 * i + 1] = deskui[i].color.ToString();
            }
            msgPop.showcard = showcards;
            // 需要把 cardType里其他几种也实现，用switch好一点？
            switch (currentType)
            {
                case Const.CardType.Single:
                    msgPop.currentType = "Single";
                    break;
                case Const.CardType.Boom:
                    msgPop.currentType = "Boom";
                    break;
                case Const.CardType.Double:
                    msgPop.currentType = "Double";
                    break;
                case Const.CardType.None:
                    msgPop.currentType = "None";
                    break;
                case Const.CardType.Straight:
                    msgPop.currentType = "Straight";
                    break;
                case Const.CardType.Three:
                    msgPop.currentType = "Three";
                    break;
                case Const.CardType.DoubleStraight:
                    msgPop.currentType = "DoubleStraight";
                    break;
                case Const.CardType.JokerBoom:
                    msgPop.currentType = "JokerBoom";
                    break;
                case Const.CardType.TripleStraight:
                    msgPop.currentType = "TripleStraight";
                    break;
                case Const.CardType.ThreeAndOne:
                    msgPop.currentType = "ThreeAndOne";
                    break;
                case Const.CardType.ThreeAndTwo:
                    msgPop.currentType = "ThreeAndTwo";
                    break;
            }
            NetManager.Send(msgPop);
        }
    }
    void notpop(GameObject notpop)
    {
        if (this.gameObject.GetComponentInParent<RoundModel>().CurrentType != Const.CardType.None)
        {
            this.gameObject.GetComponentInParent<RoundModel>().Turn();
            MsgGrabMsg msgPop = new MsgGrabMsg();
            msgPop.roomId = NetManager.GetPlayer().roomId;
            msgPop.pop = true;
            //以为要改
            Const.CardType currentType = this.gameObject.GetComponentInParent<RoundModel>().CurrentType;
            msgPop.currentLength = this.gameObject.GetComponentInParent<RoundModel>().CurrentLength;
            msgPop.currentWeight = this.gameObject.GetComponentInParent<RoundModel>().CurrentWeight;
            switch (currentType)
            {
                case Const.CardType.Single:
                    msgPop.currentType = "Single";
                    break;
                case Const.CardType.Boom:
                    msgPop.currentType = "Boom";
                    break;
                case Const.CardType.Double:
                    msgPop.currentType = "Double";
                    break;
                case Const.CardType.None:
                    msgPop.currentType = "None";
                    break;
                case Const.CardType.Straight:
                    msgPop.currentType = "Straight";
                    break;
                case Const.CardType.Three:
                    msgPop.currentType = "Three";
                    break;
                case Const.CardType.DoubleStraight:
                    msgPop.currentType = "DoubleStraight";
                    break;
                case Const.CardType.JokerBoom:
                    msgPop.currentType = "JokerBoom";
                    break;
                case Const.CardType.TripleStraight:
                    msgPop.currentType = "TripleStraight";
                    break;
                case Const.CardType.ThreeAndOne:
                    msgPop.currentType = "ThreeAndOne";
                    break;
                case Const.CardType.ThreeAndTwo:
                    msgPop.currentType = "ThreeAndTwo";
                    break;
            }
            NetManager.Send(msgPop);
        }
    }
    
    void hint(GameObject prompt)
    {
        RoundModel rm = this.transform.parent.GetComponent<RoundModel>();
        this.GetComponent<Hint>().implement(rm);
    }

    public void able(List<Card> cards)
    {
        Debug.Log("execute");
        for (int i = 0; i < cards.Count; i++)
        {
            Debug.Log(cards[i].value);
        }
    }
}

