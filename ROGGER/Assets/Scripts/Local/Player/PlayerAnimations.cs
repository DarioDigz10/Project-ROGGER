using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Player player;

    void Start() {
        animator = GetComponentInChildren<Animator>();
        player = GameManager.Instance.Player;
    }

    void Update() {
        animator.SetFloat("VerInput", GameManager.Instance.InputController.Vertical);
        animator.SetFloat("HorInput", GameManager.Instance.InputController.Horizontal);
        //CHECK DIRECTION:
        if (player.lookDir.Up) animator.SetBool("LookingUp", true);
        else animator.SetBool("LookingUp", false);
        if (player.lookDir.Right) animator.SetBool("LookingRight", true);
        else animator.SetBool("LookingRight", false);
        if (player.lookDir.Down) animator.SetBool("LookingDown", true);
        else animator.SetBool("LookingDown", false);
        if (player.lookDir.Left) animator.SetBool("LookingLeft", true);
        else animator.SetBool("LookingLeft", false);
    }
}
