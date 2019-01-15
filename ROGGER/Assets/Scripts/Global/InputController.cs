using UnityEngine;

public class InputController : MonoBehaviour
{
    public float Vertical;
    public float Horizontal;
    //MOUSE:
    public Vector3 mousePosition;
    public bool mLeftClicked;
    public bool mLeftUp;
    public bool FIre1;
    public bool MejorarArma;
    public bool Jump;
    public bool Reload;

    public void Update()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        mousePosition = Input.mousePosition;
        mLeftClicked = Input.GetMouseButtonDown(0);
        mLeftUp = Input.GetMouseButtonUp(0);
        FIre1 = Input.GetButton("Fire1");
        Jump = Input.GetButtonDown("Jump");
        MejorarArma = Input.GetKeyDown(KeyCode.Q);
        Reload = Input.GetKey(KeyCode.R);
    }
}
