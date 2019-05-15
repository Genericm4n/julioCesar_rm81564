using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectableController : MonoBehaviour {
    
    private void OnCollisionEnter(Collision col)
    {
        // verificacao de colicao com o jogador
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerController.points++;  // contabilizacao de pontos
            Destroy(gameObject);        // destruindo o objeto apos coletado
        }
    }
}
