using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Game2PlayCardUI : MonoBehaviour
{
    public Button notpop;
    public Button pop;
    // Start is called before the first frame update
    void Start()
    {
        notpop.onClick.AddListener(NotPop);
        pop.onClick.AddListener(Pop);
    }

    public void Pop()
    {
        this.gameObject.GetComponent<Game2PlayCard>().FirstJudge();
    }
    public void NotPop()
    {
        if (this.gameObject.GetComponentInParent<Game2RoundModel>().CurrentType != Const.CardType.None)
        {
            this.gameObject.GetComponentInParent<Game2RoundModel>().NotPop();
        }
    }

    public void able(List<Card> cards)
    {
        Debug.Log("execute");
        for (int i = 0; i < cards.Count; i++)
        {
            Debug.Log(cards[i].value);
        }
    }
}
