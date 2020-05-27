using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptLevel2 : MonoBehaviour
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
        enemyCount = FindObjectsOfType<FishScriptLevel2>().Length;
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
