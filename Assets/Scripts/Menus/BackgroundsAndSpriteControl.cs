using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BackgroundsAndSpriteControl : MonoBehaviour
{

    //characters

    [SerializeField]
    private GameObject AsheIMG;
    [SerializeField]
    private bool Ashe;

    [SerializeField]
    private GameObject BlazeIMG;
    [SerializeField]
    private bool Blaze;

    [SerializeField]
    private GameObject RemiIMG;
    [SerializeField]
    private bool Remi;


    //backgrounds

    [SerializeField]
    private GameObject BackgroundOutside;
    [SerializeField]
    private GameObject BackgroundInside;
    [SerializeField]
    private GameObject BackgroundInsideEvening;
    [SerializeField]
    private bool OutsideVillage;
    [SerializeField]
    private bool Evening;

    // Start is called before the first frame update
    void Start()
    {
        if (Ashe)
        {
            AsheIMG.SetActive(true);
        }

        if (Blaze)
        {
            BlazeIMG.SetActive(true);
        }

        if (Remi)
        {
            RemiIMG.SetActive(true);
        }

        if (OutsideVillage == false)
        {
            
            if (Evening)
            {
                BackgroundInsideEvening.SetActive(true);
            }
            else
            {
                BackgroundInside.SetActive(true);
            }
                
        }
        else
        {
            BackgroundOutside.SetActive(true); 
        }
        
           
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }














}
