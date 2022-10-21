using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TadpoleAI : MonoBehaviour
{
    private float random_X;
    private float random_Y;
    public float speed;

    private float timer;

    public float changeDireTime;

    public float hp;
    public float consumeSpeed;
    public SpriteRenderer m_sprite;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > changeDireTime)
        {
            int x = Random.Range(0, 2);
            if (x > 1)
            {
                random_X = Random.Range(5f, 10f) + transform.position.x;
            }
            else
            {
                random_X = Random.Range(-10f, -5f) + transform.position.x;
            }

            int y = Random.Range(0, 2);
            if (y > 1)
            {
                random_Y = Random.Range(5f, 10f) + transform.position.y;
            }
            else
            {
                random_Y = Random.Range(-10f, -5f) + transform.position.y;
            }

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
        Fading(consumeSpeed);
        CheckAlive();
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
        Fading(consumeSpeed * 2);
        CheckAlive();
    }
    private void Rotate(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void Fading(float speed)
    {
        hp -= Time.deltaTime * speed;
        m_sprite.color = new Color(1, 1, 1, hp);
    }
    private void CheckAlive()
    {
        if (hp < 0f)
        {
            Destroy(this);
        }
    }
}
