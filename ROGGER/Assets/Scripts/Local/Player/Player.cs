﻿using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] float speed;
    InputController playerInput;

    private MoveController m_moveController;
    public MoveController MoveController
    {
        get
        {
            if (m_moveController == null) m_moveController = GetComponent<MoveController>();
            return m_moveController;
        }
    }
    [Header("Rocket Jump variables")]
    [SerializeField] float jumpForce;
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float delay = 0.2f;
    [SerializeField] float explsionRadius = 5f;
    [SerializeField] float explsionForce = 700f;

    public GameObject explosionEffect;

    bool jumpRequest = false;
    bool jumping = false;

    private Rigidbody pRBody;
    private ShakeCamera shake;

    private void Awake()
    {
        GameManager.Instance.Player = this;
        playerInput = GameManager.Instance.InputController;
        pRBody = GetComponent<Rigidbody>();
        shake = Camera.main.GetComponent<ShakeCamera>();
    }

    void Update()
    {
        if (GameManager.Instance.InputController.Jump && !jumping)
        {
            jumpRequest = true;
            shake.Shake2();
        }
    }

    private void FixedUpdate()
    {
        //MOVEMENT:
        Vector2 direction = new Vector2(playerInput.Vertical * speed, playerInput.Horizontal * speed);
        MoveController.Move(direction);
        //LOOK AT:
        Ray cameraRay = Camera.main.ScreenPointToRay(playerInput.mousePosition);
        Plane ground = new Plane(Vector3.up, transform.position);
        float rayLength;
        if (ground.Raycast(cameraRay, out rayLength))//If the ray comming from the camera hits something
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength); //Get the intersection point
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
        //JUMP:
        if (jumpRequest && !jumping)
        {
            jumping = true;
            GameManager.Instance.Timer.Add(() =>
            {
                pRBody.velocity = Vector3.up * jumpForce;
                Explode();
            }, delay);
        }
        if (pRBody.velocity.y < 0)
        {
            pRBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision any)
    {
        jumpRequest = false;
        jumping = false;
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, explsionRadius);
        foreach (Collider nearObj in colliders)
        {
            Rigidbody rb = nearObj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explsionForce, transform.position, explsionRadius);
            }
        }
    }
}
