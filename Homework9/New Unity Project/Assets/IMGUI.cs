﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IMGUI : MonoBehaviour
{
    // 当前血量
    public float health = 0.0f;
    // 增/减后血量
    private float resulthealth;

    public Slider healthSlider;

    private Rect HealthBar;
    private Rect HealthUp;
    private Rect HealthDown;
    private Rect HealthPoint;

    void Start()
    {
        //血条区域
        HealthBar = new Rect(50, 50, 200, 20);
        //血量
        HealthPoint = new Rect(50, 50, 200, 30);
        //加血按钮区域  
        HealthUp = new Rect(105, 80, 40, 20);
        //减血按钮区域
        HealthDown = new Rect(155, 80, 40, 20);
        resulthealth = health;
    }

    void OnGUI()
    {
        if (GUI.Button(HealthUp, "加血"))
        {
            resulthealth = resulthealth + 0.1f > 1.0f ? 1.0f : resulthealth + 0.1f;
        }
        if (GUI.Button(HealthDown, "减血"))
        {
            resulthealth = resulthealth - 0.1f < 0.0f ? 0.0f : resulthealth - 0.1f;
        }

        //插值计算health值，以实现血条值平滑变化
        health = Mathf.Lerp(health, resulthealth, 0.05f);

        // 用水平滚动条的宽度作为血条的显示值
        GUI.HorizontalScrollbar(HealthBar, 0.0f, health, 0.0f, 1.0f);

        GUILayout.TextArea("Health:" + (resulthealth * 100).ToString("N"), 200);

        healthSlider.value = health;
    }
}