using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private LayerMask coinLayer;
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundDistance =0.7f;
    [SerializeField] private Transform groundPos;
    private Rigidbody rb;
    private bool isGameOver = false;
    public bool onGround;
    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        onGround = Physics.CheckSphere(groundPos.position, groundDistance, groundLayer);
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((coinLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            EventManager.Instance.CoinCollect();
            Coin coin = other.GetComponent<Coin>();
            coin.CollectAnimationTrigger();
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(!isGameOver)
        {
            if ((obstacleLayer.value & (1 << collision.gameObject.layer)) > 0)
            {
                Debug.Log("Game Over");
                EventManager.Instance.GameOver();
                isGameOver = true;
                rb.isKinematic = true;
                
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (groundPos == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundPos.position, groundDistance);
    }

}
