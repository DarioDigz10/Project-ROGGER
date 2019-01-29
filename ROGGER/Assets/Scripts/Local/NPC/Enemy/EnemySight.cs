using System.Collections;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    [Header("Sight Parameters")]
    public float viewRadius;
    public float tooCloseRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    [HideInInspector] public Transform playerVisible;
    [HideInInspector] public Animator animator;

    private void Start() {
        StartCoroutine("FindtargetsWithDelay", .2f);
        animator = gameObject.GetComponent<Animator>();
    }

    IEnumerator FindtargetsWithDelay(float delay) {
        while (true) {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets() {
        if (animator.GetBool("player seen") == true) return;
        playerVisible = null;
        //Comprueba todo lo que entra en el radio exterior:
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        foreach (Collider collider in targetsInViewRadius) {
            Transform target = collider.transform;
            //Si el jugador está em el circulo interior el enemigo se gira:
            if (Vector3.Distance(target.position, transform.position) < tooCloseRadius && target.gameObject.CompareTag("Player")) {
                animator.SetBool("player seen", true);
            }
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            //Si el jugador entra en el cono de vision: 
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2) {
                float distToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, obstacleMask) && Physics.Raycast(transform.position, dirToTarget, distToTarget, targetMask)) {
                    playerVisible = target;
                    animator.SetBool("player seen", true);
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
