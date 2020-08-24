using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCon : MonoBehaviour
{
    [SerializeField]
    public bool SelectionActive;
    [SerializeField]
    private GameObject TowerSelectedForPlacement;
    [SerializeField]
    private GameObject CameraTarget;

    private bool OrbitMode = false;
    private bool SpriteisOff = true;
    private GameObject HighlightedObject;

    private float TotalEnemies;
    [SerializeField]
    public Text EnemiesLeftDisplay;

    [SerializeField]
    private int StartingCurrency;
    private int Currency;
    public Text CurrencyDisplay;

    public void GetTotalEnemies(float numberofenemies)
    {
        TotalEnemies = numberofenemies;
    }

    public void AddCurrency(int amount)
    {
        Currency += amount;
        TotalEnemies -= 1;
    }

    public void RemoveCurrency(int amount)
    {
        if(Currency >= amount)
        {
            Currency -= amount;
        }
    }

    public void Awake()
    {
        Currency += StartingCurrency;
    }

    void Update()
    {
        CurrencyDisplay.text = ("Money:") + Currency.ToString("");
        EnemiesLeftDisplay.text = ("Slimes:") + TotalEnemies.ToString("");

        if (Input.GetMouseButtonDown(0))
        {
            if (SelectionActive == false)
            {
                LayerMask layermask = LayerMask.GetMask("Tower");
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
                {
                    HighlightedObject = hit.transform.gameObject;
                    hit.transform.gameObject.GetComponent<Outline>().enabled = true;

                    Debug.Log("TowerHit");
                    OrbitMode = true;
                    CameraTarget.transform.position = hit.transform.position;
                    Camera.main.GetComponent<CameraCon>().SwitchToOrbit();
                }
                else
                {
                    if(HighlightedObject != null)
                    {
                        HighlightedObject.GetComponent<Outline>().enabled = false;
                    }

                    if (OrbitMode == true)
                    {
                        Camera.main.GetComponent<CameraCon>().SwitchToPan();
                    }
                }
            }

            if (SelectionActive == true)
            {
                LayerMask layermask = LayerMask.GetMask("Wall");
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
                {
                    hit.transform.gameObject.layer = 11;
                    Instantiate(TowerSelectedForPlacement, hit.transform.position, Quaternion.identity);
                    SelectionActive = false;
                }
                else
                {
                    SelectionActive = false;
                }
            }
        }

        if(SelectionActive == true)
        {
            if(SpriteisOff == true)
            {
                SpriteManager.instance.TurnOnGridSprites();
                SpriteisOff = false;
            }
        }
        else
        {
            if (SpriteisOff == false)
            {
                SpriteManager.instance.TurnOffGridSprites();
                SpriteisOff = true;
            }
        }
    }

    public void AddObjectToSelection(GameObject TowerPrefab)
    {
        TowerSelectedForPlacement = TowerPrefab;
    }
}
