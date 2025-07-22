using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float speedBol = 5f;
    private Vector2 speed;


    private AudioSource audioSource; // Refer�ncia ao componente de �udio


    //Game Over
    public TextMeshProUGUI texto;
    public Button botao;



    private void Update()
    {
        ForaDaArea();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obt�m o componente Rigidbody2D

        speed = GetRandomDirection();

        rb.linearVelocity = speed * speedBol; // Define a velocidade inicial

        // Obt�m o componente AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    //Dire��es da Bola Pong
    private Vector2 GetRandomDirection()
    {
        // Define valores aleat�rios para X e Y (-1 ou 1)
        float xDirection = Random.value > 0.5f ? 1f : -1f;
        float yDirection = Random.value > 0.5f ? 1f : -1f;

        // Retorna o vetor normalizado (dire��o unit�ria)
        return new Vector2(xDirection, yDirection).normalized;
    }


    // Quando a bola colide com outro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Toca o som da colis�o
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }


    private void ForaDaArea()
    {
        // Obt�m a posi��o X do GameObject
        float posicaoX = transform.position.x;

        // Condi��o para verificar se est� em -9 ou 9
        if (posicaoX <= -13)
        {
            texto.text = "Game Over!"; // Define o texto como Game Over

            // Ativa o texto e o bot�o
            texto.gameObject.SetActive(true);
            botao.gameObject.SetActive(true);
        }
        else if (posicaoX >= 13)
        {
            texto.text = "Win!"; // Define o texto como Win

            // Ativa o texto e o bot�o
            texto.gameObject.SetActive(true);
            botao.gameObject.SetActive(true);
        }
    }




    }
