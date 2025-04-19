using UnityEngine;

public class Cargo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerItems>().cargoCount++;
            Destroy(gameObject);
        }
    }
}
