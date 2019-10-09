using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using UnityEngine.UI;

public class InterfaceGUI : MonoBehaviour {
    UserAction UserActionController;
    public GameObject t;
    bool state = false;
    float Timer;
    float Now;
    int round = 1;
    void Start () {
        UserActionController = SSDirector.getInstance().currentScenceController as UserAction;
        Timer = Time.time;
    }

    private void OnGUI()
    {
        
        if(!state) Timer = Time.time;Debug.Log(UserActionController.GetScore().ToString() + "  时间:  " + ((int)(Time.time - Timer)).ToString() + "  第" + round + "轮");
        GUI.Label(new Rect(50, 50, 500, 500),"得分: " + UserActionController.GetScore().ToString() + "  时间:  " + ((int)(Time.time - Timer)).ToString() + "  第" + round + "轮");
        if (!state && GUI.Button(new Rect(Screen.width / 2 - 30, Screen.height / 2 - 30, 100, 50), "开始"))
        {
            Timer = Time.time;
            state = true;
            UserActionController.Restart();
        }
        if (state)
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
                    state = false;
                }
            }
        }
    }
}
