using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SpawnData_.Editors
{
    [CustomEditor(typeof(SpawnCon))]
    public class CustomEnemyDatabase : Editor
    {
        SpawnCon db;
        public int InsertIndex = 0;
        void OnEnable()
        {
            db = (SpawnCon)target;
        }

        public override void OnInspectorGUI()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Total:" + db.WaveSpawner.Count);
            if (GUILayout.Button("AddEnemy"))
            {
                AddEnemy();
            }

            if (GUILayout.Button("InsertEnemy"))
            {
                InsertEnemy();
            }

            InsertIndex = EditorGUILayout.IntField(InsertIndex, GUILayout.Width(40));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Name", GUILayout.Width(100));
            GUILayout.Label("Wave", GUILayout.Width(40));
            GUILayout.Label("Rate", GUILayout.Width(40));
            GUILayout.Space(25);
            GUILayout.Label("Delay", GUILayout.Width(40));
            GUILayout.Label("Total", GUILayout.Width(40));
            GUILayout.Label("Prefab", GUILayout.Width(40));
            GUILayout.EndHorizontal();
            for (int cnt = 0; cnt < db.WaveSpawner.Count; cnt++)
            {
                
                GUILayout.BeginHorizontal();
                db.WaveSpawner[cnt].Name = GUILayout.TextField(db.WaveSpawner[cnt].Name, GUILayout.Width(100));
                db.WaveSpawner[cnt].Wave = EditorGUILayout.IntField(db.WaveSpawner[cnt].Wave, GUILayout.Width(40));
                db.WaveSpawner[cnt].SpawnRate = GUILayout.HorizontalSlider(db.WaveSpawner[cnt].SpawnRate,0,10, GUILayout.Width(40));
                GUILayout.Label("" + db.WaveSpawner[cnt].SpawnRate, GUILayout.Width(25));
                db.WaveSpawner[cnt].SpawnDelay = EditorGUILayout.FloatField(db.WaveSpawner[cnt].SpawnDelay, GUILayout.Width(40));
                db.WaveSpawner[cnt].TotalSpawned = EditorGUILayout.FloatField(db.WaveSpawner[cnt].TotalSpawned, GUILayout.Width(40));
                db.WaveSpawner[cnt].EnemyType = EditorGUILayout.ObjectField(db.WaveSpawner[cnt].EnemyType, typeof(GameObject), false,GUILayout.Width(120));

                if (GUILayout.Button("X"))
                {
                    RemoveEnemy(cnt);
                    return;
                }

                GUILayout.BeginVertical();
                if (GUILayout.Button((""),GUILayout.Width(20), GUILayout.Height(7)))
                {
                    MoveUp(cnt);
                    return;
                }

                if (GUILayout.Button((""),GUILayout.Width(20), GUILayout.Height(7)))
                {
                    MoveDown(cnt);
                    return;
                }
                GUILayout.EndVertical();
                GUILayout.EndHorizontal();
            }

            GUILayout.Space(10);
            base.OnInspectorGUI();
        }

        void AddEnemy()
        {
            db.WaveSpawner.Add(new SpawnData());
        }

        void RemoveEnemy(int index)
        {
            db.WaveSpawner.RemoveAt(index);
        }

        void InsertEnemy()
        {
            db.WaveSpawner.Insert(InsertIndex, new SpawnData());
        }

        void MoveDown(int index)
        {
            if(index < db.WaveSpawner.Count)
            {
                var item = db.WaveSpawner[index];
                db.WaveSpawner.RemoveAt(index);
                db.WaveSpawner.Insert(index + 1, item);
            }
        }

        void MoveUp(int index)
        {
            if (index > 0)
            {
                var item = db.WaveSpawner[index];
                db.WaveSpawner.RemoveAt(index);
                db.WaveSpawner.Insert(index - 1, item);
            }
        }
    }
}

