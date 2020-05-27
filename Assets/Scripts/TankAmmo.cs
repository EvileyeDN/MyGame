using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAmmo : MonoBehaviour
{
    private Rigidbody ammorb;
    public float speed = 30.0f;
    public float test = 1;
    // Start is called before the first frame update
    void Start()
    {
        ammorb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Grond"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }

    }

}
