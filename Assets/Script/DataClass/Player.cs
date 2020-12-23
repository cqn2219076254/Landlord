using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player :MonoBehaviour{

    public List<Card> CardList = new List<Card>();
    public List<Card> pickedlist = new List<Card>();
    //public PlayCard popcard;    //出牌器
    public string username;
    public int intergal = 0;

    //缺乏构造器
    //构造器需要实例化PlayCard进行双向绑定
}
