using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField] Renderer bgRend;
    float bgSpeed;
    // Start is called before the first frame update
    void Start()
    {
        bgSpeed = FindObjectOfType<Game>().GetConveyorSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        bgRend.material.mainTextureOffset += new Vector2(bgSpeed * Time.deltaTime / 28f,0);
    }
}
