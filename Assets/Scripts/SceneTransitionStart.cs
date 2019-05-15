using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionStart : MonoBehaviour {

	void Start () {

        StartCoroutine("SceneTransition");
	}

    IEnumerator SceneTransition()
    {
        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadScene("NAC02RVIA_scene0");
    }
}
