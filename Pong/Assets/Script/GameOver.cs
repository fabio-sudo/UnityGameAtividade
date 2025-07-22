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

    // Método para resetar a cena
    public void ResetScene()
    {
        // Faz o texto e o botão desaparecerem
        texto.gameObject.SetActive(false);
        botao.gameObject.SetActive(false);

        // Obtém o nome da cena atual e recarrega
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }
}
