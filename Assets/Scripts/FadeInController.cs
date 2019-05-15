using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInController : MonoBehaviour {

    Animator animeF;

	void Start ()
    {
        animeF = GetComponent<Animator>();
	}
	
	void Update () {

        if (PlayerController.triggerON == true)
        {
            animeF.SetBool("fade_in", true);
        }
	}
}
