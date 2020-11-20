using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Const;
using System.Collections;

public class CP4AI : MonoBehaviour
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
            PopSingle(4, count);
            PopSingle(8, count);
            PopSingle(9, count);
            PopSingle(10, count);
            PopSingle(11, count);
            PopSingle(14, count);
            PopSingle(3, count);
            PopSingle(12, count);
            PopSingle(6, count);
            if (count == hadc.Count)
            {
                round.NotPop();
            }
        }
        else if (round.CurrentType == CardType.Double)
        {
            Debug.Log("cp need double");
            PopDouble(3, count);
            PopDouble(12, count);
            PopDouble(6, count);
            if (count == hadc.Count)
            {
                round.NotPop();
            }
        }
        else if (round.CurrentType == CardType.Three)
        {
            Debug.Log("cp need Three");
            PopThree(6, count);
            if (count == hadc.Count)
            {
                round.NotPop();
            }
        }
        else if (round.CurrentType == CardType.ThreeAndOne)
        {
            Debug.Log("cp need ThreeAndOne");
            PopThreeAndOne(6, 4, count);
            PopThreeAndOne(6, 8, count);
            PopThreeAndOne(6, 9, count);
            PopThreeAndOne(6, 10, count);
            PopThreeAndOne(6, 11, count);
            PopThreeAndOne(6, 14, count);
            PopThreeAndOne(6, 3, count);
            PopThreeAndOne(6, 12, count);
            if (count == hadc.Count)
            {
                round.NotPop();
            }
        }
        else if (round.CurrentType == CardType.ThreeAndTwo)
        {
            Debug.Log("cp need ThreeAndTwo");
            PopThreeAndTwo(6, 3, count);
            PopThreeAndTwo(6, 12, count);
            if (count == hadc.Count)
            {
                round.NotPop();
            }
        }
        else if (round.CurrentType == CardType.None)
        {
            Debug.Log("cp need None");
            PopThreeAndTwo(6, 3, count);
            PopThreeAndOne(6, 4, count);
            PopThreeAndOne(6, 8, count);
            PopThreeAndOne(6, 9, count);
            PopThreeAndOne(6, 10, count);
            PopThreeAndOne(6, 11, count);
            PopThreeAndOne(6, 14, count);
            PopThreeAndOne(6, 3, count);
            PopThreeAndTwo(6, 12, count);
            PopThreeAndOne(6, 12, count);
            PopThree(6, count);
            PopDouble(3, count);
            PopDouble(12, count);
            PopDouble(6, count);
            PopSingle(4, count);
            PopSingle(8, count);
            PopSingle(9, count);
            PopSingle(10, count);
            PopSingle(11, count);
            PopSingle(14, count);
            PopSingle(3, count);
            PopSingle(12, count);
            PopSingle(6, count);
        }
        else
        {
            round.NotPop();
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
        int ncount = 0;
        for (int i = 0; i < hadc.Count && !done; i++)
        {
            if (hadc[i].value == n && ncount < 2)
            {
                hadc[i].picked = true;
                this.gameObject.GetComponent<Player>().pickedlist.Add(hadc[i]);
                ncount++;
            }
        }
        if (ncount == 2)
        {
            this.GetComponent<Game2PlayCard>().FirstJudge();
        }
        else if (ncount > 0)
        {
            this.GetComponent<Game2PlayCard>().CancelPick();
        }
        this.GetComponent<Game2PlayCard>().FirstJudge();
        if (count > hadc.Count)
        {
            done = true;
        }
    }

    public void PopThree(int n, int count)
    {
        int ncount = 0;
        for (int i = 0; i < hadc.Count && !done; i++)
        {
            if (hadc[i].value == n && ncount < 3)
            {
                hadc[i].picked = true;
                this.gameObject.GetComponent<Player>().pickedlist.Add(hadc[i]);
                ncount++;
            }
        }
        if (ncount == 3)
        {
            this.GetComponent<Game2PlayCard>().FirstJudge();
        }
        else if (ncount > 0)
        {
            this.GetComponent<Game2PlayCard>().CancelPick();
        }
        if (count > hadc.Count)
        {
            done = true;
        }
    }

    public void PopThreeAndOne(int m, int n, int count)
    {
        int mcount = 0;
        int ncount = 0;
        for (int i = 0; i < hadc.Count && !done; i++)
        {
            if (hadc[i].value == m && mcount < 3)
            {
                hadc[i].picked = true;
                this.gameObject.GetComponent<Player>().pickedlist.Add(hadc[i]);
                mcount++;
            }
            if (hadc[i].value == n && ncount < 1)
            {
                hadc[i].picked = true;
                this.gameObject.GetComponent<Player>().pickedlist.Add(hadc[i]);
                ncount++;
            }
        }
        if (mcount == 3 && ncount == 1)
        {
            this.GetComponent<Game2PlayCard>().FirstJudge();
        }
        else if (mcount + ncount > 0)
        {
            this.GetComponent<Game2PlayCard>().CancelPick();
        }
        if (count > hadc.Count)
        {
            done = true;
        }
    }

    public void PopThreeAndTwo(int m, int n, int count)
    {
        int mcount = 0;
        int ncount = 0;
        for (int i = 0; i < hadc.Count && !done; i++)
        {
            if (hadc[i].value == m && mcount < 3)
            {
                hadc[i].picked = true;
                this.gameObject.GetComponent<Player>().pickedlist.Add(hadc[i]);
                mcount++;
            }
            if (hadc[i].value == n && ncount < 2)
            {
                hadc[i].picked = true;
                this.gameObject.GetComponent<Player>().pickedlist.Add(hadc[i]);
                ncount++;
            }
        }
        if (mcount == 3 && ncount == 2)
        {
            this.GetComponent<Game2PlayCard>().FirstJudge();
        }
        else if (mcount + ncount > 0)
        {
            this.GetComponent<Game2PlayCard>().CancelPick();
        }
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
