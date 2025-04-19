using UnityEngine;

public class BlowTorch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerItems>().blowTorch = true;
            Destroy(gameObject);

        }
    }
}
