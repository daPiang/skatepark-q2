using UnityEngine;

public class Button : MonoBehaviour
{
    public Animator animator;

    public void useButton() {
        animator.SetBool("buttonUsed", true);
    }

    private void Update() {
        if(animator.GetBool("buttonUsed")) {
            Debug.Log("Button Pressed");
        }
    }
}
