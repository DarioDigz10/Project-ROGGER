using UnityEngine;

public class E1_Attack1 : StateMachineBehaviour
{
    public GameObject explosionEffect;

    Vector3 playerSeenPos;
    float jumpAngle;
    float jumpSpeed;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        playerSeenPos = GameManager.Instance.Player.transform.position;
        animator.transform.LookAt(new Vector3(playerSeenPos.x, animator.transform.position.y, playerSeenPos.z));

        jumpAngle = Random.Range(10f, 85f);

        float distanceToPlayer = Vector3.Distance(animator.transform.position, playerSeenPos);
        jumpSpeed = Mathf.Sqrt(distanceToPlayer * Physics.gravity.magnitude / Mathf.Sin(2f * jumpAngle * Mathf.Deg2Rad));

        animator.GetComponent<Rigidbody>().velocity = Vector3.up * jumpSpeed;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, playerSeenPos, jumpSpeed * Time.deltaTime);
        if (Vector3.Distance(playerSeenPos, animator.transform.position) <= 1f) animator.SetBool("player seen", false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Instantiate(explosionEffect, animator.transform.position, animator.transform.rotation);
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
