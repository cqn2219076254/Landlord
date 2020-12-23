using System.Collections.Generic;
using static Const;

public static class Game2Ruler
{
    /// <summary>
    /// 可否出牌
    /// </summary>
    /// <param name="cards">传入的牌</param>
    /// <param name="type">出牌类型</param>
    /// <returns></returns>
    public static bool CanPop(List<Game2Card> cards, out CardType type)
    {
        type = CardType.None;
        bool can = false;
        switch (cards.Count)
        {
            case 1:
                if (IsSingle(cards))
                {
                    can = true;
                    type = CardType.Single;
                }

                break;
            case 2:
                if (IsDouble(cards))
                {
                    can = true;
                    type = CardType.Double;
                }
                else if (IsJokerBoom(cards))
                {
                    can = true;
                    type = CardType.JokerBoom;
                }
                break;
            case 3:
                if (IsThree(cards))
                {
                    can = true;
                    type = CardType.Three;
                }
                break;
            case 4:
                if (IsBoom(cards))
                {
                    can = true;
                    type = CardType.Boom;
                }
                else if (IsThreeAndOne(cards))
                {
                    can = true;
                    type = CardType.ThreeAndOne;
                }
                break;
            case 5:
                if (IsStraight(cards))
                {
                    can = true;
                    type = CardType.Straight;
                }
                else if (IsThreeAndTwo(cards))
                {
                    can = true;
                    type = CardType.ThreeAndTwo;
                }
                break;
            case 6:
                if (IsStraight(cards))
                {
                    can = true;
                    type = CardType.Straight;
                }
                else if (IsDoubleStraight(cards))
                {
                    can = true;
                    type = CardType.DoubleStraight;
                }
                else if (IsTripleStraight(cards))
                {
                    can = true;
                    type = CardType.TripleStraight;
                }
                break;
            case 7:
                if (IsStraight(cards))
                {
                    can = true;
                    type = CardType.Straight;
                }
                break;
            case 8:
                if (IsStraight(cards))
                {
                    can = true;
                    type = CardType.Straight;
                }
                else if (IsDoubleStraight(cards))
                {
                    can = true;
                    type = CardType.DoubleStraight;
                }
                break;
            case 9:
                if (IsStraight(cards))
                {
                    can = true;
                    type = CardType.Straight;
                }
                else if (IsTripleStraight(cards))
                {
                    can = true;
                    type = CardType.TripleStraight;
                }
                break;
            case 10:
                if (IsStraight(cards))
                {
                    can = true;
                    type = CardType.Straight;
                }
                else if (IsDoubleStraight(cards))
                {
                    can = true;
                    type = CardType.DoubleStraight;
                }
                break;
            case 11:
                if (IsStraight(cards))
                {
                    can = true;
                    type = CardType.Straight;
                }
                break;
            case 12:
                if (IsStraight(cards))
                {
                    can = true;
                    type = CardType.Straight;
                }
                else if (IsDoubleStraight(cards))
                {
                    can = true;
                    type = CardType.DoubleStraight;
                }
                else if (IsTripleStraight(cards))
                {
                    can = true;
                    type = CardType.TripleStraight;
                }
                break;
            case 13:
                break;
            case 14:
                if (IsDoubleStraight(cards))
                {
                    can = true;
                    type = CardType.DoubleStraight;
                }
                break;
            case 15:
                if (IsTripleStraight(cards))
                {
                    can = true;
                    type = CardType.TripleStraight;
                }
                break;
            case 16:
                if (IsDoubleStraight(cards))
                {
                    can = true;
                    type = CardType.DoubleStraight;
                }
                break;
            case 17:
                break;
            case 18:
                if (IsDoubleStraight(cards))
                {
                    can = true;
                    type = CardType.DoubleStraight;
                }
                else if (IsTripleStraight(cards))
                {
                    can = true;
                    type = CardType.TripleStraight;
                }
                break;
            case 19:
                break;
            case 20:
                if (IsDoubleStraight(cards))
                {
                    can = true;
                    type = CardType.DoubleStraight;
                }
                break;
            default:
                break;
        }
        return can;
    }

    /// <summary>
    /// 是否单牌
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsSingle(List<Game2Card> cards)
    {
        return cards.Count == 1;
    }


