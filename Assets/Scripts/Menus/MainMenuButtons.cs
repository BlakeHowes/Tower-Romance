using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{

    [SerializeField]
    private GameObject MainTitle;


    [SerializeField]
    private GameObject ControlInstructions;

    [SerializeField]
    private GameObject AboutCredits;

    [SerializeField]
    private GameObject QuitConfirm;





    // Start is called before the first frame update
    void Start()
    {
        MainTitle.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void InstructionsButton()
    {


        InstructionsON();


    }


    private void InstructionsON()
    {
        MainTitle.SetActive(false);
        ControlInstructions.SetActive(true);
    }

    public void ExitInstructions()
    {
        InstructionsOFF();
    }
    
    private void InstructionsOFF()
    {
        ControlInstructions.SetActive(false);
        MainTitle.SetActive(true);
    }




    public void CreditsButton()
    {
        CreditsON();
    }

    private void CreditsON()
    {
        MainTitle.SetActive(false);
        AboutCredits.SetActive(true);
    }

    public void ExitCredits()
    {
        CreditsOFF();
    }

    private void CreditsOFF()
    {
        
        AboutCredits.SetActive(false);
        MainTitle.SetActive(true);
    }


    public void QuitConfirmation()
    {
        MainTitle.SetActive(false);
        QuitConfirm.SetActive(true);
    }



    // Quit Application
    public void QuitGame()
    {
        Application.Quit();
    }




}
