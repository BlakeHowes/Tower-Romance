using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnData_
{
    [System.Serializable]
    public class SpawnData
    {
        public string Name = "";
        public int Wave = 0;
        public Object EnemyType = null;
        public float SpawnRate = 0f;
        public float SpawnDelay = 0f;
        public float TotalSpawned = 0f;
        public float Counter = 0f;
        public float RateTimer = 10f;
    }
}
