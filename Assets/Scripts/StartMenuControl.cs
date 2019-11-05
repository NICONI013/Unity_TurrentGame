using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuControl : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMainSceneLoadBtn()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void OnQUitGame()
    {
        Application.Quit();
    }
}
