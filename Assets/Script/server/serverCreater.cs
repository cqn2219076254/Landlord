using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serverCreater : MonoBehaviour
{
    List<cardData> dataset = new List<cardData>();
    Queue<cardData> dealcards = new Queue<cardData>();
    public void CreateCard()
    {
        Debug.Log("create");
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                dataset.Add(new cardData(j, i));
            }
        }
        dataset.Add(new cardData(14, 5));
        dataset.Add(new cardData(15, 5));
    }
    public void Shuffle()
    {
        Debug.Log("shuffle");
        List<cardData> shuffle = new List<cardData>();
        foreach(cardData crd in dataset)
        {
            int index = Random.Range(0, shuffle.Count + 1);
            shuffle.Insert(index, crd);
        }
        foreach (cardData crd in shuffle)
        {
            dealcards.Enqueue(crd);
        }
        shuffle.Clear();
        dataset.Clear();
    }
    // Start is called before the first frame update
    void Start()
    {
        dataset.Clear();
        dealcards.Clear();
        CreateCard();
        Shuffle();
    }
}
