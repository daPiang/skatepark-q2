using UnityEngine;

public class Button : MonoBehaviour
{
    public Animator animator;
    public GameObject levelmgr;

    public void useButton() {
        if(!animator.GetBool("buttonUsed")) {
            FindObjectOfType<AudioManager>().Play("Button");
        }
        
        animator.SetBool("buttonUsed", true);
    }

    private void Update() {
        // if(animator.GetBool("buttonUsed")) {
        //     Debug.Log("Button Pressed");
        // }
    }

    private void OnCollisionEnter(Collision other) {
        if(gameObject.tag == "pressure") {
            if(other.gameObject.tag == "Player") {
                useButton();
            }
        }
    }
}
