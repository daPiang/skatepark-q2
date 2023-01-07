using UnityEngine;

public class Coin : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider col) {
        // if(col.gameObject.tag == "Coin") {
        //     // col.gameObject.SetActive(false);
        //     Destroy(col.gameObject);
        // }
    }
}
