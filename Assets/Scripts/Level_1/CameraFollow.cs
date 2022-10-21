
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector2 margin;//相机与角色的相对范围
    public Vector2 smoothing;//相机移动的平滑度

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }
    void FollowPlayer()
    { 
        var x = transform.position.x;
        var y = transform.position.y;
        if (Mathf.Abs(x - player.position.x) > margin.x)
        {
            x = Mathf.Lerp(x, player.position.x, smoothing.x * Time.deltaTime);
        }
        if (Mathf.Abs(y - player.position.y) > margin.y)
        {
            y = Mathf.Lerp(y, player.position.y, smoothing.y * Time.deltaTime);
        }
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
