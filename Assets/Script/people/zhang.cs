using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class zhang : MonoBehaviour
{
    public Image zhang1;
    public Image zhang2;
    public Image zhang3;

    public Image zhu1;
    public Image zhu2;
    
    public Image yao1;
    public Image yao2;
    public Image yao3;

    private int x;
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        StartCoroutine(Zhang());
    }

    IEnumerator Zhang()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            x++;
            switch (x % 3)
            {
                case 0:
                    zhang1.gameObject.SetActive(true);
                    zhang2.gameObject.SetActive(false);
                    zhang3.gameObject.SetActive(false);
                    // yao1.gameObject.SetActive(true);
                    // yao2.gameObject.SetActive(false);
                    // yao3.gameObject.SetActive(false);
                    break;
                case 1:
                    zhang1.gameObject.SetActive(false);
                    zhang2.gameObject.SetActive(true);
                    zhang3.gameObject.SetActive(false);
                    // yao1.gameObject.SetActive(false);
                    // yao2.gameObject.SetActive(true);
                    // yao3.gameObject.SetActive(false);
                    break;
                case 2:
                    zhang1.gameObject.SetActive(false);
                    zhang2.gameObject.SetActive(false);
                    zhang3.gameObject.SetActive(true);
                    // yao1.gameObject.SetActive(false);
                    // yao2.gameObject.SetActive(false);
                    // yao3.gameObject.SetActive(true);
                    break;
            }
            
            switch (x % 2)
            {
                case 0:
                    zhu1.gameObject.SetActive(true);
                    zhu2.gameObject.SetActive(false);
                    yao1.gameObject.SetActive(true);
                    yao2.gameObject.SetActive(false);
                    break;
                case 1:
                    zhu1.gameObject.SetActive(false);
                    zhu2.gameObject.SetActive(true);
                    yao1.gameObject.SetActive(false);
                    yao2.gameObject.SetActive(true);
                    break;
            }
        }
    }
}
