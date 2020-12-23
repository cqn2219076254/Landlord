using System;
using System.Collections.Generic;
using UnityEngine;
using static Const;

public class ServerInterface : MonoBehaviour
{
    public Message message;
    public bool deal = false;
    public bool lord = false;
    public bool pop = false;
    public int initLord = -1;
    public int lordChoice = -1;
    public int popChoice = -1;
    public bool fishDeal = false;
    public bool fishPop = false;
    public string[] fishDCards;
    public string[] fishOCard;

    public int initFish;
    public string[] dealcard;
    public string[] showcard;
    public int currentWeight = -1;
    public int currentLength = -1;

    public string currentType = "None";
    public string[] fishGCard;
    
    // Start is called before the first frame update
    void Start()
    {
        NetManager.AddMsgListener("MsgEnterRoom", OnEnterRoom);
        NetManager.AddMsgListener("MsgAllReady", OnAllReady);
        NetManager.AddMsgListener("MsgGrabMsg", OnGrabMsg);
        NetManager.AddMsgListener("MsgEnterFishRoom", OnEnterFishRoom);
    }

    void OnEnterFishRoom(MsgBase msgBase)
    {
        MsgEnterFishRoom msg = (MsgEnterFishRoom) msgBase;
        NetManager.GetPlayer().roomId = msg.roomId;
        Debug.Log(NetManager.GetPlayer().roomId);
        if (msg.allReady)
        {
            NetManager.GetPlayer().roomId = msg.roomId;
            string cardString = msg.fishDCards;
            string[] card1 = cardString.Split(',');
            string[] card = new string[10];
            Array.Copy(card1, card, 10);
            fishDCards = card;
            initFish = msg.initFish;
            Debug.Log(msg.fishGCard);
            if (!msg.fishGCard.Equals(""))
            {
                fishGCard = new string[2];
                card1 = msg.fishGCard.Split(',');
                Array.Copy(card1, fishGCard, 2);
                
            }
            method2(msgBase);
        }
    }

    void OnEnterRoom(MsgBase msgBase)
    {
        MsgEnterRoom msg = (MsgEnterRoom) msgBase;
        Debug.Log(msg.players);
        NetManager.GetPlayer().roomId = msg.roomId;
    }
    
    //抢地主/出牌
    void OnGrabMsg(MsgBase msgBase)
    {
        MsgGrabMsg msg = (MsgGrabMsg) msgBase;
        method(msg);
        Debug.Log("受到");
    }
    void OnAllReady(MsgBase msgBase)
    {
        MsgAllReady msg = (MsgAllReady) msgBase;
        string cardString = msg.cardData;
        string[] card1 = cardString.Split(',');
        string[] card = new string[40];
        Array.Copy(card1, card, 40);
        int num = msg.num;
        // 开始发牌抢地主
        MsgGrabMsg message = new MsgGrabMsg();
        message.dealcard = card;
        message.initLord = num;
        message.deal = true;
        Debug.Log("收到发牌消息且发送了抢地主消息");
        method(message);
    }

