using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

public class Line : MonoBehaviour
{
    public bool isPower;
    public List<GameObject> nextLines = new List<GameObject>();
    public SpriteRenderer spriteRenderer;

    private Light2D light2D;
    // public void OnPointerClick(PointerEventData eventData)
    // {
    //     Debug.Log("点击到");
    //     if (eventData.button == PointerEventData.InputButton.Left)
    //     {
    //         this.transform.Rotate(0, 0, -90);
    //     }
    // }
    private void Start()
    {
        light2D = GetComponent<Light2D>();
    }
    public void Rotate()
    {
        this.transform.Rotate(0, 0, -90);
    }
    public void AddNextLine(GameObject line)
    {
        nextLines.Add(line);
    }
    public void DeleteNextLine(GameObject line)
    {
        nextLines.Remove(line);
    }

    /// <summary>
    /// 通电递归
    /// </summary>
    public void Power()
    {
        Debug.Log(this.transform.name + "通电了");
        isPower = true;
        // 通电效果
        SetLuminance(true);
        //给连接的线路通电
        foreach (GameObject nextLine in nextLines)
        {
            var line = nextLine.GetComponent<Line>();
            if (!line.isPower)
            {
                line.Power();
            }
        }
    }

    /// <summary>
    /// 重置状态
    /// </summary>
    public void ResetStatic()
    {
        isPower = false;
        SetLuminance(false);
    }
    /// <summary>
    /// 通电后颜色变化
    /// </summary>
    /// <param name="p">true变红/false变会原来的颜色</param>
    public void SetLuminance(bool p)
    {
        if (p)
        {
            light2D.intensity = 2f;
            //spriteRenderer.color = new Color32(240, 124, 130, 255);
        }
        else
        {
            light2D.intensity = 0;
            //spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        }

    }
}

