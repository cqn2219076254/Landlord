using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Const;

public class Game2Card  {
    public int value;
    public int color;
    public string host;
    public bool picked;
    public Game2CardUI UIS;
    public int sortOrder;
    public Game2Card(int value,int color, string host,Game2CardUI UIS)
    {
        this.value = value;
        this.color = color;
        this.host = host;
        this.UIS = UIS;
        this.picked = false;
    }
}