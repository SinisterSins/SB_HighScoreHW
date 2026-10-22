using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Edible"))
        {
            Destroy(other.gameObject);
            Debug.Log("Edible hit boundary");

        }
        if (other.gameObject.CompareTag("Inedible"))
        {
            Destroy(other.gameObject);
            Debug.Log("Inedible hit boundary");
        }
    }
}
