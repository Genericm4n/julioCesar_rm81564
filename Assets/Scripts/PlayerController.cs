using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    
    // definicao de variaveis
    #region variables
    public float velActual;         // velocidade atual do char
    public float velMax = 5.0f;     // velocidade maxima permitida ao char
    public float velRot = 130.0f;   // velocidade de rotacao do char
    public float xrl8I = 0.3f;      // aceleracao inicial do char
    public float xrl8 = 0.03f;      // aceleracao base do char
    public float dxrl8 = 0.07f;     // desaceleracao do char

    public static float points;     // pontos por coletar o item
    public Text txtPoint;           // texto que exibira a pontuacao
    public Image image_fade;        // imagem responsável pelo fade-in

    public static bool triggerON;   // boleano que verificara colisao com trigger

    Animator anime;                 // variavel que chama o componente Animator
    #endregion
    void Awake ()
    {
        anime = GetComponent<Animator>();

        points = 0;     // definindo quantos pontos o jogador comeca a partida

        triggerON = false;
	}
	
	void Update ()
    {
        // configuracao da rotacao - pt.1: input
        float hori = Input.GetAxisRaw("Horizontal");

        // configuracao da rotacao - pt2: rotacao
        Vector3 rotation = Vector3.up * hori * velRot * Time.deltaTime;

        // configuracao da movimentacao - pt.1: input
        float vert = Input.GetAxisRaw("Vertical");

        // configuracao da movimentacao - pt.2: velocidade e aceleracao
        if (vert>0 && velActual < velMax)
        {
            velActual += (velActual == 0) ? xrl8I : xrl8;
        }
        else if (vert == 0 && velActual > 0)
        {
            velActual -= dxrl8;
        }

        // definicao dos valores minimo e maximo que a velocidade atual pode possuir
        velActual = Mathf.Clamp(velActual, 0, velMax);

        // configuracao da movimentacao - pt.3: deslocamento
        transform.Translate(Vector3.forward * vert * velActual * Time.deltaTime);

        // configuracao da rotacao - pt.3: associacao com a movimentacao
        if (velActual > 0)
        {
            transform.Rotate(rotation);
        }

        // configuracao da animacao
        float valueAni = Mathf.Clamp(velActual / velMax, 0, 1);     // velocidade que o slider do parametro "speed" ira possuir
        anime.SetFloat("speed", valueAni);                          // "Setando" o paramentro

        // fazendo o texto da pontuacao exibir os pontos obtidos
        txtPoint.text = points.ToString();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Transition")
        {
            triggerON = true;
            StartCoroutine("Fade_in");
        }
    }

    IEnumerator Fade_in()
    {
        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadScene("NAC02RVIA_scene1");
    }
}
