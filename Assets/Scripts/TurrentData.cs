using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//可序列化的
public class TurrentData //务必记住此类不继承才可在inspet面板上显示正常属性，如继承则为gameobject类，无法细分显示
{
    public GameObject Turrent;
    public int Moneycost;
    public GameObject TurrentUpdate;
    public int MoneyUpdateCost;

    public TurrentTp type;
}
public enum TurrentTp//此处务必加上public，否则上面会提示可访问性不一致
{
    Classic,
    Laser,
    Fire
}
