//查询成绩

using System;
using System.Collections.Generic;

// player data
public class MsgGetPlayerInfo : MsgBase
{
    public MsgGetPlayerInfo() { protoName = "MsgGetPlayerInfo"; }
    //服务端回
    public int bean = 0;
    public int diamond = 0;
    public int cpNum = 0;
}

// enter room
public class MsgEnterRoom : MsgBase
{
    public MsgEnterRoom() { protoName = "MsgEnterRoom"; }

    public string roomId;
    //客户端发
    // public int id = 0;
    //服务端回
    public int result = 0;
    public List<Player> players = new List<Player>();
}

// all ready
public class MsgAllReady : MsgBase
{
    public MsgAllReady() { protoName = "MsgAllReady"; }
    //客户端发

    //服务端回
    public string cardData = "";
    public int num = 0;
}

//抢地主/出牌
public class MsgGrabMsg : MsgBase
{
    public MsgGrabMsg() { protoName = "MsgGrabMsg"; }
    public string roomId;
    public bool deal = false;
    public bool lord = false;
    public bool pop = false;
    public int initLord = -1;
    public int lordChoice =-1;//
    public int popChoice = -1;//
    public bool fishDeal = false;
    public bool fishPop = false;
    public string fishDCards;
    public string fishOCard;
    public int initFish;
    public string[] dealcard;
    public string[] showcard;
    public int currentWeight = -1;
    public int currentLength = -1;
    public string currentType = "None";
    public string fishGCard;
}

public class MsgEnterFishRoom : MsgBase
{
    public MsgEnterFishRoom() {protoName = "MsgEnterFishRoom";}
    public string roomId;
    public bool allReady;
	
    public bool fishDeal;
    public bool fishPop;
    public string fishDCards;
    public string fishOCard;
    public string fishGCard;
    public int initFish;
	
    public string cardData = "";
    public int num = 0;
}



public class MsgBean : MsgBase
{
    public MsgBean() {protoName = "MsgBean";}
    public int beanNum;
}