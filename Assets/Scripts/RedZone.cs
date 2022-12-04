using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZone : MonoBehaviour
{   
    public Rigidbody player;
    public float force = 1000f;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player") {
            Debug.Log("Ouch!");
            player.AddForce(0,force,0);
        }
    }
}
