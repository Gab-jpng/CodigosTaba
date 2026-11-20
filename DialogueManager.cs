using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public GameObject CaixaDialogoBase;
    public TMP_Text NomeNPC;
    public TMP_Text FalaNPC;
    public GlossaryManager gerenciadorDeGlossario;
    
    public GameObject painelBotoesResposta; 

    public float velocidadeDeDigitacao = 0.05f;

    void Start()
    {
        CaixaDialogoBase.SetActive(false);
        if(painelBotoesResposta != null) painelBotoesResposta.SetActive(false);
    }

    public void IniciarDialogo(string nomeNpc, string fraseNpc)
    {
        CaixaDialogoBase.SetActive(true);
        NomeNPC.text = nomeNpc;
        FalaNPC.text = "";
        
        StartCoroutine(DigitarFrase(fraseNpc));
    }


    IEnumerator DigitarFrase(string fraseNpc)
    {
        foreach (char letra in fraseNpc.ToCharArray())
        {
            FalaNPC.text += letra; 
            yield return new WaitForSeconds(velocidadeDeDigitacao); 
        }
        
        if(painelBotoesResposta != null)
        {
             painelBotoesResposta.SetActive(true);
        }
    }
    
    public void FecharDialogo()
    {
         CaixaDialogoBase.SetActive(false);
         if(painelBotoesResposta != null) painelBotoesResposta.SetActive(false);
    }
    public void EscolherResposta(int indiceDaResposta)
    {
        if(painelBotoesResposta != null) painelBotoesResposta.SetActive(false);

        if (indiceDaResposta == 1)
        {
            gerenciadorDeGlossario.DescobrirPalavra(0); 
            FecharDialogo(); 
        }
        else if (indiceDaResposta == 2)
        {
            gerenciadorDeGlossario.DescobrirPalavra(1);
            FecharDialogo(); 
        }
    }
    
}