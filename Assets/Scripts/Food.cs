using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] float backSpeed;
    bool left;
    [SerializeField] float leftSpeed;

    private void Start() {
        GetComponent<Rigidbody>().isKinematic = true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position -= Vector3.right * backSpeed * Time.deltaTime;
        if (left) {
            transform.position -= Vector3.back * leftSpeed * Time.deltaTime;
        }
        else {
            transform.position -= Vector3.forward * leftSpeed * Time.deltaTime;
        }
    }
    public void BackVelocity(float speed) {
        backSpeed = speed;
    }

    public void LeftRightVelocity(float leftspeed, bool left) {
        leftSpeed = leftspeed;
        this.left = left;
    }

    private void OnDestroy() {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
