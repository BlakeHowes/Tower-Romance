using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelect : MonoBehaviour
{


    [SerializeField]
    private int TowerLevel;

    [SerializeField]
    private int NovelLevel;


    public void TowerDefence()
    {
        SceneManager.LoadScene(TowerLevel);
    }

    public void VisualNovel()
    {
        SceneManager.LoadScene(NovelLevel);
    }
    
}
