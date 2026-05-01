using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float laneDistance = 3f; // Distance between lanes
    [SerializeField] private float laneChangeSpeed = 10f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] public bool onGround;
    [SerializeField] private bool isSliding;
    [SerializeField] private Animator animator;
    private bool isChangingLane;
    private Rigidbody rb;
    private PlayerCollision playerCollision;
    private float slideDuration = 1f;
    private Vector3 originalSize;
    private Vector3 slideSize;
    private BoxCollider boxCollider;
    private float slideTimer;
    private Vector3 originalCenter;
    private Vector3 slideCenter;

    public int currentLane = 1; // 0 = Left, 1 = Middle, 2 = Right
    private Vector3 targetPosition;

    private void Awake()
    {
        playerCollision = GetComponent<PlayerCollision>();
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        originalSize = boxCollider.size;
        originalCenter = boxCollider.center;
        slideCenter = new Vector3(originalCenter.x, originalCenter.y * 0.5f, originalCenter.z);
        slideSize = new Vector3(boxCollider.size.x, boxCollider.size.y * 0.5f, boxCollider.size.z);
        
    }
    void Update()
    {
        
        onGround = playerCollision.onGround;
        HandleSlideTimer();
        if(onGround)
        {
            animator.SetBool("Jump", false);
        }
        else { animator.SetBool("Jump", true); }
        Debug.Log("velocity y : "+rb.linearVelocity.y);
        
    }
    public void PlayerMove()
    {
        if (onGround && !isSliding)
        {
            targetPosition = new Vector3((currentLane - 1) * laneDistance, rb.position.y, rb.position.z);
            rb.position = Vector3.Lerp(rb.position, targetPosition, laneChangeSpeed * Time.deltaTime);
            float distance = Mathf.Abs(rb.position.x - targetPosition.x);
            isChangingLane = distance > 0.05f;
            Debug.Log("move working");
        }
           
    }
    public void PlayerJump()
    {
        if (onGround && !isSliding)
        {
            //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            playerCollision.onGround = false;
            EventManager.Instance.Jump();
        }
    }
    public void Slide()
    {
        if (!playerCollision.onGround || isSliding || isChangingLane)
            return;

            isSliding = true;
            slideTimer = slideDuration;

            boxCollider.size = slideSize;
            boxCollider.center = slideCenter;
        animator.SetBool("Slide", true);
        EventManager.Instance.Slide();

    }
    private void HandleSlideTimer()
    {
        if (!isSliding) return;

        slideTimer -= Time.deltaTime;

        if (slideTimer <= 0f)
        {
            StopSlide();
        }
    }
    void StopSlide()
    {
        isSliding = false;

        boxCollider.size = originalSize;
        boxCollider.center = originalCenter;
        animator.SetBool("Slide", false);
    }
    public void TestMethod()
    {
        Debug.Log("testing method working");
    }
}
