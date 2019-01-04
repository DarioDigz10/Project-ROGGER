using UnityEngine;

public class RoketJump : MonoBehaviour
{
    Rigidbody pRBody;
    [SerializeField] float jumpSpeed;
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float delay = 0.2f;

    void Awake()
    {
        pRBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (GameManager.Instance.InputController.Jump)
        {
            GameManager.Instance.Timer.Add(() =>
            {
                pRBody.velocity = Vector3.up * jumpSpeed;
            }, delay);
        }
    }

    private void FixedUpdate()
    {
        if (pRBody.velocity.y < 0)
        {
            pRBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

}
