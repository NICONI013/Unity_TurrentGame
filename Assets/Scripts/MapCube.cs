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
    private void Start()
    {
        M1 = GetComponent<Renderer>().material;
        Tuspr = GameObject.Find("TurrentSpawner").GetComponent<TurrentSpawner>();
    }
    public void BulidPrefabs(GameObject TurrentPrefabs)
    {
        isUpdate = false;
        TurrentOn = Instantiate(TurrentPrefabs, transform.position+new Vector3(0,1,0), Quaternion.identity);
        Instantiate(DustParticle, transform.position, Quaternion.identity);
    }
    //public void BuildUpdateButton()
    //{
    //    BuildBtns= Instantiate(UpdateBtns, transform.position+new Vector3(0,6,0), transform.rotation);
    //}
    public void OnupdateTurrentBtn()
    {

        Destroy(TurrentOn);


    }
    public void OnDestoryBtn()
    {
        Destroy(TurrentOn);
    }

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
