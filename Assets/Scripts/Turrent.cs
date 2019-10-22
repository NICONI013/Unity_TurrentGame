using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    public List<GameObject> Enemy = new List<GameObject>();//List集合，
   

    public float timer;
    public float timeRate = 1;
    public GameObject bullet;
    public Transform fireTransform;
    // Start is called before the first frame update
    void Start()
    {
        timer = timeRate;
    }
    
    // Update is called once per frame
    void Update()
    {
        
            timer += Time.deltaTime;//计时器，一直增加时间，比如12345,
            print(timer);
            if (Enemy.Count > 0 && timer >= timeRate)
            {

                //timer -= timeRate;//攻击完成之后，减去攻击间隔，比如4秒CD，5-4=1，再过3秒继续攻击,值为1.2，看球体的数量，不用担心,不要担心个p!!!!!!
                timer = 0;//直接归零，简单方便
                Attack();
            }
        
        

    }
    private void OnTriggerEnter(Collider cld)
    {
        if (cld.tag=="Enemy")
        { 
            Enemy.Add(cld.gameObject);//向List集合中增加新的元素
        }
        
    }
    private void OnTriggerExit(Collider cld)
    {
        if (cld.tag=="Enemy")
        {
            Enemy.Remove(cld.gameObject);
        }
       
    }
    void Attack()
    {
        
        GameObject bt = Instantiate(bullet, fireTransform.position, fireTransform.rotation);//生成子弹gameobject
        if (Enemy[0]!=null)
        {
            bt.GetComponent<Bullet>().Shoot(Enemy[0].transform);//射击list中第一号敌人，只是给了个目标而已，生成子弹之后子弹unpdate中自己写了像目标移动
        }
            
        
    }
}
