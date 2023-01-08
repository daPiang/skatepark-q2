using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

    public bool isActive = false;
    public Material inactiveMaterial;
    public Material activeMaterial;
    public Rigidbody player;
    public string level;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player" && isActive) {
            SceneManager.LoadScene(level, LoadSceneMode.Single);
        }
    }

    public void setActive() {
        isActive = true;
    }

    public void disablePortal() {
        isActive = false;
    }

    private void Update() {
        if(isActive) {
            this.GetComponent<MeshRenderer>().material = activeMaterial;
        } else {
            this.GetComponent<MeshRenderer>().material = inactiveMaterial;
        }
    }
}
