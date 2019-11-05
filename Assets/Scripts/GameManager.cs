using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameEndCanves;
    public GameObject GameWinCanvas;
    public EnemySpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GameOver(Enemy.gameOver);
        //print(Enemy.gameOver+"Gameover");
        //GameOver(spawner.gamewin);
        //print(spawner.gamewin+"GameWin");
        GameEndCanves.SetActive(Enemy.gameOver);
        GameWinCanvas.SetActive(spawner.gamewin);
    }
    public void GameOver(bool over)
    {
        GameEndCanves.SetActive(over);
       
    }
    public void GameWin(bool win)
    {
        GameWinCanvas.SetActive(win);
    }
    public void OnBackMenuBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnReStartBtn()
    {
        SceneManager.LoadScene("MainGame");
    }
}
