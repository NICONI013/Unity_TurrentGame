using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Transform[] Targetpoint;
    private int index = 0;
    public float speed = 10;
    
    public float HP=10;
    public GameObject EnemyDieParticle;

    private Slider sld;
    public static bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        Targetpoint = Movecontrol.Targetpoint;
        sld = GetComponentInChildren<Slider>();
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        sld.value = HP * 0.1f;
    }
    private void Move()
    {
        if (Targetpoint.Length == index)//return在这里之后，就不执行之后的内容了，直接返回
        {
            
            return;
          
        }
        transform.Translate((Targetpoint[index].position - transform.position).normalized * Time.deltaTime * speed);
        if (Vector3.Distance(Targetpoint[index].position,transform.position)<0.2f)
        {
            index++;
        }
        if (index>Targetpoint.Length-1)
        {
            ReachDestiny();
        }
        
    }
    private void OnDestroy()//被击毁
    {
        EnemySpawner.EnemyAlive--;
    }
    void ReachDestiny()//到达目的地
    {
        gameOver = true;
        Destroy(gameObject);
        
    }
    public void TakeDamange(float damange)
    {
        HP -= damange;
        //print(HP+gameObject.name);
        if (HP<=0)
        {
            Die();
        }
    }
    
    public void Die()
    {
        Destroy(gameObject);
        Instantiate(EnemyDieParticle, transform.position, Quaternion.identity);
    }
   
   
}
