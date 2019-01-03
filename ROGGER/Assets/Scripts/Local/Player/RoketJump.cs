using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoketJump : MonoBehaviour
{
    Rigidbody playerRigidbody;
    [SerializeField] float jumpSpeed;
    [SerializeField] float fallMultiplier = 2.5f;

    [SerializeField] float delay = 0.2f;
    bool canJump = true;
    bool jumpRequest = false;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (GameManager.Instance.InputController.Jump && canJump)
        {
            canJump = false;
            jumpRequest = true;
        }
    }

    private void FixedUpdate()
    {
        if (jumpRequest)
        {
            jumpRequest = false;
            GameManager.Instance.Timer.Add(() =>
            {
                playerRigidbody.velocity = Vector3.up * jumpSpeed;
            }, delay);
        }
        if (playerRigidbody.velocity.y < 0)
        {
            playerRigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

}
