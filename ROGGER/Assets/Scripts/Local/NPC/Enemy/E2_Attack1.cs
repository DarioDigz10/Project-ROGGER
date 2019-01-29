using UnityEngine;

public class E2_Attack1 : StateMachineBehaviour
{
    Vector3 playerSeenPos;
    public float attackSpeed;
    [SerializeField] GameObject weapon;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        playerSeenPos = GameManager.Instance.Player.transform.position;
        weapon = animator.transform.Find("Weapon").gameObject;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        weapon.transform.position = Vector3.MoveTowards(weapon.transform.position, playerSeenPos, attackSpeed * Time.deltaTime);
        if (Vector3.Distance(playerSeenPos, animator.transform.position) <= 1f) animator.SetBool("player seen", false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
