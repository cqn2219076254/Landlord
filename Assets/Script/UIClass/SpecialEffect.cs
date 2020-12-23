using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffect : MonoBehaviour
{
    
    void Start()
    {
        Invoke("destory", 2f);
    }

    void destory()
    {
        DestroyImmediate(this.gameObject);
    }

}
