﻿using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour
{
    [System.Serializable]
    public class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Sensitivity;
    }

    [SerializeField]float speed;
    [SerializeField]MouseInput MouseControl;

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

    public GunController gun;

    private void Awake()
    {
        GameManager.Instance.Player = this;
        playerInput = GameManager.Instance.InputController;
    }

    private void Update()
    {
        //MOVEMENT:
        Vector2 direction = new Vector2(playerInput.Vertical * speed, playerInput.Horizontal * speed);
        MoveController.Move(direction);
        //GUN CONTROLLER:
        if (playerInput.mLeftClicked) gun.isFiring = true;
        if (playerInput.mLeftUp) gun.isFiring = false;

    }
}
