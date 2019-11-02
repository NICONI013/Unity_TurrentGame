using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
    [HideInInspector]
    public GameObject TurrentOn;
    public GameObject DustParticle;
    
    private Material M1;
    
    private TurrentSpawner Tuspr;
    [HideInInspector]
    public bool isUpdate = false;
    //public GameObject UpdateBtns;
    //public GameObject BuildBtns;

    public TurrentData Turrentdata;
    private void Start()
    {
        M1 = GetComponent<Renderer>().material;
        Tuspr = GameObject.Find("TurrentSpawner").GetComponent<TurrentSpawner>();
    }
    public void BulidPrefabs(TurrentData turrentData)//在小方块上建造炮台
    {
        isUpdate = false;
        TurrentOn = Instantiate(turrentData.Turrent, transform.position+new Vector3(0,1,0), Quaternion.identity);
        Instantiate(DustParticle, transform.position, Quaternion.identity);
        this.Turrentdata = turrentData;
    }
    public void UpdateTurrent()//更新小方块的炮台，因为TurrentData中选择了可以更新的炮台类型，所以直接点CurrentTurrent.Update即可
    {
        isUpdate = true;
        TurrentOn = Instantiate(Turrentdata.TurrentUpdate, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        Instantiate(DustParticle, transform.position, Quaternion.identity);


    }
    public void DestoryTurrent()
    {
        Destroy(TurrentOn);
        isUpdate = false;
        //TurrentOn = null;
        //Turrentdata = null;

    }
    //public void BuildUpdateButton()
    //{
    //    BuildBtns= Instantiate(UpdateBtns, transform.position+new Vector3(0,6,0), transform.rotation);
    //}
   

    private void OnMouseEnter()
    {

        if (Tuspr.CurrentTurrent.Turrent!=null)
        {
            print(Tuspr.CurrentTurrent);
            if (TurrentOn.gameObject == null && EventSystem.current.IsPointerOverGameObject() == false)
            {

                M1.color = Color.red;

            }
        }
     
    }
    private void OnMouseExit()
    {
        M1.color = Color.white;
    }
}
