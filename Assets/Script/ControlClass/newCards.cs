using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCards : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject g = Instantiate(Resources.Load<GameObject>("CardInitiate"));
        g.GetComponent<Cardinit>().dealcards = this.GetComponent<ServerInterface>().dealcard;
        g.transform.parent = this.transform;
        /*LordUI ldui=this.transform.Find("Desk").GetComponent<LordModel>().currentChoice.GetComponent<LordUI>();
        ldui.call.SetActive(true);
        ldui.notCall.SetActive(true);*/
    }

    // Update is called once per frame
}
