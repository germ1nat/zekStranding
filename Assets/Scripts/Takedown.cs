using UnityEngine;

public class Takedown : MonoBehaviour
{
    public GameObject tDownButton;
    public Rigidbody2D rbPlayer;
    public Rigidbody2D rbEnemy;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tDownButton.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                tDownButton.SetActive(false);
                rbEnemy.linearVelocity = new Vector2(0, 0);
                rbPlayer.linearVelocity = new Vector2(0, 0);

            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tDownButton.SetActive(false);
        }
    }
}
