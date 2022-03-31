using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockUI : MonoBehaviour
{
    private CanvasGroup rayCanvas;
    public static AnswersScript answerScript;
    bool buttonPressed;
    public GameObject button;
    //public GameObject[] buttons;
    //public GameObject panel;
    //GameObject[] arr = GameObject.FindGameObjectsWithTag("Button");
    //public bool isCorrect;


    public void blockInteract()
    {
        // while (gameObject.tag == "Button")
        {
         button = GameObject.FindGameObjectWithTag("Button");

        button.GetComponent<CanvasGroup>().interactable = false;

            if (gameObject.tag == "Button")
           {
             gameObject.tag = "ButtonPressed";
           }
        }
    }

    public void uninteract()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.interactable = false;
    }
    /*
     public void blockInteract()
    {
        //GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
      //  foreach (GameObject button in buttons)
      //  {
           // Debug.Log(button.name);
           // buttons = GameObject.FindGameObjectsWithTag("Button");
        for (int i = 0; i < buttons.Length; ++i)
        {
           buttons[i].GetComponent<CanvasGroup>().interactable = false;
            i++;
        }
    }
    */

    // Start is called before the first frame update
    void Start()
    {
        rayCanvas = gameObject.GetComponent<CanvasGroup>();
        //buttons = GameObject.FindGameObjectsWithTag("Button");
        //button = GameObject.FindGameObjectWithTag("Button");
        //answerScript = GetComponent<AnswersScript>();
        //buttonPressed.setBool(aS.isCorrect, false);
    }

    // Update is called once per frame
    void Update()
    {
       /* if (answerScript.Answer())//Input.GetMouseButton(0))// (Input.touchCount == 1)
        {
            //rayCanvas.IsInteractable(false);
            GameObject button = GameObject.FindGameObjectWithTag("Button");
            button.GetComponent<CanvasGroup>().interactable = false;
        } */
    }
}
