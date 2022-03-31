using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswersScript : MonoBehaviour
{
    public AudioClip aClip;
    public AudioSource myAudioSource;
    private bool hasPlayed = false;

    public bool isCorrect = false;
    public GameManager gameManager;
    private GameObject chest;
    private bool openChest;

    public static MeshDetector md;
    private BlockUI blockUI;
    RevealPostcard revealPostcard; //rp1, rp2, rp3, rp4, rp5, rp6, rp7; //RevealPostcards 
    public GameObject go;
    
    public Color startColor;

    //private void Start()
    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
        startColor = GetComponent<Image>().color;
        md = GameObject.FindGameObjectWithTag("Chest").GetComponent<MeshDetector>();
        revealPostcard = GameObject.Find("Treasure Chests").GetComponent<RevealPostcard>();
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
        blockUI = GameObject.FindGameObjectWithTag("Button").GetComponent<BlockUI>();
        md.isAnswered = false;
    }

    private IEnumerator onDelay()
    {
        print("onDelay is working");
        yield return new WaitForSeconds(2);
    }

    public void Answer()
    {
        if (isCorrect) //Will change correct answer to green if chosen
        {
            GetComponent<Image>().color = Color.green;
            if (!hasPlayed)
            {
                myAudioSource.clip = aClip;
                myAudioSource.PlayOneShot(aClip);
                hasPlayed = true;
            }
            gameManager.correct();
            print("Chest Opened");
            md.openChest();
            //onDelay();
            revealPostcard.getPrize(); 
            blockUI.blockInteract(); //blocks player from interacting with other buttons on the canvas
            
        } else 
        {
            GetComponent<Image>().color = Color.red; // will display red if play presses button with incorrect option
            
            if (!hasPlayed)
            {
                myAudioSource.clip = aClip;
                myAudioSource.PlayOneShot(aClip);
                hasPlayed = true;
            }

            blockUI.blockInteract();
            gameManager.wrong();
        }
    }
}
