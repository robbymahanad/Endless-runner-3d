using System.Collections;
using UnityEngine;

public class Player1Script : MonoBehaviour
{
    [SerializeField] private GameObject[] bodyParts;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform[] children;

    private void Awake()
    { 
        children = GetComponentsInChildren<Transform>();
    }
    private void Update()
    {
        DoRagdoll();
    }
    private void DoRagdoll()
    {
        bodyParts = new GameObject[children.Length - 1]; // exclude Player itself
        int index = 0;

        foreach (Transform child in children)
        {
            if (child == transform) continue; // skip Player root

            Collider col = child.GetComponent<Collider>();
            Rigidbody rb = child.GetComponent<Rigidbody>();
            //CharacterJoint joint=child.GetComponent<CharacterJoint>();
            if (animator.enabled == true)
            {

                if (col != null)
                {
                    col.enabled = false;
                    rb.useGravity = false;
                    //joint.enableProjection = true;
                }
                if (rb != null)
                {

                    rb.useGravity = false;
                    rb.isKinematic = true;
                    //joint.enableProjection = true;
                }
            }
            if (animator.enabled == false)
            {

                if (col != null)
                {
                    col.enabled = true;
                    rb.useGravity = true;
                    //joint.enableProjection = true;
                }
                if (rb != null)
                {

                    rb.useGravity = true;
                    rb.isKinematic = false;
                    //joint.enableProjection = true;
                }
            }

            bodyParts[index] = child.gameObject;
            index++;
        }
    }
    
}
