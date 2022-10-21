using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 管理鼠标点击
/// </summary>
public class CursorManager : Singleton<CursorManager>
{
    private Vector3 mouseWorldPos =>
    Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //检测鼠标互动情况
            ClickAction(ObjectAtMousePosition().gameObject);
        }
    }
    private void ClickAction(GameObject clickObject)
    {
        if (clickObject != null)
        {
            switch (clickObject.tag)
            {
                case "Line":
                    var line = clickObject.GetComponent<Line>();
                    line?.Rotate();
                    Level_01Manager.Instance.StartPowerCommand();
                    break;
            }
        }
    }
    /// <summary>
    /// 检测鼠标点击范围的碰撞体
    /// </summary>
    /// <returns></returns>
    private Collider2D ObjectAtMousePosition()
    {
        return Physics2D.OverlapPoint(mouseWorldPos);
    }
}