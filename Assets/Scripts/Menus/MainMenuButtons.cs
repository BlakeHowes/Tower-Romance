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

    [SerializeField]
    private GameObject BackgroundScroll;

    [SerializeField]
    private GameObject GameModeSelection;



    // Start is called before the first frame update
    void Start()
    {
        MainTitle.SetActive(true);
        ControlInstructions.SetActive(false);
        AboutCredits.SetActive(false);
        QuitConfirm.SetActive(false);
        GameModeSelection.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SelectMode()
    {
        MainTitle.SetActive(false);
        GameModeSelection.SetActive(true);
    }



    public void SelectModeOFF()
    {
        GameModeSelection.SetActive(false);
        MainTitle.SetActive(true);
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

    private void QuitConfirmationON()
    {
        MainTitle.SetActive(false);
        BackgroundScroll.SetActive(false);
        QuitConfirm.SetActive(true);
    }

    public void QuitConfirmationButton()
    {
        QuitConfirmationON();
    }

    
   

    public void ExitQuitConfirmation()
    {
        QuitConfirmationOFF();
    }

    private void QuitConfirmationOFF()
    {
        
        QuitConfirm.SetActive(false);
        BackgroundScroll.SetActive(true);
        MainTitle.SetActive(true);
    }


    // Quit Application
    public void QuitGame()
    {
        Application.Quit();
    }




}
