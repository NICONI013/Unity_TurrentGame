using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TurrentSpawner : MonoBehaviour
{
    public TurrentData ClassicTurrent;
    public TurrentData LaserTurrent;
    public TurrentData FireTurrent;

    public TurrentData CurrentTurrent;
    
    public int CurrentMoney;
    public Text MoneyText;
    void OnMoneyChanged(int change)
    {
        CurrentMoney -= change;
        MoneyText.text = CurrentMoney.ToString();
    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))//鼠标左键按下
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)//这里的Gameobject是UI上的游戏物体，意为当前碰到的不是UI上的游戏物体
            {
                
                //满足以上2种条件才可建造炮台
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool iscolliion = Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("SpaceCube"));//只检测这个图层下的游戏物体
                if (iscolliion)
                {
                    MapCube mapcube = hit.collider.gameObject.GetComponent<MapCube>();//碰撞到的那个方块，获取上面的Mapcube组件
                    if (mapcube.TurrentOn == null)
                    {
                        //上面没有炮台
                        if (CurrentMoney > CurrentTurrent.Moneycost)
                        {
                            OnMoneyChanged(CurrentTurrent.Moneycost);
                            mapcube.BulidPrefabs(CurrentTurrent.Turrent);
                        }
                        else
                        {
                            //提示钱不够
                        }

                    }
                    else
                    {
                        //有了炮台需要升级
                    }
                }

            }
        }
    }
    public void IsClassic(bool on)
    {
        CurrentTurrent = ClassicTurrent;
    }
    public void IsLaserTurrent(bool on)
    {
        CurrentTurrent = LaserTurrent;
    }
    public void IsFire(bool on)
    {
        CurrentTurrent = FireTurrent;
    }
    
}
