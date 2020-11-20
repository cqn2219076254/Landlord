using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Const;
using System.Collections;

public class CP2AI : MonoBehaviour
{
    public bool done = false;
    public List<Card> hadc = new List<Card>();

    public void Action()
    {
        StartCoroutine(Disappear());
    }

    public void Do()
    {
        done = false;
        hadc = this.gameObject.GetComponent<Player>().CardList;
        int count = hadc.Count;
        Game2RoundModel round = this.gameObject.GetComponentInParent<Game2RoundModel>();
        if (round.CurrentType == CardType.Single)
        {
            Debug.Log("cp need single");
            PopSingle(3, count);
            PopSingle(4, count);
            PopSingle(11, count);
            PopSingle(14, count);
            PopSingle(9, count);
            if (count == hadc.Count)
            {
                round.NotPop();
            }
        }
        else if (round.CurrentType == CardType.Double)
        {
            Debug.Log("cp need double");
            PopDouble(9, count);
            if (count == hadc.Count)
            {
                round.NotPop();
            }
        }
        else if (round.CurrentType == CardType.None)
        {
            Debug.Log("cp need None");
            PopSingle(3, count);
            PopSingle(4, count);
            PopSingle(11, count);
            PopSingle(14, count);
            PopDouble(9, count);
            PopSingle(9, count);
        }
    }

    public void PopSingle(int n, int count)
    {
        for (int i = 0; i < hadc.Count && !done; i++)
        {
            if (hadc[i].value == n)
            {
                hadc[i].picked = true;
                this.gameObject.GetComponent<Player>().pickedlist.Add(hadc[i]);
                this.GetComponent<Game2PlayCard>().FirstJudge();
                if (count > hadc.Count)
                {
                    done = true;
                }
            }
        }
    }

    public void PopDouble(int n, int count)
    {
        for (int i = 0; i < hadc.Count && !done; i++)
        {
            if (hadc[i].value == n)
            {
                hadc[i].picked = true;
                this.gameObject.GetComponent<Player>().pickedlist.Add(hadc[i]);
            }
        }
        this.GetComponent<Game2PlayCard>().FirstJudge();
        if (count > hadc.Count)
        {
            done = true;
        }
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(0.5f);
        Do();
    }
}
