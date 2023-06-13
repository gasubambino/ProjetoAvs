using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public GameObject pauseTab; //pause tab gameobject
    public GameObject upgradeTab; //upgrade tab gameobject

    private bool isPaused = false;
    private bool isUpgrading = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //when esc is pressed
        {
            if (isPaused) //if paused
            {
                ResumeGame(); //resume game
            }
            else //if not paused
            {
                PauseGame(); //pause game
            }
        }
    }
    public void UpgradeActivate()
    {
        upgradeTab.gameObject.SetActive(true);//opens the upgrade tab
        Time.timeScale = 0f; //pauses the game
        isUpgrading = true;
        isPaused = true;
    }

    public void UpgradeDeactivate()
    {
        upgradeTab.gameObject.SetActive(false);//closes the upgrade tab
        Time.timeScale = 1f; //unpauses the game
        isUpgrading = false;
        isPaused = false;
    }
    public void PauseGame()
    {
        if (isUpgrading == false) //if not upgrading
        {
            Time.timeScale = 0f; //pauses
            isPaused = true;
            pauseTab.gameObject.SetActive(true); //opens the pause tab
        }
    }
    public void ResumeGame()
    {
        if (isUpgrading == false) //if not upgrading
        {
            Time.timeScale = 1f; //unpause
            isPaused = false;
            pauseTab.gameObject.SetActive(false); //closes the pause tab
        }
    }
}
