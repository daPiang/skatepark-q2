using UnityEngine;

public class CoinObject : MonoBehaviour
{
    public float rotationSpeed = 5;
    
    private void Update()
    {
        transform.Rotate(10.0f * rotationSpeed * Time.deltaTime, 0.0f, 0.0f);
        // transform.
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            Destroy(gameObject);
        }
    }
}
