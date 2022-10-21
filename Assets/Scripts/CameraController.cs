using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if (x != 0 || y != 0)
        {
            Vector2 t = new Vector2(x, y).normalized;
            this.transform.position = new Vector3(this.transform.position.x + t.x * speed * Time.deltaTime,
                this.transform.position.y + t.y * speed * Time.deltaTime, -10);
        }
    }
}
