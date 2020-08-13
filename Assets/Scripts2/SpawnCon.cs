using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnData_
{
    public class SpawnCon : MonoBehaviour
    {
        [SerializeField]
        public float WaveDelay;
        [SerializeField]
        public List<SpawnData> WaveSpawner = new List<SpawnData>();
        [SerializeField]
        private float WaveCounter = 1;
        [SerializeField]
        private float GameTimer;
        [SerializeField]
        private float SpawnTimer;
        [SerializeField]
        private float WaveDelayTimer;
        [SerializeField]
        private bool CheckIfTheresAnySlimesStillSpawning = true;
        [SerializeField]
        private float CheckSlimesLeftTimer;
        private int LastWave;

        private void Awake()
        {
            LastWave = 0;
            foreach (var SlimeGroup in WaveSpawner)
            {
                if(SlimeGroup.Wave > LastWave)
                {
                    LastWave = SlimeGroup.Wave;
                }
            }
        }

        void Update()
        {
            GameTimer += Time.deltaTime;
            SpawnTimer += Time.deltaTime;
            if(SpawnTimer > 0.1)
            {
                Spawn();
                SpawnTimer = 0f;
            }


            if ((CheckIfTheresAnySlimesStillSpawning == false))
            {
                CheckSlimesLeftTimer += Time.deltaTime;
                if(CheckSlimesLeftTimer > 1)
                {
                    GameObject[] SlimesRemaining = GameObject.FindGameObjectsWithTag("Slime");
                    if (SlimesRemaining.Length == 0)
                    {
                        Debug.Log("WaveDone :))");

                        if(WaveCounter > LastWave)
                        {
                            Debug.Log("You beat the Level!!"); //Make this go to the romance stage
                        }

                        WaveDelayTimer += Time.deltaTime;
                        if (WaveDelayTimer > WaveDelay)
                        {
                            WaveDelayTimer = 0f;
                            WaveCounter += 1;
                            GameTimer = 0;
                            CheckIfTheresAnySlimesStillSpawning = true;
                        }
                    }
                }
            }
        }

        private void Spawn()
        {
            CheckIfTheresAnySlimesStillSpawning = false;
            foreach (var SlimeGroup in WaveSpawner)
            {
                if (SlimeGroup.Wave != WaveCounter)
                {
                    continue;
                }

                if (SlimeGroup.Counter < SlimeGroup.TotalSpawned)
                {
                    CheckIfTheresAnySlimesStillSpawning = true;
                    if (GameTimer > SlimeGroup.SpawnDelay)
                    {
                        if (SlimeGroup.SpawnRate > SlimeGroup.RateTimer)
                        {
                            Instantiate(SlimeGroup.EnemyType, transform.position, Quaternion.identity);
                            SlimeGroup.RateTimer = 10;
                            SlimeGroup.Counter += 1;
                        }
                        else
                        {
                            SlimeGroup.RateTimer -= 0.5f;
                        }
                    }
                }

            }
        }
    }
}

