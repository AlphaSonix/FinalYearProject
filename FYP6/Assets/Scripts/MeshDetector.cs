using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDetector : MonoBehaviour
{
    //public AudioClip aClip;
    //public AudioSource myAudioSource;
    [HideInInspector]
    public string itemName;
    private bool itsTouched = false;
    public bool isAnswered = false;
    public GameObject panel;
    public bool isCorrect = false;
    public GameObject chest;
    GameObject currentChest;
    //private Transform panelObj;
    GameObject T1, T2, T3, T4, T5, T6, T7;
    public GameObject clickedChest = null;
    private Animator chestAnimatorRef;

    public static AnswersScript answers;

    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        GET_TOUCH();
    }
    void DestroyMe()
    {
        Destroy(panel);
    }

    public void questionAnswered()
    {
        isAnswered = true;
    }

    public void correct()
    {
        isCorrect = true; 
    }

    //Opens chests. Will be called by AnswersScript once correct answer is picked
    public void openChest()
    {
        anim.SetBool("isCorrect", true);
        //chestAnimatorRef.SetBool("isCorrect", true);
        gameObject.tag = "OpenedChest";

    }


    private IEnumerator CorrectAnswer()
    {
        //myAudioSource.clip = aClip;
        //myAudioSource.Play();
        yield return new WaitForSeconds(2);
        //panel.gameObject.SetActive(false);
        

        //DestroyMe();
    }

    // Start is called before the first frame update
    void Start()
    {
        T1 = GameObject.Find("box_Gold_Round");
        T2 = GameObject.Find("box_Gold_Round2");
        T3 = GameObject.Find("box_Gold_Round3");
        T4 = GameObject.Find("box_Gold_Round4");
        T5 = GameObject.Find("box_Gold_Round5");
        T6 = GameObject.Find("box_Gold_Round6");
        T7 = GameObject.Find("box_Gold_Round7");
        anim = chest.GetComponent<Animator>();
        //chestAnimatorRef = GetComponent<Animator>();

        GameObject.FindGameObjectWithTag("Postcard").SetActive(false);
    }


    private void GET_TOUCH()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) //; Input.GetMouseButtonDown(0))
        {
            try
            {
                Animator clickedChest = null;
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); //.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    clickedChest = hit.collider.GetComponent<Animator>();
                    chestAnimatorRef = clickedChest;
                    itemName = hit.transform.name;
                    if (itemName == "box_Gold_Round")
                    {
                        if (!isAnswered)
                        {
                            T1.transform.Find("QuestionPanelTemplate").gameObject.SetActive(true);
                            print("isAnswered is" + isAnswered);
        
                            if (isCorrect)
                            {
                                questionAnswered();
                            }
                        }
                        if (isAnswered)
                        {
                            print("isAnswered is" + isAnswered);
                            if (clickedChest.name == "box_Gold_Round")
                            {
                                //openChest();
                                StartCoroutine(CorrectAnswer());
                            }
                        }
                    }
                    else if (itemName == "box_Gold_Round2")
                    {
                        if (isAnswered == false)
                        {
                            T2.transform.Find("QuestionPanelTemplate2").gameObject.SetActive(true);
                            if (isCorrect)
                            {
                                questionAnswered();
                            }

                        }
                        if (isAnswered == true)
                        {
                            if (clickedChest.name == "box_Gold_Round2")
                            {
                                //openChest();
                                StartCoroutine(CorrectAnswer());
                            }
                        }
                    }
                    else if (itemName == "box_Gold_Round3")
                    {
                        if (isAnswered == false)
                        {
                            T3.transform.Find("QuestionPanelTemplate3").gameObject.SetActive(true);

                        }
                        if (isAnswered == true)
                        {
                            if (clickedChest.name == "box_Gold_Round3")
                            {
                                //openChest();
                                StartCoroutine(CorrectAnswer());
                            }
                        }
                    }
                    else if (itemName == "box_Gold_Round4")
                    {
                        if (isAnswered == false)
                        {
                            T4.transform.Find("QuestionPanelTemplate4").gameObject.SetActive(true);

                        }
                        if (isAnswered == true || answers.isCorrect)
                        {
                            if (clickedChest.name == "box_Gold_Round4")
                            {
                                //openChest();
                                StartCoroutine(CorrectAnswer());
                            }
                        }
                    }
                    else if (itemName == "box_Gold_Round5")
                    {
                        if (isAnswered == false)
                        {
                            T5.transform.Find("QuestionPanelTemplate5").gameObject.SetActive(true);

                        }
                        if (isAnswered == true)
                        {
                            if (clickedChest.name == "box_Gold_Round5")
                            {
                                //openChest();
                                StartCoroutine(CorrectAnswer());
                            }
                        }
                    }
                    else if (itemName == "box_Gold_Round6")
                    {
                        if (isAnswered == false)
                        {
                            T6.transform.Find("QuestionPanelTemplate6").gameObject.SetActive(true);

                        }
                        if (isAnswered == true)
                        {
                            if (clickedChest.name == "box_Gold_Round6")
                            {
                                //openChest();
                                StartCoroutine(CorrectAnswer());
                            }
                        }
                    }
                    else if (itemName == "box_Gold_Round7")
                    {
                        if (isAnswered == false)
                        {
                            T7.transform.Find("QuestionPanelTemplate7").gameObject.SetActive(true);

                        }
                        if (isAnswered == true)
                        {
                            if (clickedChest.name == "box_Gold_Round7")
                            {
                                print("isAnswered is called");
                                //openChest();
                                StartCoroutine(CorrectAnswer());
                            }
                        }
                    }
                }
            }
            catch (System.NullReferenceException)
            {
                // Nothing method
            }
 
        }
    
    }
}
