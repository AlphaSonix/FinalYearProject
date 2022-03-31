using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Vuforia;

public class ARManager : MonoBehaviour
{
    public PlaneFinderBehaviour planeFinder;
    ContentPositioningBehaviour contentPositioningBehaviour;
    float touchesPrePosDifference, touchesCurPosDifference, zoomModifier;
    Vector2 Test;

    public GameObject obj; //shows the position of the object
    public bool ShowModelState = false;
    
    public bool CanSupport = false; //whether device can support vuforia
    private string consoleString; 

    //checks whether device can support surface tracking with the Ground Plane
    void HandleLog(string message, string stacktrace, LogType type)
    {
        consoleString = consoleString + "\n" + message;
        if (consoleString.Contains("SmartTerrain failed"))
        {
            CanSupport = false;
            print("This device cannot support surface tracking");
        } else
        {
            CanSupport = true;
            print("This device can support surface tracking");
        }
    }

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    
    //Enables Model
    public void LaunchModel()
    {
        planeFinder.PerformHitTest(Test);
        ShowModel();
    }

    //When within the radius, the model will be shown
    public void ShowModel()
    {

        obj.SetActive(true);
        ShowModelState = true;

    }

    //When outside of the radius, the model will be hidden
    public void HideModel()
    {
    
        obj.SetActive(false); 
        ShowModelState = false;
    }

    public void ResetTrackers()
    {

        VuforiaBehaviour.Instance.DevicePoseBehaviour.Reset();
    }

}
