using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float speedBol = 5f;
    private Vector2 speed;


    private AudioSource audioSource; // Refer�ncia ao componente de �udio


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

}
