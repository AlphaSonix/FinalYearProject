using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject panel;
    public GameObject postcard;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public void exitPanel()
    {
        //if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        //{
            panel.gameObject.SetActive(false);
        //}
    }

    public void closePostcard()
    {
        postcard.gameObject.SetActive(false);
    }
    public void playClip()
    {
        /*
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray 
        }
        */
        audioSource.clip = audioClip;
        audioSource.Play(); //OneShot(audioClip);
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource.GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
  
    }
}
