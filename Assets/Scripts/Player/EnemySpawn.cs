using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemiesPrefabs;
    public Transform[] spawnPoints;

    public GameObject enemySpawnAnim;

    public float spawnStartTime = 1f;
    public static float spawnTimer = 2.2f;

    public AudioClip enemySpawnSound;

    private float _enemySpawnAnimClipLength = 1.59f;
    
    [SerializeField]private Transform player;
    private int spawnPointIndex;
    private int enemyPrefabIndex;
    private void Start()
    {
        InvokeRepeating("Spawn",spawnStartTime,spawnTimer);
    }

    void Spawn()
    {
        spawnPointIndex = Random.Range(0, spawnPoints.Length);
        enemyPrefabIndex = Random.Range(0, enemiesPrefabs.Length);
        GameObject eSA = Instantiate(enemySpawnAnim, spawnPoints[spawnPointIndex].position, Quaternion.identity);
        Destroy(eSA,_enemySpawnAnimClipLength);
        Invoke("PlayerSpawn",_enemySpawnAnimClipLength);
    }

    void PlayerSpawn()
    {
        AudioPlay.clip = enemySpawnSound;
        AudioPlay.isPlaying = true;
        GameObject go = Instantiate(enemiesPrefabs[enemyPrefabIndex], spawnPoints[spawnPointIndex].position,
            Quaternion.identity);
        go.GetComponent<Enemy>().player = player;
    }
}
