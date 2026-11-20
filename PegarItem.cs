using UnityEngine;
using UnityEngine.InputSystem;

public class PegarItem : MonoBehaviour
{
    public string nomeDoItem; 
    private bool jogadorPerto = false;
    private Inventario inventarioDoJogo;

   void Start()
    {
        inventarioDoJogo = FindFirstObjectByType<Inventario>();

        if (inventarioDoJogo != null && inventarioDoJogo.TemItem(nomeDoItem))
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (jogadorPerto && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Coletar();
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
        }
    }

    private void Coletar()
    {
        if(inventarioDoJogo != null)
        {
            inventarioDoJogo.AdicionarItem(nomeDoItem);
        }
        
        Destroy(gameObject);
    }
}