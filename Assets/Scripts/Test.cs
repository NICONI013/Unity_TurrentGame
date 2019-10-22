using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform ts;
    public int Speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward);//这种方法是直接向前移动
        transform.Translate((ts.position-transform.position).normalized*Speed*Time.deltaTime);//这种方法是向着目标位置移动，用后者的pos减前者的pos再.normalized标准化
    }
}
