using UnityEngine;

public class GlossaryManager : MonoBehaviour
{
    public GameObject painelGlossario;
    
    public GameObject[] palavrasDoGlossario; 

    void Start()
    {
        painelGlossario.SetActive(false);
        
        foreach(GameObject palavra in palavrasDoGlossario)
        {
            if(palavra != null) palavra.SetActive(false);
        }
    }

   public void FecharGlossario()
    {
        painelGlossario.SetActive(false);
        Time.timeScale = 1f; 
    }

    public void AbrirGlossario()
    {
        painelGlossario.SetActive(true);
    }

    public void DescobrirPalavra(int indiceDaPalavra)
    {
        if(indiceDaPalavra < palavrasDoGlossario.Length)
        {
            palavrasDoGlossario[indiceDaPalavra].SetActive(true);
            Debug.Log("Nova palavra da língua ze'egete registrada!");
        }
    }
}