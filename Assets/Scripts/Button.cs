using UnityEngine;

public class Button : MonoBehaviour
{
    public Animator animator;
    public GameObject levelmgr;

    public void useButton() {
        animator.SetBool("buttonUsed", true);
        if(levelmgr != null) {
            levelmgr.GetComponent<LevelManager>().toggleSolved();
        }
    }

    private void Update() {
        if(animator.GetBool("buttonUsed")) {
            Debug.Log("Button Pressed");
        }
    }
}
