using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public float maxDistance;
    [SerializeField] float travelledDist;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        travelledDist += speed * Time.deltaTime;
        if (travelledDist >= maxDistance) Destroy(this.gameObject);
    }
}
