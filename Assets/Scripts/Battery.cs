using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Battery : MonoBehaviour
{
    public GameObject outLine;//正极连接的线
    public GameObject inLine;//负极连接的线

    /// <summary>
    /// 开始通电
    /// </summary>
    public void StartPower()
    {
        if (outLine != null)
        {
            //Debug.Log("电池开始通电");
            outLine.GetComponent<Line>().Power();
        }
    }
}
