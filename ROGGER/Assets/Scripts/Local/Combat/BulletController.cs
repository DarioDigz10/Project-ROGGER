using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] public float speed = 10f;
    [SerializeField] public float timeToLive;
    [SerializeField] public float damage;

    private ShakeCamera shake;

    private void Start()
    {
        Destroy(gameObject, timeToLive);
        shake = Camera.main.GetComponent<ShakeCamera>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Destructible destructible = other.GetComponent<Destructible>();
        if (destructible != null)
        {
            print(other.name);
            destructible.takeDamage(damage);
            int rand = Random.Range(0, 9);
            if(rand > 2)  shake.Shake1();
        }
    }
}
