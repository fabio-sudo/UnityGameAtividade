using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float speedBol = 5f;
    private Vector2 speed;


    private AudioSource audioSource; // Referência ao componente de áudio


    //Game Over
    public TextMeshProUGUI texto;
    public Button botao;



    private void Update()
    {
        ForaDaArea();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtém o componente Rigidbody2D

        speed = GetRandomDirection();

        rb.linearVelocity = speed * speedBol; // Define a velocidade inicial

        // Obtém o componente AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    //Direções da Bola Pong
    private Vector2 GetRandomDirection()
    {
        // Define valores aleatórios para X e Y (-1 ou 1)
        float xDirection = Random.value > 0.5f ? 1f : -1f;
        float yDirection = Random.value > 0.5f ? 1f : -1f;

        // Retorna o vetor normalizado (direção unitária)
        return new Vector2(xDirection, yDirection).normalized;
    }


    // Quando a bola colide com outro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Toca o som da colisão
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }


    private void ForaDaArea()
    {
        // Obtém a posição X do GameObject
        float posicaoX = transform.position.x;

        // Condição para verificar se está em -9 ou 9
        if (posicaoX <= -13)
        {
            texto.text = "Game Over!"; // Define o texto como Game Over

            // Ativa o texto e o botão
            texto.gameObject.SetActive(true);
            botao.gameObject.SetActive(true);
        }
        else if (posicaoX >= 13)
        {
            texto.text = "Win!"; // Define o texto como Win

            // Ativa o texto e o botão
            texto.gameObject.SetActive(true);
            botao.gameObject.SetActive(true);
        }
    }




    }
