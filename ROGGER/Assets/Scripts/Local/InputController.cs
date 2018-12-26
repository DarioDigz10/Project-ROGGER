using UnityEngine;

public class InputController : MonoBehaviour
{
    public float Vertical;
    public float Horizontal;
    //MOUSE:
    public Vector2 MouseInput;
    public bool mLeftClicked;
    public bool mLeftUp;

    public void Update()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mLeftClicked = Input.GetMouseButtonDown(0);
        mLeftUp = Input.GetMouseButtonUp(0);
    }
}
