using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private int enemyCount;
    [SerializeField] private int mapHeight;
    [SerializeField] private int mapWidth;

    private void Start()
    {
        while (enemyCount > 0)
        {
            int randomHeight = Random.Range(-mapHeight / 2, mapHeight / 2);
            int randomWidth = Random.Range(-mapWidth / 2, mapWidth / 2);

            Vector3 randomPos = new Vector3(randomHeight, randomWidth, 0);
            int index = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[index], randomPos, Quaternion.identity);

            enemyCount--;
        }
    }
}
