using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public Animator camAnim;
    public void Shake1()
    {
        camAnim.SetTrigger("Shake");
    }

    public void Shake2()
    {
        camAnim.SetTrigger("Shake_RJ");
    }
}
