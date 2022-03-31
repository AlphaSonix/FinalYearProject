using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealPostcard : MonoBehaviour
{
    GameObject P1, P2, P3, P4, P5, P6, P7;
    MeshDetector md; 

    // Start is called before the first frame update
    void Start()
    {
        P1 = GameObject.Find("box_Gold_Round");
        P2 = GameObject.Find("box_Gold_Round2");
        P3 = GameObject.Find("box_Gold_Round3");
        P4 = GameObject.Find("box_Gold_Round4");
        P5 = GameObject.Find("box_Gold_Round5");
        P6 = GameObject.Find("box_Gold_Round6");
        P7 = GameObject.Find("box_Gold_Round7");

        md = GameObject.FindGameObjectWithTag("Chest").GetComponent<MeshDetector>();
    }

    public void getPrize()
    {
        Debug.Log("getPrize is called");
        if (md.itemName == "box_Gold_Round")
        {
            P1.transform.Find("Postcard1").gameObject.SetActive(true);
        } else if (md.itemName == "box_Gold_Round2")
        {
            Debug.Log(md.itemName + " is called");
            P2.transform.Find("Postcard2").gameObject.SetActive(true);
        }
        else if (md.itemName == "box_Gold_Round3")
        {
            P3.transform.Find("Postcard3").gameObject.SetActive(true);
        }
        else if (md.itemName == "box_Gold_Round4")
        {
            P4.transform.Find("Postcard4").gameObject.SetActive(true);
        }
        else if (md.itemName == "box_Gold_Round5")
        {
            P5.transform.Find("Postcard5").gameObject.SetActive(true);
        }
        else if (md.itemName == "box_Gold_Round6")
        {
            P6.transform.Find("Postcard6").gameObject.SetActive(true);
        }
        else if (md.itemName == "box_Gold_Round7")
        {
            P7.transform.Find("Postcard7").gameObject.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
