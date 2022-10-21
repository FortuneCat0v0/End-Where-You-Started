using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggAI : MonoBehaviour
{
    private float random_X;
    private float random_Y;
    public float speed;

    private float timer;

    public float changeDireTime;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > changeDireTime)
        {
            random_X = Random.Range(-10f, 10f) + transform.position.x;
            random_Y = Random.Range(-10f, 10f) + transform.position.y;
            timer = 0;
        }
        Move(new Vector3(random_X, random_Y, 0));
    }

    /// <summary>
    /// 朝一个方向移动
    /// </summary>
    /// <param name="tar"></param>
    public void Move(Vector3 tar)
    {
        Vector3 direction = tar - transform.position;
        direction.z = 0;
        transform.Translate(direction.normalized * Time.deltaTime * speed, Space.World);
        Rotate(direction);
    }

    /// <summary>
    /// 加速
    /// </summary>
    public void Accelerate(Vector3 tar)
    {
        Vector3 direction = tar - transform.position;
        direction.z = 0;
        transform.Translate(direction.normalized * Time.deltaTime * speed * 2f, Space.World);
        Rotate(direction);
    }
    private void Rotate(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Level_1GameManager.Instance.NextGame();
        }
        if (other.tag == "AI")
        {
            Level_1GameManager.Instance.ResetGame();
        }
    }
}
