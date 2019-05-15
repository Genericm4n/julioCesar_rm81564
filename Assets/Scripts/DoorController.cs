using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {
    
    // definindo variaveis
    Animator animeD;

	void Awake ()
    {
        animeD = GetComponent<Animator>();
	}
	
	void Update ()
    {
        if (PlayerController.points == 5)
        {
            animeD.SetBool("open", true);
        }
	}
}
