using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (SelectionActive == false)
            {
                LayerMask layermask = LayerMask.GetMask("Tower");
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layermask))
                {
                    //SetZoom and position
                    Debug.Log("TowerHit");
                    OrbitMode = true;
                    CameraTarget.transform.position = hit.transform.position;
                    Camera.main.GetComponent<CameraCon>().SwitchToOrbit();
                }
                else
                {
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
