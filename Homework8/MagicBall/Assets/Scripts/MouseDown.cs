using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDown : MonoBehaviour
{

    public GameObject obj;
    public int show_time = 8;                      
    void Start()
    {
        obj.SetActive(false);
        StartCoroutine(ShowTip());
    }

    void OnMouseDown()
    {
        if (obj.active == true)
        {
            obj.SetActive(false);
        }
        else
        {
            obj.SetActive(true);
        }
    }
    private void OnGUI()
    {
        if (show_time > 0)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, 30, 150, 150), "粒子系统");
        }
    }
    public IEnumerator ShowTip()
    {
        while (show_time >= 0)
        {
            yield return new WaitForSeconds(1);
            show_time--;
        }
    }
}
