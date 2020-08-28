using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNamedScene : MonoBehaviour
{
    [SerializeField]
    private string NextScene;

    public void LoadNext()
    {
        SceneManager.LoadScene(NextScene);
    }
}