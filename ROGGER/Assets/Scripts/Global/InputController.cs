using UnityEngine;

public class InputController : MonoBehaviour
{
    //MOVEMENT:
    public float Vertical;
    public float Horizontal;
    public bool Jump;
    //MOUSE:
    public Vector3 mousePosition;
    public bool mLeftClicked;
    public bool mLeftUp;
    public bool Fire;
    public bool MouseWheelUp;
    public bool MouseWheelDown;
    //ACTIONS:
    public bool Reload;
    //SPELLS:
    public bool MejorarArma;

    public void Update() {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        mousePosition = Input.mousePosition;
        mLeftClicked = Input.GetMouseButtonDown(0);
        mLeftUp = Input.GetMouseButtonUp(0);
        Fire = Input.GetButton("Fire1");
        Jump = Input.GetButtonDown("Jump");
        MejorarArma = Input.GetKeyDown(KeyCode.Q);
        Reload = Input.GetKey(KeyCode.R);
        MouseWheelUp = Input.GetAxis("Mouse ScrollWheel") > 0;
        MouseWheelDown = Input.GetAxis("Mouse ScrollWheel") < 0;
    }
}
