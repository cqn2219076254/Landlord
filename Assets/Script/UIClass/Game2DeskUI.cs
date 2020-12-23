using System.Collections.Generic;
using UnityEngine;

public class Game2DeskUI : MonoBehaviour
{
    public GameObject player;
    public GameObject computer;
    public List<Game2Card> displayCard = new List<Game2Card>();

    public void showMyCard(List<Game2Card> cards)
    {
        this.clearDesk();
        Vector3 z = new Vector3(0, 0, 0);
        z = new Vector3((float)(-0.5 * (cards.Count - 1) / 2.0), (float)-0.5, 0);
        Vector3 f = new Vector3((float)0.5, 0, 0);
        cards.Reverse();
        Debug.Log("done");
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].UIS.transform.position = z + i * f;
            cards[i].host = "";
            displayCard.Add(cards[i]);
        }
        cards.Clear();
    }

    public void updateHasCard(List<Game2Card> hadCards)
    {
        Game2RoundModel round = this.GetComponent<Game2RoundModel>();
        if(round.CurrentCharacter == player.GetComponent<Game2Player>())
        {
            Vector3 zs = new Vector3((float)(-0.5 * (hadCards.Count - 1) / 2.0), (float)-4.5, 0);
            Vector3 f = new Vector3((float)0.5, 0, 0);
            for (int i = 0; i < hadCards.Count; i++)
            {
                hadCards[i].UIS.transform.position = zs + i * f;
            }
        }
        else
        {
            Vector3 zs = new Vector3((float)(-0.5 * (hadCards.Count - 1) / 2.0), (float)1.7, 0);
            Vector3 f = new Vector3((float)0.5, 0, 0);
            for (int i = 0; i < hadCards.Count; i++)
            {
                hadCards[i].UIS.transform.position = zs + i * f;
            }
        }
    }

    public void clearDesk()
    {
        if (displayCard.Count != 0)
        {
            for (int i = 0; i < displayCard.Count; i++)
            {
                displayCard[i].UIS.gameObject.SetActive(false);
            }
            displayCard.Clear();
        }
    }
}
