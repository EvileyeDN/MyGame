using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
    private AudioSource playerAudio;
    public AudioClip FireSound;
    public GameObject projectilePrefab;
    public float Ammo = 10;
    private Tank tank;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        tank = GameObject.Find("Tank").GetComponent<Tank>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && Ammo > 0 && tank.TankControler == true)
        {
            playerAudio.PlayOneShot(FireSound, 1.0f);
            Ammo = Ammo - 1;
            Instantiate(projectilePrefab, transform.position, transform.rotation);


        }
        if (Ammo == 0)
        {
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        }

    }
   
}
