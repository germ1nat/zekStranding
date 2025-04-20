using UnityEngine;

public class EnemyMovementY : MonoBehaviour
{

    public Rigidbody2D enemyRigid;
    public Transform enemyTransform;
    public Transform playerTransform;

    private bool isPlayerInside = false;
    public float step = 10f;
    public float patrolSpeed = 1f;
    public float patrolTimer = 7f;
    private float patrolReset;
    private void Start()
    {
        enemyRigid.linearVelocityY = patrolSpeed;
        patrolReset = patrolTimer;
    }
    private void Update()
    {

        if (isPlayerInside)
        {
            Vector2 distance = playerTransform.position - enemyTransform.position;
            float angleRad = Mathf.Atan2(distance.y, distance.x);
            float angle = (180 / Mathf.PI) * angleRad;
            enemyRigid.rotation = angle;
            enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, playerTransform.position, step * Time.deltaTime);

        }
        if (!isPlayerInside)
        {
            if (patrolReset >= 0)
            {
                patrolReset -= Time.deltaTime;
                if (patrolReset <= 0)
                {
                    enemyRigid.linearVelocityY *= -1;
                    patrolReset = patrolTimer;
                }
            }
            if (enemyRigid.linearVelocityY < 0)
            {
                enemyRigid.rotation = 270;
            }
            if (enemyRigid.linearVelocityY > 0)
            {
                enemyRigid.rotation = 90;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            isPlayerInside = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInside = false;

        }
    }
}