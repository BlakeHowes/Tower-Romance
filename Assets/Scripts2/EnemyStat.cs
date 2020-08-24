using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    [SerializeField]
    private float Health;
    [SerializeField]
    private int AddToCurrency;
    private GameObject MainControl;

    void OnEnable()
    {
        MainControl = GameObject.Find("Manager"); // this might cause bugs 
    }

    void Update()
    {
        if (Health < 0f)
        {
            MainControl.GetComponent<MainCon>().AddCurrency(AddToCurrency);
            Destroy(gameObject);
        }
    }

    public void RemoveHealth(float Damage)
    {
        Health -= Damage;
    }
}
