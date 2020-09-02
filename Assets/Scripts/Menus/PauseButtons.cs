﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtons : MonoBehaviour
{


    //quick-fix loas scene settings 

    [SerializeField]
    private int CurrentLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //continue game/unpause
    public void Continue()
    {
        PauseMenu.FindObjectOfType<PauseMenu>().PauseMenuOFFButton();
    }

    //return to title page (will loose all progress)
    public void Title()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(CurrentLevel);
    }


}
