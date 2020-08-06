using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorShredder : MonoBehaviour {
    [SerializeField] bool left;
    Game myGame;
    private void Start() {
        myGame = FindObjectOfType<Game>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("ActiveCollider")) {
            if (left) {
                if (other.transform.parent.gameObject.CompareTag("Left")) {
                    myGame.CorrectLeft();
                }
                else {
                    myGame.FalseLeft();
                }
            }
            else {
                if (other.transform.parent.gameObject.CompareTag("Right")) {
                    myGame.CorrectRight();
                }
                else {
                    myGame.FalseRight();
                }
            }
            Destroy(other.transform.parent.gameObject);
        }
    }

}
