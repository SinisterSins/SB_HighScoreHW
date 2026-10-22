using UnityEngine;

public class IngredientController : MonoBehaviour
{
    public int pointValue;
    public ScoreManager scoreManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        scoreManager.ChangeScore(pointValue);
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Edible"))
            {
                Destroy(gameObject);
                Debug.Log("Edible object in pot!");
            }
            else if (gameObject.CompareTag("Inedible"))
            {
                Destroy(gameObject);
                Debug.Log("That doesn't belong in soup");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
            Debug.Log("Hit the Floor");
        }
    }

}
