using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GPSInit : MonoBehaviour
{
    string message; //"Initialising GPS...";
    float thisLat;
    float thisLon;
    private double distance;
    private Vector3 TargetPosition;
    private Vector3 OriginalPosition;
    public float Radius = 5f; //Range that Target Marker covers
    public float TimeUpdate = 3f; //Compares current coordinates with target
    string newLat;
    string newLon;
    public float[] lat;
    public float[] lon;
    internal int PointCounter = 0; //Amount of markers to check in the GPSInit
    public GameObject[] TargetPopUp; //the UI pages that pop up user reaches within radius
    public bool TargetPopUpOneTime = false; //checks to make sure popup appears only one time when user is in range of target

    public GameObject[] PointObjects; //list of objects for each point

    public UnityEvent EventStartGPS;
    public UnityEvent EventAtGPSPoint;
    public UnityEvent EventOutsideGPSPoint;

    public GameObject NoGPSPopUp;
    public bool NoGPSPopUpOneTime = false;

    public AudioClip aClip;
    public AudioSource myAudioSource;
    bool hasPlayed = false;

    private void OnGUI() //Renders and Handles GUI
    {
        GUI.skin.label.fontSize = 30; //May need to be changed
        GUI.Label(new Rect(30, 30, 1000, 1000), message);
    }

    // Calls the GPS connection and connects to satellite
    void Start()
    {
        Input.location.Start();
        StartCoroutine("GPSProcess");

        if (EventStartGPS != null)
        {
            EventStartGPS.Invoke();
        }
        myAudioSource = GetComponent<AudioSource>();
    }

    public IEnumerator GPSProcess()
    {
        while(true)
        {
            yield return new WaitForSeconds(TimeUpdate);
            message = "Starting GPS...";
            if (!Input.location.isEnabledByUser) {
                message = "GPS is not active";
                NoGPSPopUp.SetActive(true);
                yield break;
            }
            
            if (Input.location.isEnabledByUser == true)
            {
                Input.location.Start(0.1f,0.1f); //accuracy, displacement

                int maxWait = 40;
                while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
                {
                    yield return new WaitForSeconds(1);
                    maxWait--;
                }

                if (maxWait < 1)
                {
                    message += "Timed out \n";
                    yield break;
                }

                thisLat = Input.location.lastData.latitude;
                newLat = thisLat.ToString();

                thisLon = Input.location.lastData.longitude;
                newLon = thisLon.ToString();

                Calc(lat[PointCounter], lon[PointCounter], thisLat, thisLon);
                message = "GPS is active";
            } 

        }
    }

    //Compares distance between user and target value
    public void Calc(float lat1, float lon1, float lat2, float lon2)
    {
        var R = 6378.137; // radius of earth in km
        var dLat = lat2 * Mathf.PI / 180 - lat1 * Mathf.PI / 180;
        var dLon = lon2 * Mathf.PI / 180 - lon1 * Mathf.PI / 180;
        float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
            Mathf.Cos(lat1 * Mathf.PI / 180) * Mathf.Cos(lat2 * Mathf.PI / 180) *
            Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);
        var c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        distance = R * c;
        distance = distance * 1000f;
        float distanceFloat = (float)distance;
        TargetPosition = OriginalPosition - new Vector3(0, 0, distanceFloat * 12);

        //original code - objects and UI appear if within radius
        if (distance < Radius)
        {
            if (TargetPopUpOneTime == false)
            {
                for (int i = 0; i < TargetPopUp.Length; i++)
                {
                    TargetPopUp[i].SetActive(false);
                    PointObjects[i].SetActive(false);
                }
                TargetPopUp[PointCounter].SetActive(true);
                PointObjects[PointCounter].SetActive(true);

                if (EventAtGPSPoint != null) { 
                EventAtGPSPoint.Invoke();
                }
            }
        } if (distance > Radius) 
        {
            for (int i = 0; i < TargetPopUp.Length; i++)
            {
                TargetPopUp[i].SetActive(false);
                PointObjects[i].SetActive(false);
            }
            PointCounter++;

            if(PointCounter == lat.Length)
            {
                PointCounter = 0;
            }
            if (EventOutsideGPSPoint != null) { 
            EventOutsideGPSPoint.Invoke();
           }
        }
    }

    public void HideTargetPopUp()
    {
        TargetPopUp[PointCounter].SetActive(false);
        PointObjects[PointCounter].SetActive(false);
        TargetPopUpOneTime = true;
    }

    public void HideNoGPSPopUp()
    {
        NoGPSPopUp.SetActive(false);
    }

    void stopUpdate()
    {
        TimeUpdate = 60f; 
    }

    void resumeUpdate()
    {
        TimeUpdate = 3f;
    }

    void radiusBeep()
    {
        
            myAudioSource.clip = aClip;
            myAudioSource.PlayOneShot(aClip);
        
    }

}
