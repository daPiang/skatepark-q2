using UnityEngine;

public class LevelManager : MonoBehaviour {
    
    [SerializeField]
    public bool solved {get; private set;}
    public GameObject portal;

    private void Update() {
        if(solved) {
            portal.GetComponent<Portal>().setActive();
        }
    }

    public void toggleSolved() {
        solved = !solved;
    }

}
