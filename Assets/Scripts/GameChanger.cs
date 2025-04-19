using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class GameChanger : MonoBehaviour
{
    public GameObject gameObject;
    public Slider slider;
    public float stamina;
    private void Update()
    {
        stamina = gameObject.GetComponent<PlayerMovement>().stamina;
       
        slider.value = stamina;
    }

}
