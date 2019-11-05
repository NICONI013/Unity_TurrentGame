using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner:MonoBehaviour 
{
    public EnemyState[] enemystats;
    public Transform startpos;
    public int spawnrate;
    public static int EnemyAlive = 0;
    private int Enemygroupcount = 0;
    private GameObject gb;
    public bool gamewin = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        gamewin = false;

    }
    private void Update()
    {
        print(enemystats.Length+"Length");
        print(Enemygroupcount);
        print(EnemyAlive + "EnemyAlive");
        if (EnemyAlive==0&&Enemygroupcount==enemystats.Length)
        {
            gamewin = true;
        }
    }


    IEnumerator SpawnEnemy()
    {
        foreach (EnemyState states in enemystats)//右边的是数组，左边的是元素，把每个元素放进数组表示循环结束，比如2个类型的敌人，就循环2次
        {
            for (int i = 0; i < states.num; i++)//此处为生成的敌人数量
            {
                gb=  GameObject.Instantiate(states.EnemyType, startpos.position, Quaternion.identity);
                yield return new WaitForSeconds(states.rate);
                EnemyAlive++;
                
            }
            Enemygroupcount++;
           
            while (EnemyAlive >0)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(spawnrate);

           
        }
       
    }
        

}
