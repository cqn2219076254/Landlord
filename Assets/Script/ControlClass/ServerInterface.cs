using System.Collections;
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

    public Player LandLord = null;
    public string[] dealcard = new string[20];
    public List<Card> showcard = new List<Card>();
    public int currentWeight = -1;
    public int currentLength = -1;
    public CardType currentType = CardType.None;
    public Player biggestCharacter = null;
    public Player currentCharacter = null;
    // Start is called before the first frame update
    void Start()
    {
        //addListener;
        method(message);
    }
    void method(Message messaget) {
        this.deal = messaget.deal;
        this.lord = messaget.lord;
        this.pop = messaget.pop;
        this.initLord = messaget.initLord;
        this.lordChoice = messaget.lordChoice;//1 call, 2 not call, 3 grab, 4 not grab
        this.popChoice = messaget.popChoice;//1 pop, 2 not pop
        this.LandLord = messaget.LandLord;
        for (int n = 0; n < messaget.dealcard.Length; n++)
            this.dealcard[n] = messaget.dealcard[n];
        for (int n = 0; n < messaget.showcard.Count; n++)
            this.showcard.Add(messaget.showcard[n]);
        this.currentWeight = messaget.currentWeight;
        this.currentLength = messaget.currentLength;
        this.currentType = messaget.currentType;
        this.biggestCharacter = messaget.biggestCharacter;
        this.currentCharacter = messaget.currentCharacter;

        if (this.deal)
        {
            this.GetComponent<newCards>().enabled = true;
            this.transform.Find("Desk").GetComponent<LordModel>().lordInit = initLord;
        }else if (this.lord)
        {
            if (this.lordChoice==1)
            {
                this.transform.Find("Desk").GetComponent<LordModel>().callL();
            }else if (this.lordChoice == 2)
            {
                this.transform.Find("Desk").GetComponent<LordModel>().notCallL();
            }
            else if (this.lordChoice == 3)
            {
                this.transform.Find("Desk").GetComponent<LordModel>().grabL();
            }
            else if (this.lordChoice == 4)
            {
                this.transform.Find("Desk").GetComponent<LordModel>().notGrabL();
            }
        }
        else if (pop)
        {
            /*if (popChoice == 1)
            {
                Player nowPlayer = this.transform.Find("Desk").GetComponent<RoundModel>().CurrentCharacter;
                nowPlayer.pickedlist.Clear();
                for(int i = 0; i < showcard.Count; i++)
                {
                    nowPlayer.pickedlist.Add(showcard[i]);
                }
                nowPlayer.GetComponent<PlayCard>().FirstJudge();
            }
            else
            {
                if (this.transform.Find("Desk").GetComponent<RoundModel>().CurrentType != Const.CardType.None)
                {
                    this.transform.Find("Desk").GetComponent<RoundModel>().Turn();
                }
            }*/
            RoundModel rm = this.transform.Find("Desk").GetComponent<RoundModel>();
            rm.CurrentLength = this.currentLength;
            rm.CurrentType = this.currentType;
            rm.CurrentWeight = this.currentWeight;
            if (popChoice == 1)
            {
                rm.BiggestCharacter = rm.CurrentCharacter;
            }
            rm.Turn();
        }
    }
}
