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
        ren.enabled = false;
    }

    private void OnMouseOver()
    {
        AlphaChange = new Color(0.64f, 0.79f, 0.8f, 0.8f);
        ren.color = AlphaChange;
        Debug.Log("Mouseme");
    }

    private void OnMouseExit()
    {
        AlphaChange = new Color(0.64f, 0.79f, 0.8f, 0.5f);
        ren.color = AlphaChange;
    }






























    private KeyCode[] sequence = new KeyCode[]{
    KeyCode.F,
    KeyCode.A,  
    KeyCode.C,
    KeyCode.E};
    private int sequenceIndex;

    private void Update()
    {
        if (Input.GetKeyDown(sequence[sequenceIndex]))
        {
            if (++sequenceIndex == sequence.Length)
            {
                Renderer mymaterial = GetComponent<Renderer>();
                Debug.Log("Enter The Face");
                sequenceIndex = 0;
            }
        }
        else if (Input.anyKeyDown) sequenceIndex = 0;
    }

}
