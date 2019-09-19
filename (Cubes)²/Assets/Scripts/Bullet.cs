using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Awake()
    {
    }

    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ennemy")
        {
            Ennemy enem;

            enem = other.GetComponent<Ennemy>();
            EnnemyManager.identity.KillFeed(enem.identity);
            enem.Die();
            Destroy(this.gameObject);

        }
        if (other.tag == "environnement")
        {
            Destroy(this.gameObject);
        }
    }

}
