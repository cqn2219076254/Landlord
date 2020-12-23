using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardData : MonoBehaviour
{
    public int value;
    public int color;
    // Start is called before the first frame update
    public cardData(int value,int color)
    {
        this.value = value;
        this.color = color;
    }
}