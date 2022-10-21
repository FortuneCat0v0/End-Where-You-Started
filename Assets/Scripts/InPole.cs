using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 负极
/// </summary>
public class InPole : MonoBehaviour
{
    public Battery battery;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            //Debug.Log("连接到线路");
            battery.inLine = other.transform.parent.parent.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            //Debug.Log("断开线路");
            battery.inLine = null;
        }
    }
}
