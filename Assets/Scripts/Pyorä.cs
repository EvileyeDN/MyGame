using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyorä : MonoBehaviour
{
    private float forwardinput;
    private float speed = 100.0f;
    private Tank tank;
    // Start is called before the first frame update
    void Start()
    {
        tank = GameObject.Find("Tank").GetComponent<Tank>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tank.TankControler == true)
        {
            forwardinput = Input.GetAxis("Vertical");
            transform.Rotate(Vector3.right * Time.deltaTime * speed * forwardinput);
        }
        
    }
}
