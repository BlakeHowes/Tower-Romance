using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCon : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer ren;
    private Color AlphaChange;
    void Awake()
    {

    }

    private void Start()
    {
        SpriteManager.instance.GridSprites.Add(ren);
    }

    private void OnMouseOver()
    {
        AlphaChange = new Color(1, 1, 1, 1);
        ren.color = AlphaChange;
        Debug.Log("Mouseme");
    }

    private void OnMouseExit()
    {
        AlphaChange = new Color(1, 1, 1, 0.5f);
        ren.color = AlphaChange;
    }

}
