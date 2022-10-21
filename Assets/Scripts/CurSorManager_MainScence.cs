using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurSorManager_MainScence : Singleton<CurSorManager_MainScence>
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
                    LevelManager.Instance.StartPowerCommand();
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
