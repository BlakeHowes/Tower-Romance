using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject PausedMenu;

    //is the game paused?
    private bool GameIsPaused = false;




    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                PauseMenuOFF();
            }
            else
            {
                PauseMenuON();
            }
        }







    }


    private void PauseMenuON()
    {
        Time.timeScale = 0;
        PausedMenu.SetActive(true);
        GameIsPaused = true;
    }

    //method called by button to unpause
    public void PauseMenuOFFButton()
    {
        PauseMenuOFF();
    }

    private void PauseMenuOFF()
    {
        Time.timeScale = 1;
        PausedMenu.SetActive(false);
        GameIsPaused = false;

    }






}
