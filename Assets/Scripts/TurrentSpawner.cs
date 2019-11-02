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

    public bool Chooseon = false;

    public GameObject UpdateCanvas;
    public Button BuildBtns;
    private GameObject SelecedTurrent;//表示当前选择的炮台

    public MapCube Mapcube;

    Ray ray;
    RaycastHit hit;
    MapCube mapcube;
    void OnMoneyChanged(int change)
    {
        CurrentMoney -= change;
        MoneyText.text = CurrentMoney.ToString();
    }
    private void Update()
    {
         ray = Camera.main.ScreenPointToRay(Input.mousePosition);

         

        if ( Input.GetMouseButtonDown(0))//鼠标左键按下
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)//这里的Gameobject是UI上的游戏物体，意为当前碰到的不是UI上的游戏物体
            {
                
                //满足以上2种条件才可建造炮台

                bool iscolliion = Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("SpaceCube"));//只检测这个图层下的游戏物体
                if (iscolliion)
                {
                    //碰撞到的那个方块，获取上面的Mapcube组件
                    mapcube = hit.collider.gameObject.GetComponent<MapCube>();

                    Mapcube = mapcube;//之前一直不知道怎么在下面的方法中得到选中的小方块，想不到这么简单！！！！！！！！
                    //直接在上面public一个mapcube然后把这个值赋给它就可以在下面调用了

                    if (CurrentTurrent.Turrent != null && mapcube.TurrentOn == null)
                    {
                        //上面没有炮台//当前炮台游戏物体不为空的前提下
                        if (CurrentMoney > CurrentTurrent.Moneycost)
                        {
                            OnMoneyChanged(CurrentTurrent.Moneycost);
                            mapcube.BulidPrefabs(CurrentTurrent);
                            CanvasHide();
                        }
                        else
                        {
                            //提示钱不够
                        }

                    }
                    else if(mapcube.TurrentOn!=null)
                    {
                        
                        //mapcube.BuildUpdateButton();
                        CanvasOn(mapcube.transform.position+new Vector3(0,10,0), mapcube.isUpdate);//获取点击小方块的坐标，如果生成了炮台isuodate为true，按钮可以点击
                       
                        if (mapcube.TurrentOn == SelecedTurrent&& UpdateCanvas.activeInHierarchy)//此按钮在层级列表中是否激活
                        {
                            CanvasHide();
                            
                        }
                        SelecedTurrent = mapcube.TurrentOn;//保存下来的炮台，通过mapcube生成的游戏物体赋值
                        CurrentTurrent = mapcube.Turrentdata;
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
    //public void UpdateTurrentBtn()
    //{
    //    Destroy(mapcube.TurrentOn);
    //    if (CurrentTurrent==ClassicTurrent)
    //    {
    //        mapcube.BulidPrefabs(ClassicTurrent.Turrent);
    //    }
    //    if (CurrentTurrent==LaserTurrent)
    //    {
    //        mapcube.BulidPrefabs(LaserTurrent.Turrent);
    //    }
    //    if (CurrentTurrent==FireTurrent)
    //    {
    //        mapcube.BulidPrefabs(FireTurrent.Turrent);
    //    }
    //    //Destroy(mapcube.BuildBtns);
    //}
    //public void DestoryTurrentBtn()
    //{
    //    Destroy(mapcube.TurrentOn);
    //    Destroy(mapcube.BuildBtns);
    //}///失败的例子
    void CanvasOn(Vector3 pos, bool isDisableUpdate=false)//此处传递位置坐标信息，把坐标传递进来，因为mapcube需要raycast hit检测是哪个方块，所以这么调用
    {
        UpdateCanvas.SetActive(true);
        UpdateCanvas.transform.position = pos;
        BuildBtns.interactable =! isDisableUpdate;//此为按钮的可互动性
    }
    void CanvasHide()
    {
        UpdateCanvas.SetActive(false);
    }
    public void OnupdateTurrentBtn()
    {
       
        Destroy(mapcube.TurrentOn);
        mapcube.UpdateTurrent();
        CanvasHide();

    }
    public void OnDestoryBtn()
    {
        //mapcube.TurrentOn = null;
        //mapcube.Turrentdata = null;
        mapcube.DestoryTurrent();
        CanvasHide();
    }

}
