using UnityEngine;

public class CameraController : MonoBehaviour
{
    //[SerializeField] Player player;
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float smoothSpeed = 12.5f;

    void Awake() {
        GameManager.Instance.OnPlayerJoined += HandleOnPlayerJoined;
    }

    private void HandleOnPlayerJoined(Player player) {
        //this.player = player;
        transform.LookAt(player.transform);
        target = player.transform;
    }

    void FixedUpdate() {
        Vector3 finalPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, finalPos, smoothSpeed * Time.deltaTime);
    }
}
