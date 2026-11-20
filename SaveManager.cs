using UnityEngine;
using UnityEngine.SceneManagement; 
using System.Collections.Generic; 

public class SaveManager : MonoBehaviour
{
    public GameObject jogador; 
    public Inventario inventarioDoJogo; 

    void Awake()
    {
        if (inventarioDoJogo == null) 
            inventarioDoJogo = FindFirstObjectByType<Inventario>();

        if (PlayerPrefs.GetInt("CarregarSaveGatilho") == 1)
        {
            CarregarDados();
            PlayerPrefs.SetInt("CarregarSaveGatilho", 0); 
        }
    }

    public void SalvarJogo()
    {
        if (jogador != null)
        {
            PlayerPrefs.SetFloat("PosicaoX", jogador.transform.position.x);
            PlayerPrefs.SetFloat("PosicaoY", jogador.transform.position.y);
            PlayerPrefs.SetString("CenaSalva", SceneManager.GetActiveScene().name);
            
            if (inventarioDoJogo != null)
            {
                string itensJuntos = string.Join(",", inventarioDoJogo.itensColetados);
                PlayerPrefs.SetString("InventarioSalvo", itensJuntos);
            }

            PlayerPrefs.SetInt("ExisteSave", 1);
            PlayerPrefs.Save(); 
            
            Debug.Log("Progresso e Inventário salvos automaticamente!");
        }
    }

    private void CarregarDados()
    {
        if (PlayerPrefs.HasKey("ExisteSave"))
        {
            // Carrega a posição
            if (jogador != null)
            {
                float x = PlayerPrefs.GetFloat("PosicaoX");
                float y = PlayerPrefs.GetFloat("PosicaoY");
                jogador.transform.position = new Vector3(x, y, 0);
            }

            if (inventarioDoJogo != null && PlayerPrefs.HasKey("InventarioSalvo"))
            {
                string itensJuntos = PlayerPrefs.GetString("InventarioSalvo");
                inventarioDoJogo.itensColetados.Clear(); 

                if (!string.IsNullOrEmpty(itensJuntos))
                {
                    string[] itensSeparados = itensJuntos.Split(',');
                    inventarioDoJogo.itensColetados.AddRange(itensSeparados);
                }
            }
        }
    }

    private void OnApplicationQuit()
    {
        SalvarJogo();
    }
}