using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoe : MonoBehaviour
{
    [SerializeField] protected float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            if (transform.position.x >= 144)
            {
                transform.Rotate(0, 180, 0);
            }
            if (transform.position.x <= 117)
            {
            transform.Rotate(0, 180, 0);
        }
        
    }
}
