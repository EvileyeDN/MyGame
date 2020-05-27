using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemyScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<FishCript>().Length;
        if (enemyCount == 0)
        {
            Spawn();
        }
    }
    private void Spawn()
    {
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    }
}
