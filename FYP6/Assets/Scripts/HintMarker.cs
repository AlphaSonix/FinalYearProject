using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintMarker : MonoBehaviour
{
    public GameObject hintPanel;
    // markerActive;
    //[HideInInspector]
    string itemName;
    GameObject Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9;

    //public GameObject markerActive { get; private set; }
    GameObject markerActive; 

    // Start is called before the first frame update
    void Start()
    {
        
        Q1 = GameObject.Find("HintMarker1");
        Q2 = GameObject.Find("HintMarker2");
        Q3 = GameObject.Find("HintMarker3");
        Q4 = GameObject.Find("HintMarker4");
        Q5 = GameObject.Find("HintMarker5");
        Q6 = GameObject.Find("HintMarker6");
        Q7 = GameObject.Find("HintMarker7");
        Q8 = GameObject.Find("HintMarker8");
        Q9 = GameObject.Find("HintMarker9");
        
    }

    void HINT_INTERACT()
    {
        transform.Rotate(new Vector3(0, 0.3f, 0));
        //GET_TOUCH_HINT();
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) //Input.GetMouseButtonDown(0))  
        {
            //try
            //{
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); //mousePosition);   
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                itemName = hit.transform.name;
      
                if (itemName == "HintMarker1")
                {
                    Q1.transform.Find("Marker1").gameObject.SetActive(true);

                }
                else if (itemName == "HintMarker2")
                {
                    Q2.transform.Find("Marker2").gameObject.SetActive(true);
                }
                else if (itemName == "HintMarker3")
                {
                    Q3.transform.Find("Marker3").gameObject.SetActive(true);
                }
                else if (itemName == "HintMarker4")
                {
                    Q4.transform.Find("Marker4").gameObject.SetActive(true);
                }
                else if (itemName == "HintMarker5")
                {
                    Q5.transform.Find("Marker5").gameObject.SetActive(true);
                }
                else if (itemName == "HintMarker6")
                {
                    Q6.transform.Find("Marker6").gameObject.SetActive(true);
                }
                else if (itemName == "HintMarker7")
                {
                    Q7.transform.Find("Marker7").gameObject.SetActive(true);
                }
                else if (itemName == "HintMarker8")
                {
                    Q8.transform.Find("Marker8").gameObject.SetActive(true);
                }
                else if (itemName == "HintMarker9")
                {
                    Q9.transform.Find("Marker9").gameObject.SetActive(true);
                }

            }
        }

    }
// Update is called once per frame
    void Update()
        {
        HINT_INTERACT();
        }

   }

    

