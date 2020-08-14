using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCon : MonoBehaviour
{
    [SerializeField]
    public bool SelectionActive;
    [SerializeField]
    private GameObject TowerSelected;
    private bool SpriteisOff = true;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (SelectionActive == true)
            {
                LayerMask layermask = LayerMask.GetMask("Wall");
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
                {
                    Instantiate(TowerSelected, hit.transform.position, Quaternion.identity);
                    SelectionActive = false;
                }
                else
                {
                    SelectionActive = false;
                }
            }

            if(SelectionActive == false)
            {
                //Highlight Tower
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
        TowerSelected = TowerPrefab;
    }
}
