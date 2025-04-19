using UnityEngine;


public class Attack : MonoBehaviour
{
    public float deadTime;
    public float attackRecoil;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().InputMove = false;
            Vector2 force = new Vector2(-collision.transform.position.x + transform.position.x, -collision.transform.position.y + transform.position.y);
            collision.GetComponent<Rigidbody2D>().AddForceY(-force.y * attackRecoil, ForceMode2D.Impulse);
            collision.GetComponent<Rigidbody2D>().AddForceX(-force.x * attackRecoil, ForceMode2D.Impulse);
            void MoveAgain()
            {
                collision.GetComponent<PlayerMovement>().InputMove = true;
            }
            Invoke(nameof(MoveAgain), deadTime);

        }

    }

}
