using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float jumpForce = 300f;
    public float moveForce = 5f;
    Rigidbody rb;
    bool canJump = false;
    bool hasSwitchedLayers = false;
    Vector3 startPos;
    bool isJumpBlocked = false;
    bool isSwitchBlocked = false;

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A)) rb.velocity = new Vector3(-moveForce, rb.velocity.y, 0);
        if(Input.GetKey(KeyCode.D)) rb.velocity = new Vector3(moveForce, rb.velocity.y, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canJump && !isJumpBlocked)
        {
            canJump = false;
            rb.AddForce(0, jumpForce, 0);
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && !isSwitchBlocked) SwitchLayers();
        if(transform.position.y < -5) transform.position = startPos;
    }

    void SwitchLayers()
    {
        if(hasSwitchedLayers) transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        else transform.position = new Vector3(transform.position.x, transform.position.y, 10);
        hasSwitchedLayers = !hasSwitchedLayers;
    }

    void OnCollisionEnter(Collision other)
    {
        canJump = true;
        if(other.gameObject.tag == "Trap") transform.position = startPos;
        if(other.gameObject.tag == "Bouncy") rb.AddForce(0f, jumpForce * 1f, 0f);
        if(other.gameObject.tag == "Sticky") isJumpBlocked = true;
        if(other.gameObject.tag == "AntiSwitch") isSwitchBlocked = true;
        if(other.gameObject.tag == "LayerSwitcher") SwitchLayers();
        if(other.gameObject.tag == "Checkpoint") startPos = other.gameObject.transform.position + Vector3.up;
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Sticky") isJumpBlocked = false;
        if(other.gameObject.tag == "AntiSwitch") isSwitchBlocked = false;
    }
}
