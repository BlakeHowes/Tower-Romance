using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCon : MonoBehaviour
{
    [SerializeField]
    private GameObject TowerPrefab;
    [SerializeField]
    private GameObject Manager;
  public void Press()
    {
        if(Manager.GetComponent<MainCon>().Currency >= 10)
        {
            Manager.GetComponent<MainCon>().SelectionActive = true;
            Manager.GetComponent<MainCon>().AddObjectToSelection(TowerPrefab);
        }
    }
}
