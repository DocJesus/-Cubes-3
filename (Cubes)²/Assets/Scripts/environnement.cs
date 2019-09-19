using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class environnement : MonoBehaviour
{
    Ennemy ennem;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerEnter");
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerShoot>().Die();
            //appel le menu pour Restart ou Quit le jeu
        }

        if (other.tag == "Ennemy")
        {
            //les ennemy
        }
 
    }
    */

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ennemy")
        {
            ennem = other.GetComponent<Ennemy>();
            ennem.setUpArena();
            //other.isTrigger = false;
        }
    }

}
