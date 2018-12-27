using UnityEngine;

public class InputController : MonoBehaviour
{
    public float Vertical;
    public float Horizontal;
    //MOUSE:
    public Vector3 mousePosition;
    public bool mLeftClicked;
    public bool mLeftUp;

    public void Update()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        mousePosition = Input.mousePosition;
        mLeftClicked = Input.GetMouseButtonDown(0);
        mLeftUp = Input.GetMouseButtonUp(0);
    }
}
