using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Tank tank;
    private float towerimput;
    private float speed = 20.0f;
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
            towerimput = Input.GetAxis("tower");
            transform.Rotate(Vector3.down * Time.deltaTime * speed * towerimput);
        }
    }
}
