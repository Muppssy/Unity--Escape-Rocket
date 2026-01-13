using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinController : MonoBehaviour
{
    public float vitesseCoin = 2f;
  
   
    
    void Start()
    {
        
    }

    void Update()
    {
        // Déplacement de droite à gauche vers la fusée
        transform.position -= new Vector3(-vitesseCoin * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Sol"))
        {
            print("Pièce touchée ! Redémarrage du jeu...");
            Time.timeScale = 1f;
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }
}
