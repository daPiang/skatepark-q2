using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2 : MonoBehaviour
{
    public GameObject button;

    // Update is called once per frame
    void Update()
    {
        if(button.GetComponent<Button>().animator.GetBool("buttonUsed")) {
            if(!GetComponent<LevelManager>().solved) {
                GetComponent<LevelManager>().ySolved();
            }
        }
    }
}
