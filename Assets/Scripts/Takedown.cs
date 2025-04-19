using UnityEngine;

public class Takedown : MonoBehaviour
{
    public GameObject tDownButton;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tDownButton.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                tDownButton.SetActive(false);


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
