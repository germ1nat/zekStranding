using UnityEngine;
using UnityEngine.UI;

public class Takedown : MonoBehaviour
{
    public GameObject tDownButton;
    public GameObject player;
    public Rigidbody2D rbPlayer;
    
    public Rigidbody2D rbEnemy;
    public GameObject slideer;
    private bool isColliding = false;
    public float enemyReflex;
    public Slider slider;
    public float tDownBarDecrease = 5f;
    public float tDownBarIncrease = 2f;
    public float tDonBarDecrease;
    private float tDownBar = 40f;
    public GameObject slidingz;
    public GameObject enemyObj;

    private void FixedUpdate()
    {


        if (isColliding)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                
                slideer.SetActive(true);
                rbEnemy.linearVelocity = new Vector2(0, 0);
                rbPlayer.linearVelocity = new Vector2(0, 0);
                player.GetComponent<PlayerMovement>().InputMove = false;
                Invoke(nameof(DecreaseIncrementation),.1f);

            }
            if (!Input.GetKey(KeyCode.Q))
            {
                Invoke(nameof(EnemyResponse), enemyReflex);
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                slideer.SetActive(false);
                rbEnemy.linearVelocity = new Vector2(0, -1);
                player.GetComponent<PlayerMovement>().InputMove = true;
            }
        }
    }
    private void Update()
    {
        TakeDownBar();
        Value();
        if (tDownBar == 100)
        {
            Destroy(enemyObj);
            
        }
        if (tDownBar == 0)
        {
            rbEnemy.linearVelocity = new Vector2(-1, 0);
            slideer.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            

            tDownButton.SetActive(true);
            isColliding = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tDownButton.SetActive(false);
            isColliding = false;
        }
    }
    void EnemyResponse()
    {
        slideer.SetActive(false);
        rbEnemy.linearVelocity = new Vector2(-1, 0);
    }
    void TakeDownBar()
    {
        if (!Input.GetKeyDown(KeyCode.E))
        {
            tDonBarDecrease = tDownBarDecrease;
            tDownBar -= tDonBarDecrease * Time.deltaTime;

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            tDownBar += tDownBarIncrease;
        }
        tDownBar = Mathf.Clamp(tDownBar, 0, 100);
    }
    void Value()
    {
        if (slideer.activeSelf)
        {
            slider.value = tDownBar;
        }
        
    }
    void DecreaseIncrementation()
    {
        tDownBarDecrease = 75f;
        tDownBarIncrease = 25f;
    }
}
