using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Const;

public class Card  {
    public int value;
    public int color;
    public string host;
    public bool picked;
    public CardUI UIS;
    public int sortOrder;
    public Card(int value,int color, string host,CardUI UIS)
    {
        this.value = value;
        this.color = color;
        this.host = host;
        this.UIS = UIS;
        this.picked = false;
    }
}
