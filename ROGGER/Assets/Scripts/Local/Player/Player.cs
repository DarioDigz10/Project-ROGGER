using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour
{
    [SerializeField]float speed;

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
        //LOOK AT:
        Ray cameraRay = Camera.main.ScreenPointToRay(playerInput.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if(ground.Raycast(cameraRay, out rayLength))//If the ray comming from the camera hits something
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength); //Get the intersection point
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
        
    }
}
