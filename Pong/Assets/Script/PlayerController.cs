
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{


    private Vector2 minhaPosicao;  // Declaração de uma variável para armazenar a posição da raquete
    public float meuY;  // Variável pública para controlar a coordenada Y da raquete
    public float speed = 5f;
    public bool Player;

    //Limite da tela
    private float limit = 3f;

    //Variavel para checar se deve ser controlada pela IA
    public bool automatico = false;

    public Transform bola;//Pega a posicao da bola


    void Start()
    {
        float deltaVelocidade = speed * Time.deltaTime;

        minhaPosicao = transform.position;  // Armazena a posição inicial da raquete
    }

    // Update is called once per frame
    void Update()
    {

        float deltaVelocidade = speed * Time.deltaTime;
        minhaPosicao.y = meuY;  // Atualiza o valor de 'y' da posição com o valor de 'meuY'

        transform.position = minhaPosicao;  // Define a nova posição da raquete

        if (automatico == false)
        {


            if (Player)
            {
                if (Keyboard.current.upArrowKey.isPressed && meuY < limit)
                {
                    meuY += deltaVelocidade;
                }
                if (Keyboard.current.downArrowKey.isPressed && meuY > -limit)
                {
                    meuY -= deltaVelocidade;
                }
            }
            else
            {
                if (Keyboard.current.wKey.isPressed && meuY < limit)
                {
                    meuY += deltaVelocidade;
                }
                if (Keyboard.current.sKey.isPressed && meuY > -limit)
                {
                    meuY -= deltaVelocidade;
                }
            }




        }
        else {

            // IA segue a bola automaticamente no eixo Y
            if (bola != null)
            {
                float direcao = Mathf.Sign(bola.position.y - meuY); // +1 ou -1 dependendo da posição da bola
                meuY += direcao * deltaVelocidade;

                // Limitar a raquete dentro dos limites da tela
                meuY = Mathf.Clamp(meuY, -limit, limit);

                minhaPosicao.y = meuY;
                transform.position = minhaPosicao;
            }

        }

        

    }
}
