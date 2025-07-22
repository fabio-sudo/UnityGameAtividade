using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI texto;
    public Button botao;
    private void Awake()
    {
        botao.onClick.AddListener(ResetScene);
    }

    // M�todo para resetar a cena
    public void ResetScene()
    {
        // Faz o texto e o bot�o desaparecerem
        texto.gameObject.SetActive(false);
        botao.gameObject.SetActive(false);

        // Obt�m o nome da cena atual e recarrega
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }
}
