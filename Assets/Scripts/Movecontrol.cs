using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 此脚本挂载在Road组上，会自动获取子物体赋值
/// </summary>
public class Movecontrol : MonoBehaviour
{
    public static Transform[] Targetpoint;//新建静态transform数组，
    private void Awake()
    {
        Targetpoint = new Transform[transform.childCount];//再次新建一个数组，让数组长度为子物体个数
        for (int i = 0; i < Targetpoint.Length; i++)
        {
            Targetpoint[i] = transform.GetChild(i);//赋值
        }
    }
   
    
   
}
