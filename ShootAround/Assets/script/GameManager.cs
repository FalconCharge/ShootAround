using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Porbably should start as true if we start at menu screen
    bool isEnded = false;
    public void loadGameOver()
    {
        if(isEnded == false)
        {
            isEnded = true;
            Invoke("gameOver", 1f);
        }
        
    }
    public void loadGame()
    {
        if(isEnded == true)
        {
            isEnded = false;
            Invoke("playGame", 1f);
        }
        
    }
    public void loadMainMenu()
    {
        if(isEnded == true)
        {
            isEnded = false;
            Invoke("mainMenu", 1f);
        }
        
    }
    void playGame()
    {
        SceneManager.LoadScene("Game");
    }
    void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    void gameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
