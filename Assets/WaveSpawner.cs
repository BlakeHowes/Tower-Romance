using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public float WaveTimer = 5f;
    private float countdown = 2f;

    void update()
    {
        if (countdown <= 0f)
        {
            SpawnWave();
            countdown = WaveTimer;
        }
    }

    void SpawnWave()
    {
        Debug.Log("NextWave");
    }
}
