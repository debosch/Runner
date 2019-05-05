using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundPoint;
    [SerializeField] private float jumpForce;

    private readonly float groundCheckRadius = 0.2f; 

    private Animator animator;
    private Rigidbody2D rb2D;

    private bool isGrounded;
   
   private void Start()
    { 
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, groundCheckRadius, groundMask);

        LayerHolder();
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
            Jump();
    }

    private void Jump()
    {
        rb2D.AddForce(Vector2.up * jumpForce);
        animator.SetTrigger("Jump");
    }

  
    private void HorizontalMovement()
    {

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
