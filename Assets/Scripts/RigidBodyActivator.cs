using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyActivator : MonoBehaviour
{
    [SerializeField] bool isEndLine;
    private void OnTriggerEnter(Collider other) {
        other.gameObject.GetComponentInParent<Rigidbody>().isKinematic = false;
        if (isEndLine) {
            other.gameObject.layer = 8;
            other.gameObject.transform.parent.gameObject.layer = 8;
        }
    }

}
