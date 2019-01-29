using UnityEngine;

public class Pointer : MonoBehaviour
{
	private Camera cam;
	private float height;
	private float width;

	private Vector3 dir;
	private float angle;

	public GameObject player;

    void Start()
    {
		cam = Camera.main;
		height = 2.0f * cam.orthographicSize;
		width = cam.aspect;
    }

    void FixedUpdate()
    {
		dir = player.transform.position - this.transform.position;
		angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
    }
}
