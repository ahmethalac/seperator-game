using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDeflector : MonoBehaviour
{
    [SerializeField] bool toLeft;
    [SerializeField] float power;
    private void OnCollisionEnter(UnityEngine.Collision collision) {
        if (toLeft) {
            collision.gameObject.GetComponentInParent<Food>().LeftRightVelocity(0.3f,true);
            collision.gameObject.GetComponentInParent<Rigidbody>().AddForce(new Vector3(-0.7f,0,1) * power,ForceMode.VelocityChange);
        }
        else {
            collision.gameObject.GetComponentInParent<Food>().LeftRightVelocity(0.3f,false);
            collision.gameObject.GetComponentInParent<Rigidbody>().AddForce(new Vector3(-0.7f,0,-1) * power,ForceMode.VelocityChange);
        }
    }
}
