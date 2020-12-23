using UnityEngine;
public class Game2CardUI : MonoBehaviour
{
    public Game2Card card;
    public Game2Player host;
    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Debug.Log(hits);
            RaycastHit2D hit = hits[0];
            for(int i = 1; i < hits.Length; i++)
            {
                if(hit.collider.GetComponent<SpriteRenderer>().sortingOrder< hits[i].collider.GetComponent<SpriteRenderer>().sortingOrder)
                {
                    hit = hits[i];
                }
            }
            Game2CardUI UI = hit.collider.gameObject.GetComponent<Game2CardUI>();
            Debug.Log(UI.card);
            Debug.Log(UI.host);
            if (UI.card.host.Equals("player")) //这里需要添加card的host即Player的Pickedlist!!!!!!!!!!!!!
            {
                if (!UI.card.picked)
                {
                    UI.transform.position += (float) 0.5 * Vector3.up;
                    UI.card.picked = true;
                    host.pickedlist.Add(UI.card);
                }
                else
                {
                    UI.transform.position -= (float) 0.5 * Vector3.up;
                    UI.card.picked = false;
                    host.pickedlist.Remove(UI.card);
                }
            }
            else if (UI.card.host.Equals("computer"))
            {
                
            }
        }
    }
}