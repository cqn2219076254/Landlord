using System.Collections;
using System.Collections.Generic;
using static Const;
public class Message
{
    public bool deal = false;
    public bool lord = false;
    public bool pop = false;
    public int initLord = -1;
    public int lordChoice =-1;//
    public int popChoice = -1;//

    // public Player LandLord = null;
    public string[] dealcard;
    // public List<Card> showcard = new List<Card>();
    public string[] showcard;
    public int currentWeight = -1;
    public int currentLength = -1;
    // public CardType currentType = CardType.None;
    public string currentType = "None";
    // public Player biggestCharacter = null;
    // public Player currentCharacter = null;
    public Message()
    {

    }
}