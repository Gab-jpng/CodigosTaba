using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void IniciarNovoJogo()
    {
        SceneManager.LoadScene("FlorestaGeral"); 
    }

    public void CarregarJogoSalvo()
    {
        if (PlayerPrefs.HasKey("ExisteSave"))
        {
            PlayerPrefs.SetInt("CarregarSaveGatilho", 1);
            
            string cenaParaCarregar = PlayerPrefs.GetString("CenaSalva");
            SceneManager.LoadScene(cenaParaCarregar);
        }
        else
        {
            Debug.Log("Não existe nenhum jogo salvo para carregar.");
        }
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
}