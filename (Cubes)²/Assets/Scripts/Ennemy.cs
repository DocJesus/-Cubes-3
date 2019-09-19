using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public Vector3 RotateAmount;
    public string identity;

    //Rigidbody rig;
    GameObject[] randoms;
    AudioSource source;

    [Header("targetting")]
    public Transform target;

    [Header("Child managment")]
    [SerializeField]
    GameObject childSpawn;
    [SerializeField]
    int numberOfChild;

    [SerializeField]
    float speed;
    [SerializeField]
    GameObject particule;


    void Start()
    {
        Setup();
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        float distanceFrame = speed * Time.deltaTime;

        transform.Translate(dir.normalized * distanceFrame, Space.World);
        if (dir.magnitude <= distanceFrame)
        {
            getRandomMove();
        }
    }

    void Setup()
    {
        source = GetComponent<AudioSource>();
        randoms = GameObject.FindGameObjectsWithTag("waypoint");
        //rig = GetComponent<Rigidbody>();
        if (identity != "Yellow")
            getRandomMove();
    }

    private void FixedUpdate()
    {
        transform.Rotate(RotateAmount * Time.deltaTime);
    }

    public void Die()
    {
        if (numberOfChild != 0)
        {
            for (int i = 0; i < numberOfChild; i++)
            {
                Ennemy enem;
                GameObject inst = Instantiate(childSpawn, transform.position, transform.rotation);
                enem = inst.GetComponent<Ennemy>();
                enem.setUpArena();
                EnnemyManager.identity.AddEnney(enem.identity);

            }
        }
        ScoreUI.score += 1;
        GameObject partInst = Instantiate(particule, transform.position, transform.rotation);
        Destroy(partInst, 1);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerShoot>().Die();
        }
    }
    

    void getRandomMove()
    {
        int i = Random.Range(0, randoms.Length);
        target = randoms[i].transform;
    }

    public void setUpArena()
    {
        Setup();
        if (identity == "Yellow" && (Random.Range(0, 2) == 1))
            target = GameManager.playerInstance.transform;
        else
        {
            getRandomMove();
        }
    }
}
