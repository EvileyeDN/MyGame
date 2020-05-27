using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public GameObject PressF;
    public GameObject TankCamera;
    public GameObject SaphiChan;
    public bool TankControler = false;
    private Rigidbody playerRb;
    private GameManager gameManager;
    [SerializeField] protected float speed = 5.0f;
    [SerializeField] protected float turnspeed;
    [SerializeField] protected float horizontalinput;
    [SerializeField] protected float forwardinput;
    private Vector3 offset = new Vector3(0, 0, -4);
    public int SphereCount;
    // Start is called before the first frame update
    void Start()
    {
      
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (transform.position.y < -10)
        {
            transform.position = new Vector3(4, 2, 0);
        }
        if (TankCamera.active)
        {
            
            SaphiChan.SetActive(false);
            TankControler = true;
        }
        if (TankControler == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                PressF.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                PressF.SetActive(false);
                SaphiChan.SetActive(true);
                SaphiChan.transform.position = transform.position + offset;
                TankControler = false;
                TankCamera.SetActive(false);
            }
            horizontalinput = Input.GetAxis("Horizontal");
            forwardinput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardinput);
            transform.Rotate(Vector3.up, Time.deltaTime * forwardinput * 15 * horizontalinput);
        }
    }
}
