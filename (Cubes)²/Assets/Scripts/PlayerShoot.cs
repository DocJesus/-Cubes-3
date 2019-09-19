using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    private float camRayLength = 200f;
    int floorMask;
    Vector3 playertoMouse;
    AudioSource source;

    [SerializeField]
    Rigidbody playerRigidbody;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform scope;
    [SerializeField]
    private Transform parttoRotate;
    [SerializeField]
    private float playerGlide = 50f;
    [SerializeField]
    AudioClip laserSound;

    [SerializeField]
    GameObject deathParticule;



	// Use this for initialization
	void Start ()
    {
        floorMask = LayerMask.GetMask("Floor");
        //playerRigidbody = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Turning();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
	}

    void Turning()
    {
        Ray cameray = Camera.main.ScreenPointToRay(Input.mousePosition);    

        RaycastHit floorhit;

        if (Physics.Raycast(cameray, out floorhit, camRayLength, floorMask))
        {
            playertoMouse = floorhit.point - transform.position;
            playertoMouse.y = 0;

            Quaternion rotation = Quaternion.LookRotation(playertoMouse);
            parttoRotate.rotation = rotation;
        }
    }

    void Shoot()
    {
        GameObject inst = Instantiate(bullet, scope.position, scope.rotation);
        source.PlayOneShot(laserSound);
        //flash de tir ?
        //particule system de tir ?
        inst.GetComponent<Rigidbody>().velocity = 75 * transform.forward;
        playerRigidbody.velocity = playerGlide * -playertoMouse;
    }

    public void Die()
    {
        this.gameObject.SetActive(false);
        GameObject inst = Instantiate(deathParticule, transform.position, transform.rotation);
        Destroy(inst, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "environnement")
        {
            Die();
        }
    }
}
