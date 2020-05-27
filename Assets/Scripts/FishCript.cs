using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCript : MonoBehaviour
{
    public float speed = -30.0f;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (transform.position.x < 88)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
     if (collision.gameObject.CompareTag("Player"))
     {
            Destroy(gameObject);
            gameManager.UpdateLives(-1);
        }
       
       
    }
}
