using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LordModel : MonoBehaviour
{
    public List<Player> players = new List<Player>();
    public int lordInit;
    public Player initCall;
    public bool[] edited = new bool[3];
    public bool[] lord = new bool[3];
    public Player currentChoice;
    public Player currentLord;
    public void Awake()
    {
        lordInit = 0;
        players = this.GetComponentsInChildren<Player>().ToList<Player>();
        initCall = players[lordInit];
        currentChoice = players[lordInit];
    }
    public void nextChoice()
    {
        lordInit = (lordInit + 1) % 3;
    }
    public void playerStartCall()
    {
        if (lordInit == 0)
        {
            currentChoice.GetComponent<LordUI>().notCall.SetActive(true);
            currentChoice.GetComponent<LordUI>().call.SetActive(true);
        }
    }
    public void notCallL()
    {
        edited[lordInit] = true;
        lord[lordInit] = false;
        currentChoice.GetComponent<LordUI>().notCall.SetActive(false);
        currentChoice.GetComponent<LordUI>().call.SetActive(false);
        if (edited[0] && edited[1] && edited[2] && (!lord[0]) && (!lord[1]) && (!lord[2]))
        {
            lordInit = Random.Range(0, 3);
            initCall = players[lordInit];
            currentChoice = players[lordInit];
            edited[0] = false;
            edited[1] = false;
            edited[2] = false;
            this.transform.parent.Find("CardInitiate(Clone)").GetComponent<Cardinit>().selfDestroy();
            GameObject g = Instantiate(Resources.Load<GameObject>("CardInitiate"));
            g.transform.parent = this.transform.parent;
        }
        else
        {
            nextChoice();
            initCall = players[lordInit];
            currentChoice = players[lordInit];
            if (currentChoice == players[0])
            {
                currentChoice.GetComponent<LordUI>().notCall.SetActive(true);
                currentChoice.GetComponent<LordUI>().call.SetActive(true);
            }
        }
    }
    public void click()
    {
        currentChoice.GetComponent<LordUI>().notCall.SetActive(false);
        currentChoice.GetComponent<LordUI>().call.SetActive(false);
        currentChoice.GetComponent<LordUI>().notGrab.SetActive(false);
        currentChoice.GetComponent<LordUI>().grab.SetActive(false);
    }
    public void receiveCall()
    {
        currentChoice.GetComponent<LordUI>().notCall.SetActive(true);
        currentChoice.GetComponent<LordUI>().call.SetActive(true);
    }
    public void receiveGrab()
    {
        currentChoice.GetComponent<LordUI>().notGrab.SetActive(true);
        currentChoice.GetComponent<LordUI>().grab.SetActive(true);
    }
    public void callL()
    {
        edited[lordInit] = true;
        lord[lordInit] = true;
        currentChoice.GetComponent<LordUI>().notCall.SetActive(false);
        currentChoice.GetComponent<LordUI>().call.SetActive(false);
        currentLord = players[lordInit];
        nextChoice();
        if (!edited[lordInit])
        {
            currentChoice = players[lordInit];
            if (currentChoice == players[0])
            {
                currentChoice.GetComponent<LordUI>().notGrab.SetActive(true);
                currentChoice.GetComponent<LordUI>().grab.SetActive(true);
            }
        }
        else
        {
            RoundModel round = this.GetComponent<RoundModel>();
            round.LandLord = initCall;
            round.CurrentCharacter = initCall;
            this.transform.parent.Find("CardInitiate(Clone)").GetComponent<Cardinit>().AddCard(initCall);
            if (initCall == players[0])
            {
                initCall.GetComponent<PlayCardUI>().pop.SetActive(true);
                initCall.GetComponent<PlayCardUI>().notPop.SetActive(true);
            }
        }
    }
    public void notGrabL()
    {
        edited[lordInit] = true;
        lord[lordInit] = false;
        currentChoice.GetComponent<LordUI>().notGrab.SetActive(false);
        currentChoice.GetComponent<LordUI>().grab.SetActive(false);
        if (currentChoice == initCall)
        {
            RoundModel round = this.GetComponent<RoundModel>();
            round.LandLord = currentLord;
            round.CurrentCharacter = currentLord;
            this.transform.parent.Find("CardInitiate(Clone)").GetComponent<Cardinit>().AddCard(currentLord);
            if (currentLord == players[0])
            {
                currentLord.GetComponent<PlayCardUI>().pop.SetActive(true);
                currentLord.GetComponent<PlayCardUI>().notPop.SetActive(true);
            }
        }
        else
        {
            if (currentLord == initCall && edited[0] && edited[1] && edited[2])
            {
                RoundModel round = this.GetComponent<RoundModel>();
                round.LandLord = currentLord;
                round.CurrentCharacter = currentLord;
                this.transform.parent.Find("CardInitiate(Clone)").GetComponent<Cardinit>().AddCard(currentLord);
                if (currentLord == players[0])
                {
                    currentLord.GetComponent<PlayCardUI>().pop.SetActive(true);
                    currentLord.GetComponent<PlayCardUI>().notPop.SetActive(true);
                }
            }
            else
            {
                while (edited[lordInit] && (!lord[lordInit]))
                {
                    nextChoice();
                }
                currentChoice = players[lordInit];
                if (currentChoice == players[0])
                {
                    currentChoice.GetComponent<LordUI>().notGrab.SetActive(true);
                    currentChoice.GetComponent<LordUI>().grab.SetActive(true);
                }
            }
        }
    }
    public void grabL()
    {
        edited[lordInit] = true;
        lord[lordInit] = false;
        currentChoice.GetComponent<LordUI>().notGrab.SetActive(false);
        currentChoice.GetComponent<LordUI>().grab.SetActive(false);
        currentLord = players[lordInit];
        if (currentChoice == initCall)
        {
            RoundModel round = this.GetComponent<RoundModel>();
            round.LandLord = initCall;
            round.CurrentCharacter = initCall;
            this.transform.parent.Find("CardInitiate(Clone)").GetComponent<Cardinit>().AddCard(initCall);
            if (initCall == players[0])
            {
                initCall.GetComponent<PlayCardUI>().pop.SetActive(true);
                initCall.GetComponent<PlayCardUI>().notPop.SetActive(true);
            }
        }
        else
        {
            while (edited[lordInit] && (!lord[lordInit]))
            {
                nextChoice();
            }
            currentChoice = players[lordInit];
            if (currentChoice == players[0])
            {
                currentChoice.GetComponent<LordUI>().notGrab.SetActive(true);
                currentChoice.GetComponent<LordUI>().grab.SetActive(true);
            }
        }
    }
}
