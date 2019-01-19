using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] Animator animator;

    void Start() {
        animator = GetComponentInChildren<Animator>();
    }

    void Update() {
        animator.SetFloat("VerInput", GameManager.Instance.InputController.Vertical);
        animator.SetFloat("HorInput", GameManager.Instance.InputController.Horizontal);
    }
}
