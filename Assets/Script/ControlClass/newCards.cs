using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCards : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void nStart()
    {
        if (GameObject.Find("Root/Canvas/multi(Clone)/board").transform.childCount != 1)
        {
            GameObject.Find("Root/Canvas/multi(Clone)/board/CardInitiate(Clone)").GetComponent<Cardinit>().selfDestroy();
        }
        GameObject g = Instantiate(Resources.Load<GameObject>("CardInitiate"));
        g.GetComponent<Cardinit>().dealcards = GameObject.Find("Root/Canvas/multi(Clone)/board").GetComponent<ServerInterface>().dealcard;
        g.transform.parent = GameObject.Find("Root/Canvas/multi(Clone)/board").transform;
    }

    // Update is called once per frame
}