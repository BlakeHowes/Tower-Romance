using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCon : MonoBehaviour
{
    [SerializeField]
    private float Height;
    [SerializeField]
    private GameObject Empty;
    public bool SelectionActive;
    [SerializeField]
    private GameObject TowerSelected;
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
                    Vector3 AddHeight = new Vector3(0f, Height, 0f);
                    Instantiate(TowerSelected, hit.transform.position + AddHeight, Quaternion.identity);
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
    }

    public void AddObjectToSelection(GameObject TowerPrefab)
    {
        TowerSelected = TowerPrefab;
    }
}
