using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_01Manager : Singleton<Level_01Manager>
{
    public GameObject gameoverUI;
    public Battery battery;
    public Line Like;
    public Line Coin;
    public Line Collect;
    [Header("场景中存在的线")]
    public GameObject[] lines;
    private void Start()
    {
        lines = GameObject.FindGameObjectsWithTag("Line");
    }
    public void StartPowerCommand()
    {
        //重置所有线的状态
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i].GetComponent<Line>().ResetStatic();
        }

        //这里需要延迟调用一下，因为通过OnTrigger添加对象会有延迟
        Invoke("StartPower", 0.5f);

        //这里需要延迟调运一下，因为电路的递归需要点时间
        Invoke("isGameOver", 0.5f);
    }
    private void StartPower()
    {
        battery.StartPower();
    }

    private void isGameOver()
    {
        GameObject gameObject = battery.inLine;
        if (gameObject != null)
        {
            if (gameObject.GetComponent<Line>().isPower && Like.isPower &&
                Coin.isPower && Collect.isPower)
                GameOver();
        }
    }
    private void GameOver()
    {
        gameoverUI.SetActive(true);
        Debug.Log("GameOver");
    }
}