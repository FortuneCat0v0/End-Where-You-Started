using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public GameObject gameoverUI;
    public Transform cameraTransform;
    //地图中各个元件的数量"
    private int NumBattery = 1;
    private int NumLike = 1;
    private int NumCoin = 1;
    private int NumCollect = 1;
    private int Numline_A = 50;
    private int Numline_B = 50;
    private int Numline_C = 50;

    //存储元件位置 
    const int Max_X = 50;
    const int Max_Y = 50;
    private float[,] positions = new float[Max_X, Max_Y];//Unity坐标系

    [Header("各元件Prefab的引用")]
    public GameObject Line_A_Prefab;
    public GameObject Line_B_Prefab;
    public GameObject Line_C_Prefab;
    public GameObject Battery_Prefab;
    public GameObject Like_Prefab;
    public GameObject Coin_Prefab;
    public GameObject Collect_Prefab;


    public Battery battery;
    public Line like;
    public Line coin;
    public Line collect;

    private bool flog = true;//为第一个生成是电池做判断

    [Header("场景中存在的线")]
    public List<GameObject> lines;
    //public GameObject[] lines;

    private void Start()
    {
        cameraTransform.position = new Vector3(12, 12, -10);
        LoadingMap(12, 12);
        //lines = GameObject.FindGameObjectsWithTag("Line");
    }

    /// <summary>
    /// 地图加载
    /// </summary>
    /// <param name="x">x坐标</param>
    /// <param name="y">y坐标</param>
    private void LoadingMap(int x, int y)
    {
        int forword;
        //给元件一个随机的方向
        forword = Random.Range(0, 4);
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, 90 * forword);

        //选择生成元件的类型
        int choose;
        choose = Random.Range(1, 8);

        //保证第一个生成是电池
        if (flog)
        {
            choose = 1;
            flog = false;
        }

        while (true)
        {
            if (choose == 1)
            {
                if (NumBattery <= 0)
                {
                    choose = (choose + 1) % 7;
                    continue;
                }

                NumBattery--;

                battery = Instantiate(Battery_Prefab, new Vector3(x + 0.5f, y + 0.5f, 0),
                    Quaternion.identity).GetComponent<Battery>();
                positions[x, y] = 1;

                LoadingMap(x - 1, y);
                LoadingMap(x + 1, y);

                break;
            }
            else if (choose == 2)
            {
                if (NumLike <= 0)
                {
                    choose = (choose + 1) % 7;
                    continue;
                }

                NumLike--;

                like = Instantiate(Like_Prefab, new Vector3(x + 0.5f, y + 0.5f, 0),
                    Quaternion.identity).GetComponent<Line>();
                positions[x, y] = 1;

                LoadingMap(x - 1, y);
                LoadingMap(x + 1, y);

                break;
            }
            else if (choose == 3)
            {
                if (NumCoin <= 0)
                {
                    choose = (choose + 1) % 7;
                    continue;
                }

                NumCoin--;

                coin = Instantiate(Coin_Prefab, new Vector3(x + 0.5f, y + 0.5f, 0),
                    Quaternion.identity).GetComponent<Line>();
                positions[x, y] = 1;

                LoadingMap(x - 1, y);
                LoadingMap(x + 1, y);

                break;
            }
            else if (choose == 4)
            {
                if (NumCollect <= 0)
                {
                    choose = (choose + 1) % 7;
                    continue;
                }

                NumCollect--;

                collect = Instantiate(Collect_Prefab, new Vector3(x + 0.5f, y + 0.5f, 0),
                    Quaternion.identity).GetComponent<Line>();
                positions[x, y] = 1;

                LoadingMap(x - 1, y);
                LoadingMap(x + 1, y);

                break;
            }
            else if (choose == 5)
            {
                if (Numline_A <= 0)
                {
                    choose = (choose + 1) % 7;
                    continue;
                }

                Numline_A--;

                lines.Add(Instantiate(Line_A_Prefab, new Vector3(x + 0.5f, y + 0.5f, 0),
                    randomRotation));
                positions[x, y] = 1;

                Vector2 nextPoint = NextPoint(x, y);
                if (!(nextPoint.x == 0 && nextPoint.y == 0))
                {
                    LoadingMap((int)nextPoint.x, (int)nextPoint.y);
                }

                break;
            }
            else if (choose == 6)
            {
                if (Numline_B <= 0)
                {
                    choose = (choose + 1) % 7;
                    continue;
                }

                Numline_B--;

                lines.Add(Instantiate(Line_B_Prefab, new Vector3(x + 0.5f, y + 0.5f, 0),
                    randomRotation));
                positions[x, y] = 1;

                Vector2 nextPoint = NextPoint(x, y);
                if (!(nextPoint.x == 0 && nextPoint.y == 0))
                {
                    LoadingMap((int)nextPoint.x, (int)nextPoint.y);
                }

                break;
            }
            else if (choose == 7)
            {
                if (Numline_C <= 0)
                {
                    choose = (choose + 1) % 7;
                    continue;
                }

                Numline_C--;

                lines.Add(Instantiate(Line_C_Prefab, new Vector3(x + 0.5f, y + 0.5f, 0),
                    randomRotation));
                positions[x, y] = 1;

                Vector2 nextPoint = NextPoint(x, y);
                if (!(nextPoint.x == 0 && nextPoint.y == 0))
                {
                    LoadingMap((int)nextPoint.x, (int)nextPoint.y);
                }

                break;
            }
        }
    }

    /// <summary>
    /// 在地址数组中，从该点的四方向找一个空点，用于下一步生成
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    private Vector2 NextPoint(int x, int y)
    {
        //随机选择一个初始方向
        int next;
        next = Random.Range(0, 4);

        int t = 0;
        while (t < 4)
        {

            if (next == 0)
            {
                if (x - 1 >= 0 && positions[x - 1, y] == 0)
                {
                    return new Vector2(x - 1, y);
                }
            }
            else if (next == 1)
            {
                if (y + 1 <= Max_Y && positions[x, y + 1] == 0)
                {
                    return new Vector2(x, y + 1);
                }
            }
            else if (next == 2)
            {
                if (x + 1 <= Max_X && positions[x + 1, y] == 0)
                {
                    return new Vector2(x + 1, y);
                }
            }
            else if (next == 3)
            {
                if (y - 1 > 0 && positions[x, y - 1] == 0)
                {
                    return new Vector2(x, y - 1);
                }
            }
            next = (next + 1) % 4;
            t++;
        }
        return new Vector2(0, 0);
    }
    public void StartPowerCommand()
    {
        //重置所有线的状态
        for (int i = 0; i < lines.Count; i++)
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
            if (gameObject.GetComponent<Line>().isPower && like.isPower &&
                coin.isPower && collect.isPower)
                GameOver();
        }
    }
    private void GameOver()
    {
        gameoverUI.SetActive(true);
        Debug.Log("GameOver");
    }
}
