using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public static SpriteManager instance;

    public List<SpriteRenderer> GridSprites = new List<SpriteRenderer>();
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        TurnOffGridSprites();
    }

    public void TurnOnGridSprites()
    {
        foreach(SpriteRenderer gridSprite in GridSprites)
        {
            gridSprite.enabled = true;
        }
    }

    public void TurnOffGridSprites()
    {
        foreach (SpriteRenderer gridSprite in GridSprites)
        {
            gridSprite.enabled = false;
        }
    }
}
