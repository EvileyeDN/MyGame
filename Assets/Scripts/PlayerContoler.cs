using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class PlayerContoler : MonoBehaviour

{
    private GameManager gameManager;
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public float jumpforce = 10;
    public bool isOnGround = true;
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
        PlayerContoller();
        // if y-10 spawn again player
        if (transform.position.y < -10)
        {
            transform.position = new Vector3(-4, 0, 0);
            gameManager.UpdateLives(-1);
            playerAnim.SetTrigger("Damage");
        }
      
        if (transform.position.z > 1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        }
        if (transform.position.x < -7)
        {
            transform.position = new Vector3(-7, transform.position.y, transform.position.z);
        }
        if (gameManager.GameOver == true && gameManager.Lives==0)
        {
            playerAnim.SetBool("Death", true);
        }

    }
   public void PlayerContoller()
    {
        if (gameManager.GameOver==false)
        {

        
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
            }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            Destroy(collision.gameObject);
            gameManager.UpdateLives(-1);
            playerAnim.SetTrigger("Damage");
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);

        }
        if (collision.gameObject.CompareTag("Live"))
        {
            Destroy(collision.gameObject);
            gameManager.UpdateLives(3);
        }
        if (collision.gameObject.CompareTag("SecretLevel"))
        {
            SceneManager.LoadScene("Secret", LoadSceneMode.Single);
        }
        if (collision.gameObject.CompareTag("Doe"))
        {
            gameManager.UpdateLives(-1);
            playerAnim.SetTrigger("Damage");
        }
        if (collision.gameObject.CompareTag("Final"))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }

}
