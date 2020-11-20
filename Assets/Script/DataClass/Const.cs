using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Const
{
    /// <summary>
    /// 枚举类，用于判断所有持有牌的类型
    /// </summary>
    public enum CardType
    {
        None,
        Single,//单 1
        Double,//对儿 2
        Straight,//顺子 5 - 12
        DoubleStraight,//双顺 >= 6
        TripleStraight,//飞机 >= 6 
        Three,//三不带 3
        ThreeAndOne,//三带一 4
        ThreeAndTwo,//三代二 5
        Boom,//炸弹 4
        JokerBoom//王炸 2
    }
    /// <summary>
    /// 牌的大小
    /// </summary>
    public enum Weight
    {
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        One,
        Two,
        SJoker,
        LJoker
    }
}

