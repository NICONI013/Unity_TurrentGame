using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    public List<GameObject> Enemy = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider cld)
    {
        if (cld.tag=="Enemy")
        {
            Enemy.Add(cld.gameObject);
        }
        
    }
    private void OnTriggerExit(Collider cld)
    {
        if (cld.tag=="Enemy")
        {
            Enemy.Remove(cld.gameObject);
        }
       
    }
}
