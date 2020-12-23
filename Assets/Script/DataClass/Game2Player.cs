using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2Player :MonoBehaviour{

    public List<Game2Card> CardList = new List<Game2Card>();
    public List<Game2Card> pickedlist = new List<Game2Card>();
    //public PlayCard popcard;    //出牌器
    public string username;
    public int intergal;

    //缺乏构造器
    //构造器需要实例化PlayCard进行双向绑定
}