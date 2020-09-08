using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelect : MonoBehaviour
{


    [SerializeField]
    private string TowerLevel;

    [SerializeField]
    private string NovelLevel;


    public void TowerDefence()
    {
        SceneManager.LoadScene(TowerLevel);
    }

    public void VisualNovel()
    {
        SceneManager.LoadScene(NovelLevel);
    }
    
}
