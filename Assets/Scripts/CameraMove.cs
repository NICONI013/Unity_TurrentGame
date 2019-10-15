using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float Speed;
    public float Mousespeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float MouseScroll = Input.GetAxis("Mouse ScrollWheel");
        
        transform.Translate(new Vector3(h * Speed, MouseScroll *-1* Mousespeed, v * Speed)*Time.deltaTime,Space.World);
        //space.world指的是世界坐标，如果使用此参数，相机只会拉近



        //以下为设定相机的位置和方向，让相机不出预定范围
        if (transform.position.x>25)
        {
            transform.position = new Vector3(25, transform.position.y, transform.position.z);
        }
        if (transform.position.x< -15)
        {
            transform.position = new Vector3(-15, transform.position.y, transform.position.z);
        }

        if (transform.position.z>6)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 6);
        }
        if (transform.position.z<-45 )
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -45);
        }

    }
}
