using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerSecret : MonoBehaviour
{
    public int SphereCount;
    public int RockCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SphereCount = FindObjectsOfType<Coin>().Length;
        RockCount = FindObjectsOfType<DestroyCollision>().Length;
        if (SphereCount == 0 && RockCount == 0)
        {
            SceneManager.LoadScene("Level2.1", LoadSceneMode.Single);
        }
    }
}
