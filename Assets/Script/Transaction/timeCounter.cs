using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Timer", 1, 1);
    }
    private int s = 30;
    // Update is called once per frame
    private void Timer()
    {
        s--;
        this.GetComponent<Text>().text = string.Format("{0:d2}", s);
        if (s <= 0)
        {
            CancelInvoke("Timer");
        }
    }
}
