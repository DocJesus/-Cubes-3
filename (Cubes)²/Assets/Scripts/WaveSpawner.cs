using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform center;

    [SerializeField]
    Transform[] spawnPoints;
    [SerializeField]
    float timeBetweenWaves = 15f;
    [SerializeField]
    Text timeText;
    [SerializeField]
    Text waveText;

    EnnemyManager manager;
    float countDown;
    public waves[] wave;
    int nbWave;

	// Use this for initialization
	void Start ()
    {
        manager = GetComponent<EnnemyManager>();
        countDown = timeBetweenWaves;
        nbWave = 0;
        countDown = 5;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.isOver)
            return;

        if (countDown <= 0)
        {
            StartCoroutine(SpawnWave());
            nbWave += 1;
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        timeText.text = string.Format("{0:00.00}", countDown);
        waveText.text = "Wave:\n" +     nbWave;
    }

    IEnumerator SpawnWave()
    {
        waves currentWave = wave[nbWave];

        SpawnEnnemy(currentWave.greenNB, currentWave.greenEnnemy);
        SpawnEnnemy(currentWave.redNB, currentWave.redEnnemy);
        SpawnEnnemy(currentWave.yellowNB, currentWave.yellowEnnemy);

        yield return 0;
    }

    void SpawnEnnemy(int limit, GameObject bluePrint)
    {
        int j;
        Ennemy enem;

        for (int i = 0; i < limit; i++)
        {
            j = Random.Range(0, 15);
            GameObject inst = Instantiate(bluePrint, spawnPoints[j].position, spawnPoints[j].rotation);
            enem = inst.GetComponent<Ennemy>();
            enem.target = center;
            manager.AddEnney(enem.identity);

        }
    }



}
