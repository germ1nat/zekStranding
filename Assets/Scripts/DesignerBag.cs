using UnityEngine;

public class DesignerBag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerItems>().designerBag = true;
            Destroy(gameObject);
        }
    }
}
