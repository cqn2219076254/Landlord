using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class FishSound : MonoBehaviour
{
    public AudioSource Effect;
    public string rscdir = "Sound/FishSound/";
    public List<string> ma = new List<string> {"1", "2", "3", "4", "5", "6", "7", "8"};
    public Button pop;

    public int i;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        pop.onClick.AddListener(PlaySound);
    }

    public void PlaySound()
    {
        Effect = gameObject.AddComponent<AudioSource>();
        Effect.volume = 20;
        Debug.Log(i);
        Debug.Log(ma[i]);
        AudioClip clip = Resources.Load<AudioClip>(rscdir + ma[i]);
        Effect.clip = clip;
        Effect.Play();
        i++;
        i %= 8;
    }
}
