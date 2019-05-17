using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundPoint;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float jumpForce;
    [SerializeField] private float horizontalMovementSpeed;

    private readonly float groundCheckRadius = 0.3f;
    private readonly float lowJumpMultiplier = 1.8f;

    private Animator animator;
    private Rigidbody2D rb;

    private bool isGrounded;
   
   private void Start()
    { 
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        transform.position = spawnPoint.position;
    }

    private void Update()
    {
        HandleInput();
        LayerHolder();
    }

    private void FixedUpdate()
    {
        HorizontalMovement();

        isGrounded = Physics2D.OverlapCircle(groundPoint.position, groundCheckRadius, groundMask);

        rb.gravityScale = 4;

        if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            rb.gravityScale *= lowJumpMultiplier;
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
        animator.SetTrigger("Jump");
    }

  
    private void HorizontalMovement()
    {
        rb.velocity = new Vector2(horizontalMovementSpeed * Time.deltaTime, rb.velocity.y);
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)    
            Jump();
        
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            horizontalMovementSpeed *= 1.5f;
            animator.SetBool("Running", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            horizontalMovementSpeed /= 1.5f;
            animator.SetBool("Running", false);
        }
    }

    private void LayerHolder()
    {
        if (!isGrounded)
        {
            animator.SetLayerWeight(1, 1);
            animator.SetLayerWeight(0, 0);
        }
        else
        {
            animator.SetLayerWeight(0, 1);
            animator.SetLayerWeight(1, 0);
        }
            
    }
}
