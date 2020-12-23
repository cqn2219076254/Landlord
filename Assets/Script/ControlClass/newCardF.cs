using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCardF : MonoBehaviour
{
    // Start is called before the first frame update
    public void nStart()
    {
        GameObject g = Instantiate(Resources.Load<GameObject>("fishingInit"));
        g.transform.parent = this.transform;
        g.GetComponent<fCardInit>().fishDeal = this.GetComponent<ServerInterface>().fishDCards;
    }
}
