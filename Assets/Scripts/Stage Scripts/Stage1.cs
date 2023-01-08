using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1 : MonoBehaviour
{
    public GameObject coin;
    public List<GameObject> coinPos;
    private int x = 0;
    void Start()
    {
        InvokeRepeating("moveCoin", 1.6f, 1.6f);
    }

    private void moveCoin() {
        x++;
        if(x == 5) {
            x = 0;
        }
        coin.transform.position = coinPos[x].transform.position;
    }
    
    private void Update() {
        if(coin == null) {
            CancelInvoke();
            if(!GetComponent<LevelManager>().solved) {
                GetComponent<LevelManager>().ySolved();
            }
        }
    }
}
