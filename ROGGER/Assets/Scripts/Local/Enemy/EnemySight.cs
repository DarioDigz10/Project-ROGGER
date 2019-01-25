using System.Collections;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    [Header("Sight Parameters")]
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    [HideInInspector] public Transform playerVisible;
    [HideInInspector] public Animator animator;

    private void Start() {
        StartCoroutine("FindtargetsWithDelay", .5f);
        animator = gameObject.GetComponent<Animator>();
    }

    IEnumerator FindtargetsWithDelay(float delay) {
        while (true) {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets() {
        playerVisible = null;
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        foreach (Collider collider in targetsInViewRadius) {
            Transform target = collider.transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2) {
                float distToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, obstacleMask) && Physics.Raycast(transform.position, dirToTarget, distToTarget, targetMask)) {
                    playerVisible = target;
                    animator.SetTrigger("player seen");
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal) {
        if (!angleIsGlobal) {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

}
