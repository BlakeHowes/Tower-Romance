using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selections : MonoBehaviour
{


    [SerializeField]
    private string AsheBeginning;

    [SerializeField]
    private string BlazeBeginning;

    [SerializeField]
    private string RemiBeginning;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AshePath()
    {
        SceneManager.LoadScene(AsheBeginning);
    }

    public void BlazePath()
    {
        SceneManager.LoadScene(BlazeBeginning);
    }

    public void RemiPath()
    {
        SceneManager.LoadScene(RemiBeginning);
    }



}
