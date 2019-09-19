using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isOver;
    public static GameObject playerInstance;
    public Fadder fadder;

    AudioSource source;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    AudioClip playerDeathSound;


    // Use this for initialization
    void Start ()
    {
        source = GetComponent<AudioSource>();
        fadder.FaddIn();
        isOver = false;
        playerInstance = Instantiate(player);	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (!playerInstance.active && !isOver)
        {
            source.PlayOneShot(playerDeathSound);
            gameOver.SetActive(true);
            isOver = true;
        }
	}


}
