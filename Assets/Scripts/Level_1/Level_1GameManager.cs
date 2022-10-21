using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_1GameManager : Singleton<Level_1GameManager>
{
    public void ResetGame()
    {
        SceneManager.LoadScene(1);
    }
    public void NextGame()
    {
        SceneManager.LoadScene(2);
    }
}
