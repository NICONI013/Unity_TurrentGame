using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform[] Targetpoint;
    private int index = 0;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        Targetpoint = Movecontrol.Targetpoint;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        if (Targetpoint.Length == index)//return在这里之后，就不执行之后的内容了，直接返回
        {
            Destroy(gameObject);
            return;
          
        }
        transform.Translate((Targetpoint[index].position - transform.position).normalized * Time.deltaTime * speed);
        if (Vector3.Distance(Targetpoint[index].position,transform.position)<0.2f)
        {
            index++;
        }
        
        
        
    }
}
