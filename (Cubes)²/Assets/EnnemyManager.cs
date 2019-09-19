using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnnemyManager : MonoBehaviour
{

    public static EnnemyManager identity = null;

    [SerializeField]
    private AudioClip deathClip;
    [SerializeField]
    Text ennemyLeft;

    AudioSource source;

    [Header("Wave Status")]
    int nbTotalRED = 0;
    int nbTotalYellow = 0;
    int nbTotalGreen = 0;


    // Use this for initialization
    void Start ()
    {
        if (identity != null)
            Debug.LogError("double singleton");
        identity = this;
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        ennemyLeft.text = "Ennemy Left:\n-" + nbTotalRED + " Red\n-" + nbTotalGreen + " Green\n-" + nbTotalYellow + " Yellow";
    }

    public void KillFeed(string ennemy)
    {
        if (ennemy == "Yellow")
            nbTotalYellow -= 1;
        if (ennemy == "Red")
            nbTotalRED -= 1;
        if (ennemy == "Green")
            nbTotalGreen -= 1;
        source.PlayOneShot(deathClip);
    }

    public void AddEnney(string ennemy)
    {
        if (ennemy == "Yellow")
            nbTotalYellow += 1;
        if (ennemy == "Red")
            nbTotalRED += 1;
        if (ennemy == "Green")
            nbTotalGreen += 1;
    }
}
