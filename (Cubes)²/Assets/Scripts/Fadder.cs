using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fadder : MonoBehaviour {

    public Image screenFadder;
    public AnimationCurve curve;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void FaddIn()
    {
        StartCoroutine(faddeIn());
    }

    public void FaddeTo(string scene)
    {
        StartCoroutine(faddeOut(scene));
    }

    IEnumerator faddeIn()
    {
        float t = 1;

        while (t > 0f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);

            screenFadder.color = new Color(0, 0, 0, a);
            yield return 0;

        }
    }

    IEnumerator faddeOut(string _scene)
    {
        float t = 0f;

        while (t < 1)
        {
            t += Time.deltaTime;

            //récupère la valeur de l'alpha par la courbe en fonctio de t
            float a = curve.Evaluate(t);

            //couleur noire
            screenFadder.color = new Color(0f, 0f, 0f, a);

            //skip une frame, permet de faire les chose petit à petit
            yield return 0;
        }

        // ne se lit que si le fondu est terminé
        SceneManager.LoadScene(_scene);
    }

}
