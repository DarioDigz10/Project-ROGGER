using UnityEngine;

public class RoketJump : MonoBehaviour
{
    Rigidbody pRBody;
    [SerializeField] float jumpForce;
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float delay = 0.2f;

    bool jumpRequest = false;
    bool jumping = false;

    private ShakeCamera shake;

    void Awake()
    {
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
        if (jumpRequest && !jumping)
        {
            jumping = true;
            GameManager.Instance.Timer.Add(() =>
            {
                pRBody.velocity = Vector3.up * jumpForce;
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

}
