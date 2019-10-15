using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurrentSpawner : MonoBehaviour
{
    public TurrentData ClassicTurrent;
    public TurrentData LaserTurrent;
    public TurrentData FireTurrent;

    public TurrentData CurrentTurrent;

    public int CurrentMoney;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (EventSystem.current.IsPointerOverGameObject()==false)
            {
                //满足以上2种条件才可建造炮台
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool iscolliion=  Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("SpaceCube"));
                if (iscolliion)
                {
                    MapCube mapcube = hit.collider.gameObject.GetComponent<MapCube>();
                    if (mapcube!=null)
                    {
                        //上面没有炮台
                        if (CurrentMoney>CurrentTurrent.Moneycost)
                        {
                            CurrentMoney-= CurrentTurrent.Moneycost;
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
