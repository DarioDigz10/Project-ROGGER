using UnityEngine;

public class E2_Stun : MonoBehaviour
{
    [SerializeField] Animator animator;
    void Start() {
        animator = GetComponentInParent<Animator>();
    }

    void Update() {
        //if (animator.GetBool("Hit") == false) return;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            animator.SetBool("Hit", true);
        }
    }
}