    /// <summary>
    /// 判断对儿
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsDouble(List<Game2Card> cards)
    {
        if (cards.Count == 2)
        {
            if (cards[0].value == cards[1].value)
                return true;

        }

        return false;
    }

    /// <summary>
    /// 是否是顺子
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsStraight(List<Game2Card> cards)
    {
        if (cards.Count < 5 || cards.Count > 12)
            return false;
        for (int i = 0; i < cards.Count - 1; i++)
        {
            if (cards[i + 1].value - cards[i].value != 1)
                return false;
            //不能超过A
            if (cards[i].value > 11 || cards[i + 1].value > 11)
                return false;
        }
        return true;
    }


    /// <summary>
    /// 是否双顺
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsDoubleStraight(List<Game2Card> cards)
    {
        if (cards.Count < 6 || cards.Count % 2 != 0)
            return false;

        for (int i = 0; i < cards.Count - 2; i += 2)
        {
            if (cards[i + 1].value != cards[i].value)
                return false;
            if (cards[i + 2].value - cards[i].value != 1)
                return false;

            //不能超过A
            if (cards[i].value > 11 || cards[i + 2].value > 11)
                return false;
        }
        return true;
    }


    /// <summary>
    /// 是否三个的顺子
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsTripleStraight(List<Game2Card> cards)
    {
        if (cards.Count < 6 || cards.Count % 3 != 0)
            return false;

        for (int i = 0; i < cards.Count - 3; i += 3)
        {
            if (cards[i + 1].value != cards[i].value)
                return false;
            if (cards[i + 2].value != cards[i].value)
                return false;
            if (cards[i + 1].value != cards[i + 2].value)
                return false;

            if (cards[i + 3].value - cards[i].value != 1)
                return false;

            //不能超过A
            if (cards[i].value > 11 || cards[i + 3].value > 11)
                return false;
        }
        return true;
    }


    /// <summary>
    /// 三不带
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsThree(List<Game2Card> cards)
    {
        if (cards.Count != 3)
            return false;

        if (cards[1].value != cards[0].value)
            return false;
        //if (cards[2].value != cards[0].value)
        //    return false;
        if (cards[1].value != cards[2].value)
            return false;
        return true;
    }

    /// <summary>
    /// 三带一
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsThreeAndOne(List<Game2Card> cards)
    {
        if (cards.Count != 4)
            return false;
        if (cards[1].value == cards[0].value && cards[1].value == cards[2].value)
            return true;
        else if (cards[1].value == cards[2].value && cards[3].value == cards[2].value)
            return true;
        return false;

    }

    /// <summary>
    /// 三代二
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsThreeAndTwo(List<Game2Card> cards)
    {
        if (cards.Count != 5)
            return false;

        if (cards[1].value == cards[0].value && cards[1].value == cards[2].value)
        {
            if (cards[3].value == cards[4].value)
                return true;

        }
        else if (cards[3].value == cards[2].value && cards[3].value == cards[4].value)
        {
            if (cards[1].value == cards[0].value)
                return true;
        }
        return false;
    }


    /// <summary>
    /// 炸弹
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsBoom(List<Game2Card> cards)
    {
        if (cards.Count != 4)
            return false;

        if (cards[1].value != cards[0].value)
            return false;
        if (cards[2].value != cards[1].value)
            return false;
        if (cards[3].value != cards[2].value)
            return false;
        return true;
    }
    /// <summary>
    /// 王炸
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsJokerBoom(List<Game2Card> cards)
    {
        if (cards.Count != 2)
            return false;

        if (cards[0].value == 14 && cards[1].value ==15)
            return true;

        return false;
    }
    /// <summary>
    /// 飞机
    /// </summary>
    /// <param name="cards"></param>
    /// <returns></returns>
    public static bool IsPlane(List<Game2Card> cards)
    {
        return false;
    }
    /// <summary>
    /// 四带两单牌
    /// </summary>
    /// <returns></returns>
    public static bool IsFourAndTwoSingle()
    {
        return false;
    }
    /// <summary>
    /// 四带两对
    /// </summary>
    /// <returns></returns>
    public static bool IsFourAndTwoDouble()
    {
        return false;
    }
}

