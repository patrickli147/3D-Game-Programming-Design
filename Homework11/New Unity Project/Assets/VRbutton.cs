using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
 
public class VRbutton : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject plane;
    public GameObject VRbutton_up;
    public GameObject VRbutton_down;
    public VirtualButtonBehaviour[] VRbehaviours;

    void Start()
    {
        VRbehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < VRbehaviours.Length; i++)
        {
            VRbehaviours[i].RegisterEventHandler(this);
        }
        plane = GameObject.Find("tree");
        VRbutton_up = GameObject.Find("up");
        VRbutton_down = GameObject.Find("down");
        Debug.Log("ready\n");
    }

    void Update()
    {

    }

    public void OnButtonPressed(VirtualButtonBehaviour myButton)
    {        
        plane.transform.position += new Vector3(0, 0.03f, 0);
    }
    
    public void OnButtonReleased(VirtualButtonBehaviour myButton)
    {

    }
}