using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tadpole : MonoBehaviour
{
    public float speed;
    public float Speed
    {
        set
        {
            speed = value;
        }
    }
    [SerializeField]
    public float hp;
    public float consumeSpeed;
    public SpriteRenderer m_sprite;

    private void Update()
    {
        Vector3 tar = Camera.main.ScreenToWorldPoint(
          new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        if (Input.GetMouseButton(0))
        {
            Accelerate(tar);
        }
        else
        {
            Move(tar);
        }
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
            Level_1GameManager.Instance.ResetGame();
        }
    }

}
