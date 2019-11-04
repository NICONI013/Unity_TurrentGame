using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector]
    public Transform targettf;
    public float speed = 10;
    public int damanger = 1;
    public GameObject hitParitcle;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Broke",5);
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {
        if (targettf == null)
        {
            Destroy(gameObject);
            return;
        }
        transform.LookAt(targettf);//看向目标方向
        transform.Translate(Vector3.forward * speed * Time.deltaTime);//持续朝前移动，但是因为看向目标方向，所以会追踪目标
       
        
       
    }
    public void LookTransform(Transform target)//方法中传递一个坐标进来，把坐标赋值过来，在炮台那里调用
    {
        this.targettf = target;
       
    }
    
    void Broke()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider cld)
    {
        if (cld.tag=="Enemy")
        {
           
            cld.gameObject.GetComponent<Enemy>().TakeDamange(damanger);
            Instantiate(hitParitcle, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
        
    }

}
