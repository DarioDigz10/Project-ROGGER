using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    [SerializeField] float timeToDespawn = 1f;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.Timer.Add(() =>
        {
            Destroy(gameObject);
        }, timeToDespawn);
    }
}
