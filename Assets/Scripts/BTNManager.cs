using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BTNManager : MonoBehaviour
{

    /*------------> Pause Functionality <-------------*/
    public GameObject pausePannel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
    }
    public void PauseMenu()
    {
        pausePannel.SetActive(!pausePannel.activeSelf);

        Time.timeScale = pausePannel.activeSelf ? 0f : 1f; //Depending if Pause Menu is active, time scale is set to 0 or 1 | 0 Pauses the game | 
    }
    //==================================================//
    //==================================================//
    /*-------------> New Level for BTN <---------------*/
    public void NewLevel(string newLevel)
    {
        SceneManager.LoadScene(newLevel);
    }
    /*-------------> End Game for BTN <---------------*/
    public void ExitGameBtn()
    {
        Application.Quit();
    }
}
