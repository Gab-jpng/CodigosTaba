using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public List<string> itensColetados = new List<string>();

    public void AdicionarItem(string nomeDoItem)
    {
        itensColetados.Add(nomeDoItem);
        Debug.Log("Item guardado no inventário: " + nomeDoItem);
    }

    public bool TemItem(string nomeDoItem)
    {
        return itensColetados.Contains(nomeDoItem);
    }

    public void RemoverItem(string nomeDoItem)
    {
        if (TemItem(nomeDoItem))
        {
            itensColetados.Remove(nomeDoItem);
            Debug.Log("Item entregue para o NPC: " + nomeDoItem);
        }
    }
}