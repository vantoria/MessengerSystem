using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float clipSize;
    public GameObject shootingPoint;

    //movement
    Rigidbody rb;
    Camera mainCam;
    public float jumpHeight, moveSpeed;


    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        mainCam = GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 playerMove = new Vector3(moveHor, 0f, moveVer);

        rb.AddForce(playerMove * moveSpeed);


    }

    // Update is called once per frame
    void Update() {

    }

    void shoot(float clipSize)
    {

    }
}
