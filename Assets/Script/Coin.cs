using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void CollectAnimationTrigger()
    {
        animator.SetTrigger("Collect");
    }
}