    void method2(MsgBase msgBase)
    {
        MsgEnterFishRoom msg = (MsgEnterFishRoom) msgBase;
        this.transform.Find("Desk2").GetComponent<frm>().firstP = this.initFish;
        this.transform.Find("Desk2").GetComponent<frm>().recvCard = this.fishGCard;
        this.GetComponent<newCardF>().nStart();
    }
    void method(MsgBase msgBase)
    {
        Debug.Log("in");
        MsgGrabMsg msg = (MsgGrabMsg) msgBase;
        this.deal = msg.deal;
        this.lord = msg.lord;
        this.pop = msg.pop;
        this.initLord = msg.initLord;
        this.lordChoice = msg.lordChoice;//1 call, 2 not call, 3 grab, 4 not grab
        this.popChoice = msg.popChoice;//1 pop, 2 not pop
        this.dealcard = msg.dealcard;
        this.showcard = msg.showcard;
        this.currentWeight = msg.currentWeight;
        this.currentLength = msg.currentLength;
        this.currentType = msg.currentType;
        this.fishDeal = msg.fishDeal;
        this.fishPop = msg.fishPop;
        Debug.Log("fishDeal" + fishDeal);
        Debug.Log("fishDeal" + fishPop);
        //this.fishDCards = msg.fishDCards;
        if (NetManager.GetPlayer().roomId[0] == 'F')
        {
            string[] card;
            fishOCard = new string[2];
            card = msg.fishOCard.Split(',');
            Array.Copy(card, fishOCard, 2);
            fishGCard = new string[2];
            card = msg.fishGCard.Split(',');
            Array.Copy(card, fishGCard, 2);
            this.initFish = msg.initFish;
            this.transform.Find("Desk2").GetComponent<frm>().recvCard = this.fishGCard;
            Card t = new Card(int.Parse(fishOCard[0]), int.Parse(fishOCard[1]), "", null);
            this.transform.Find("Desk2").GetComponent<frm>().process(t);
        }
        else
        {
            if (this.deal)
            {
                GameObject.Find("Root/Canvas/multi(Clone)/board").GetComponent<newCards>().nStart();
                GameObject.Find("Root/Canvas/multi(Clone)/board/Desk").GetComponent<LordModel>().initL(initLord);

            }
            else if (this.lord)
            {
                if (this.lordChoice==1)
                {
                    GameObject.Find("Root/Canvas/multi(Clone)/board/Desk").GetComponent<LordModel>().callL();
                }else if (this.lordChoice == 2)
                {
                    GameObject.Find("Root/Canvas/multi(Clone)/board/Desk").GetComponent<LordModel>().notCallL();
                }
                else if (this.lordChoice == 3)
                {
                    GameObject.Find("Root/Canvas/multi(Clone)/board/Desk").GetComponent<LordModel>().grabL();
                }
                else if (this.lordChoice == 4)
                {
                    GameObject.Find("Root/Canvas/multi(Clone)/board/Desk").GetComponent<LordModel>().notGrabL();
                }
            }
            else if (pop)
            {
                List<Card> showList = new List<Card>();
                for (int i = 0; i < showcard.Length / 2; i++)
                {
                    showList.Add(new Card(int.Parse(showcard[2 * i]), int.Parse(showcard[2 * i + 1]), "", null));
                }
                // RoundModel rm = this.transform.Find("Desk").GetComponent<RoundModel>();
                RoundModel rm = GameObject.Find("Root/Canvas/multi(Clone)/board/Desk").GetComponent<RoundModel>();

                rm.CurrentLength = this.currentLength;
                if (msg.currentType.Equals("None"))
                {
                    rm.CurrentType = CardType.None;
                }
                if (msg.currentType.Equals("Single"))
                {
                    rm.CurrentType = CardType.Single;
                }
                if (msg.currentType.Equals("Double"))
                {
                    rm.CurrentType = CardType.Double;
                }
                if (msg.currentType.Equals("ThreeAndTwo"))
                {
                    rm.CurrentType = CardType.ThreeAndTwo;
                }
                if (msg.currentType.Equals("Boom"))
                {
                    rm.CurrentType = CardType.Boom;
                }
                if (msg.currentType.Equals("Straight"))
                {
                    rm.CurrentType = CardType.Straight;
                }
                if (msg.currentType.Equals("Three"))
                {
                    rm.CurrentType = CardType.Three;
                }
                if (msg.currentType.Equals("ThreeAndOne"))
                {
                    rm.CurrentType = CardType.ThreeAndOne;
                }
                if (msg.currentType.Equals("JokerBoom"))
                {
                    rm.CurrentType = CardType.JokerBoom;
                }
                if (msg.currentType.Equals("DoubleStraight"))
                {
                    rm.CurrentType = CardType.DoubleStraight;
                }
                if (msg.currentType.Equals("TripleStraight"))
                {
                    rm.CurrentType = CardType.TripleStraight;
                }
                // rm.CurrentType = this.currentType;
                GameObject.Find("Root/Canvas/multi(Clone)/board/Desk").GetComponent<Sound>().PlayCardEffect(rm.CurrentType,msg.currentWeight);
                rm.CurrentWeight = this.currentWeight;
                if (popChoice == 1)
                {
                    if (rm.CurrentCharacter == rm.PlayerList[1])
                    {
                        Debug.Log(msg.showcard[0]);
                        Debug.Log(msg.showcard[1]);
                        // this.transform.Find("Desk").GetComponent<DeskUI>().showOtherCard(showList, "Right");
                        GameObject.Find("Root/Canvas/multi(Clone)/board/Desk").GetComponent<DeskUI>().showOtherCard(showList, "Right");
                        
                    }else if (rm.CurrentCharacter == rm.PlayerList[2])
                    {
                        Debug.Log(msg.showcard[0]);
                        Debug.Log(msg.showcard[1]);
                        // this.transform.Find("Desk").GetComponent<DeskUI>().showOtherCard(showList, "Left");
                        GameObject.Find("Root/Canvas/multi(Clone)/board/Desk").GetComponent<DeskUI>().showOtherCard(showList, "Left");
                    }
                    rm.BiggestCharacter = rm.CurrentCharacter;
                }
                rm.Turn();
            }
        }
    }

    public void RemoveListener()
    {
        NetManager.RemoveMsgListener("MsgEnterRoom", OnEnterRoom);
        NetManager.RemoveMsgListener("MsgAllReady", OnAllReady);
        NetManager.RemoveMsgListener("MsgGrabMsg", OnGrabMsg);
        NetManager.RemoveMsgListener("MsgEnterFishRoom", OnEnterFishRoom);
    }
}
