using UnityEngine;

public class CargoLoss : MonoBehaviour
{
    public GameObject cargo;
    public GameObject player;
    

    private void Update()
    {

    }
    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AttackRange")&&player.GetComponent<PlayerItems>().cargoCount > 0 )
        {
            CargoSpawner();
        }
    }
    void CargoSpawner()
    {
        player.GetComponent<PlayerItems>().cargoCount--;
        GameObject cargoCopy = Instantiate(cargo,new Vector3(player.transform.position.x - Random.Range(-3,3),player.transform.position.y - Random.Range(-3,3),0),player.transform.rotation);
    }

}
