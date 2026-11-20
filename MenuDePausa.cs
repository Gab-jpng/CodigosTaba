using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuDePausa : MonoBehaviour
{
    public GameObject painelDePausa;
    public GameObject painelGlossario; 
    
    private SaveManager gerenciadorDeSave; 

    void Start()
    {
        painelDePausa.SetActive(false);
        gerenciadorDeSave = FindFirstObjectByType<SaveManager>(); 
    }

    public void PausarJogo()
    {
        painelDePausa.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void ContinuarJogo()
    {
        painelDePausa.SetActive(false);
        Time.timeScale = 1f; 
    }

    public void AbrirGlossarioDaPausa()
    {
        if(painelGlossario != null) painelGlossario.SetActive(true);
        painelDePausa.SetActive(false); 
    }

    public void VoltarAoMenuInicial()
    {
        if(gerenciadorDeSave != null) gerenciadorDeSave.SalvarJogo();
        
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MenuInicial"); 
    }
}