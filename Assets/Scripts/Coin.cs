using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coins;

    public CapsuleCollider col;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Coin") {
            Debug.Log("coin got");
            coins += 1;
            col.gameObject.SetActive(false);
        }
    }
}
