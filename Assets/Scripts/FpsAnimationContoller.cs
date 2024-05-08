using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsAnimationContoller : MonoBehaviour
{
    Animator anim;

    int xMove = Animator.StringToHash("xmove");
    int yMove = Animator.StringToHash("ymove");

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void playerAnimation(Vector2 m)
    {
        anim.SetFloat(xMove, m.x);
        anim.SetFloat(yMove, m.y);
    }
}
