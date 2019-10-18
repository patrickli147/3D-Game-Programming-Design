﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using UnityEngine.UI;
 
public class InterfaceGUI : MonoBehaviour {
    UserAction UserActionController;
    ISceneController SceneController;
    public GameObject t;
    bool ss = false;
    float S;
    float Now;
    int round = 1;
    void Start () {
        UserActionController = SSDirector.getInstance().currentScenceController as UserAction;
        SceneController = SSDirector.getInstance().currentScenceController as ISceneController;
        S = Time.time;
    }

    private void OnGUI()
    {
        if(!ss) S = Time.time;
        GUI.Label(new Rect(50, 50, 500, 500),"得分: " + UserActionController.GetScore().ToString() + "  时间:  " + ((int)(Time.time - S)).ToString() + "  第" + round + "轮");
        if (!ss && GUI.Button(new Rect(Screen.width / 2 - 30, Screen.height / 2 - 30, 100, 50), "Start"))
        {
            S = Time.time;
            ss = true;
            UserActionController.Restart();
            SceneController.LoadResources();
        }
        if (ss)
        {
            round = UserActionController.GetRound();
            if (Input.GetButtonDown("Fire1"))
            {

                Vector3 pos = Input.mousePosition;
                UserActionController.Hit(pos);

            }
            if (round > 4)
            {
                round = 4;
                if (UserActionController.RoundStop())
                {
                    ss = false;
                }
            }
        }
    }
}
