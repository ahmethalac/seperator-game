using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.transform.parent != null) {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
        else {
            Destroy(other);
        }
    }
}
