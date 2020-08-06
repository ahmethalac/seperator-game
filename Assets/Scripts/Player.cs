using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] [Range(1,10)] float speed;
    [SerializeField] Vector3 playerPosition;

    Game myGame;
    bool hold;
    Vector3 initialPlayerPosition;
    [SerializeField] Vector2 offset;
    [SerializeField] GameObject dwarf;

    // Start is called before the first frame update
    void Start() {
        hold = false;
        playerPosition = transform.position + Vector3.right * 2;
        myGame = FindObjectOfType<Game>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        ControlPlayerPosition();
        AdjustPlayerPosition();
        dwarf.gameObject.transform.position = playerPosition;
    }

    private void ControlPlayerPosition() {
        if (Input.GetMouseButtonDown(0)) {
            hold = true;
            offset.x = Input.mousePosition.x / Camera.main.scaledPixelWidth * speed;
            offset.y = Input.mousePosition.y / Camera.main.scaledPixelHeight * speed * 3;
            initialPlayerPosition = playerPosition;
        }
        else if (!Input.GetMouseButton(0)) {
            hold = false;
        }
        if (hold) {
            playerPosition.x = Mathf.Clamp(Input.mousePosition.y / Camera.main.scaledPixelHeight * speed * 3 - offset.y + initialPlayerPosition.x,-2f,myGame.GetStartPoint() - 10);
            playerPosition.z = Mathf.Clamp(initialPlayerPosition.z - Input.mousePosition.x / Camera.main.scaledPixelWidth * speed + offset.x,-3f,3f);
        }
        /*
        if (conveyorEffect) {
            playerPosition.x = Mathf.Clamp(( myJoystick.Vertical * speed - myConveyor.GetSpeed() ) * Time.deltaTime + playerPosition.x,-2f,myGame.GetStartPoint() - 10);
            playerPosition.z = Mathf.Clamp(playerPosition.z - myJoystick.Horizontal * speed * Time.deltaTime,-2.4f,2.4f);
        }
        else {
            playerPosition.x = Mathf.Clamp(myJoystick.Vertical * speed * Time.deltaTime + playerPosition.x,-2f,myGame.GetStartPoint() - 10);
            playerPosition.z = Mathf.Clamp(playerPosition.z - myJoystick.Horizontal * speed * Time.deltaTime,-2.4f,2.4f);
        }*/
    }

    private void AdjustPlayerPosition() {
        gameObject.transform.right = playerPosition - gameObject.transform.position;
        gameObject.transform.localScale = new Vector3(Vector3.Distance(gameObject.transform.position,playerPosition) / 2,1,1);
    }
}
