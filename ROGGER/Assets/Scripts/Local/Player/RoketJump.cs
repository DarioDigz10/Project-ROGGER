using UnityEngine;

public class RoketJump : MonoBehaviour
{
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
        foreach(Collider nearObj in colliders)
        {
            Rigidbody rb = nearObj.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(explsionForce, transform.position, explsionRadius);
            }
        }
    }

}
