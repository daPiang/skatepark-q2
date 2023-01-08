using UnityEngine;

public class LevelManager : MonoBehaviour {
    
    [SerializeField]
    public bool solved;
    public GameObject portal;

    private void Start() {
        FindObjectOfType<AudioManager>().Stop("Door");
    }

    private void Update() {
        if(solved) {
            portal.SendMessage("setActive");
        } else {
            portal.SendMessage("disablePortal");
        }
    }

    public void nSolved() {
        solved = false;
    }

    public void ySolved() {
        solved = true;
        FindObjectOfType<AudioManager>().Play("Door");
    }

}
