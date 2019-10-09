using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
public class CCActionManager : SSActionManager, SSActionCallback
{
    int count = 0;
    public SSActionEventType Complete = SSActionEventType.Completed;

    public void MoveDisk(Disk Disk)
    {
        count++;
        Complete = SSActionEventType.Started;
        CCMoveToAction action = CCMoveToAction.getAction(Disk.speed);
        addAction(Disk.gameObject, action, this);
    }

    public void SSActionCallback(SSAction source) //
    {
        count--;
        Complete = SSActionEventType.Completed;
        source.gameObject.SetActive(false);
    }

    public bool IsAllFinished() //
    {
        if (count == 0) return true;
        else return false;
    }
}