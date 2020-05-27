using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretLevelPlayer : MonoBehaviour
{
    public GameObject PressF;
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    private GameManager gameManager;
    private Rigidbody playerRb;
    private Animator playerAnim;
    public float jumpforce = 10;
    public bool isOnGround = true;
    public bool Tank = false;
    public GameObject TankCamera;
    [SerializeField] protected float Verticalinput;
    [SerializeField] protected float speed = 5.0f;
    private Vector3 Test = new Vector3(0, -100, 0);
    private Vector3 Test2 = new Vector3(0, 100, 0);
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            transform.position = new Vector3(4, 2, 0);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            playerAnim.SetTrigger("Win");
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Test * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Test2 * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            playerAnim.SetBool("Walk", false);
            playerAnim.SetTrigger("JumpTrig");
            playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isOnGround = false;
        }
        if (Input.GetKey(KeyCode.W))
        {
            playerAnim.SetBool("Walk", true);
            Verticalinput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * Time.deltaTime * speed * Verticalinput);

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.SetBool("Walk", false);
            Tank = false;
        }
        if (Tank == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                PressF.SetActive(true);
                TankCamera.SetActive(true);
                Tank = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Tank"))
        {
            Tank = true;
        }
    }
    }
