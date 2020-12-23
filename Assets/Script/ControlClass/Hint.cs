using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Const;

public class Hint : MonoBehaviour
{
    // Start is called before the first frame update
    public void implement(RoundModel rm)
    {
        CardUI hostUI = this.GetComponent<CardUI>();
        Player hostPlayer = this.GetComponent<Player>();
        if (rm.CurrentType == CardType.None)
        {
            
        }
        else if (rm.CurrentType == CardType.Single)
        {
            bool has = false;
            int currentValue = rm.CurrentWeight;
            for (int i = hostPlayer.CardList.Count-1; i >-1; i--)
            {
                if (hostPlayer.CardList[i].value > currentValue)
                {
                    if (!hostPlayer.CardList[i].picked)
                    {
                        hostPlayer.CardList[i].UIS.transform.position += (float)0.5 * Vector3.up;
                        hostPlayer.CardList[i].picked = true;
                        hostPlayer.pickedlist.Add(hostPlayer.CardList[i]);
                    }
                    has = true;
                    break;
                }
            }
            if (!has)
            {
                Debug.Log("no cards.");
            }
        }
        else if (rm.CurrentType == CardType.Double)
        {
            bool has = false;
            int currentValue = rm.CurrentWeight;
            for (int i = hostPlayer.CardList.Count - 1; i > -1; i--)
            {
                if (hostPlayer.CardList[i].value > currentValue)
                {
                    if (i - 1 > -1)
                    {
                        if (hostPlayer.CardList[i - 1].value == hostPlayer.CardList[i].value)
                        {
                            if (!hostPlayer.CardList[i].picked)
                            {
                                hostPlayer.CardList[i].UIS.transform.position += (float)0.5 * Vector3.up;
                                hostPlayer.CardList[i].picked = true;
                                hostPlayer.pickedlist.Add(hostPlayer.CardList[i]);
                            }
                            if (!hostPlayer.CardList[i - 1].picked)
                            {
                                hostPlayer.CardList[i - 1].UIS.transform.position += (float)0.5 * Vector3.up;
                                hostPlayer.CardList[i - 1].picked = true;
                                hostPlayer.pickedlist.Add(hostPlayer.CardList[i - 1]);
                            }
                            has = true;
                            break;
                        }
                    }
                }
            }
            if (!has)
            {
                Debug.Log("no cards.");
            }
        }
        else
        {
            Debug.Log("no cards.");
        }
    }
}
