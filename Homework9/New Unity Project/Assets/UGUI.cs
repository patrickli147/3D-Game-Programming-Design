using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGUI : MonoBehaviour {
    //外侧的血条边框
    public RectTransform rectBloodPos;
    //内侧的血条
    public RectTransform blood;
    //减少的血条，先要将内部血条设为stretch，然后这里的reduceBlood对应right属性
    public int reduceBlood = 0;
    void Update()
    {
        //为了保证物体移动的时候血条跟着动
        Vector2 vec2 = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
        rectBloodPos.anchoredPosition = new Vector2(vec2.x - Screen.width / 2 + 0, vec2.y - Screen.height / 2 + 60);
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(20, 30, 40, 20), "加血"))
        {
            reduceBlood -= 10;
            if(reduceBlood < 0)
            {
                reduceBlood = 0;
            }
        }
        if (GUI.Button(new Rect(70, 30, 40, 20), "减血"))
        {
            reduceBlood += 10;
            if(reduceBlood > 200)
            {
                reduceBlood = 200;
            }
        }
    }
}
