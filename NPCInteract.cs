using UnityEngine;
using UnityEngine.InputSystem; 

public class NPCInteract : MonoBehaviour
{
    public string nomeDoNPC;
    
    [TextArea(3, 5)] 
    public string fraseDoNPC; 

    [TextArea(3, 5)] 
    public string fraseMissaoConcluida; 

    public string itemNecessario; 
    
    private bool jogadorPerto = false;
    private DialogueManager gerenciadorDeDialogo;
    private Inventario inventarioDoJogo;

    void Start()
    {
        gerenciadorDeDialogo = FindFirstObjectByType<DialogueManager>();
        inventarioDoJogo = FindFirstObjectByType<Inventario>(); 
    }

    void Update()
    {
        if (jogadorPerto && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (!string.IsNullOrEmpty(itemNecessario) && inventarioDoJogo != null && inventarioDoJogo.TemItem(itemNecessario))
            {
                inventarioDoJogo.RemoverItem(itemNecessario);
                
                gerenciadorDeDialogo.IniciarDialogo(nomeDoNPC, fraseMissaoConcluida);
                
                itemNecessario = ""; 
            }
            else
            {
                gerenciadorDeDialogo.IniciarDialogo(nomeDoNPC, fraseDoNPC);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jogadorPerto = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jogadorPerto = false;
            if(gerenciadorDeDialogo != null) gerenciadorDeDialogo.FecharDialogo(); 
        }
    }
}