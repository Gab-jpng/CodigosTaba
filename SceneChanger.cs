using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneChanger : MonoBehaviour
{

    public string nomeDaProximaCena;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(nomeDaProximaCena);
        }
    }
}