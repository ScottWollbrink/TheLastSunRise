using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;

    [SerializeField] Animator animator;

    [SerializeField] float jumpforce;
    [SerializeField] float speed;
    [SerializeField] float hp;

    private float currentHP;

    [SerializeField] Transform groundedPOS;
    [SerializeField] LayerMask ground;

    [SerializeField] float attackDmg;
    [SerializeField] float attackSpeed;

    [SerializeField] Rigidbody2D ridgidbody;

    private float horizontal;
    private bool facingRight;
    private bool grounded;
    private bool canJump = true;
    private bool isPlayingFootsteps = false;

    // Start is called before the first frame update
    void Awake()
    {
        currentHP = hp;
        ridgidbody = GetComponent<Rigidbody2D>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (ridgidbody.velocity.x != 0 && !isPlayingFootsteps && grounded)
        {
            isPlayingFootsteps = true;
            
            audioManager.Play("Footsteps");
        }
        else if (ridgidbody.velocity.x == 0 || !grounded)
        {
           isPlayingFootsteps = false;
           audioManager.StopPlaying("Footsteps");
        }

        animator.SetFloat("speed", Mathf.Abs(horizontal));

        if (Input.GetButtonDown("Jump") && canJump)
        {
            ridgidbody.velocity = new Vector2(ridgidbody.velocity.x, jumpforce);
            animator.SetBool("isJumping", true);
            audioManager.Play("Jump");
            canJump = false;
        }
    }

    private void FixedUpdate()
    {
        
        ridgidbody.velocity = new Vector2(horizontal * speed, ridgidbody.velocity.y);

        // if moving right and not facing right flip
        if(horizontal < 0 && !facingRight)
        {
            flipdirection();
        }
        // if moving left and facing right flip
        else if(horizontal > 0 && facingRight)
        {
            flipdirection();
        }

        bool wasGrounded = grounded;
        grounded = false;

        Collider2D[] groundCollider = Physics2D.OverlapCircleAll(groundedPOS.position, 0.4f, ground);
        
        for(int i = 0; i < groundCollider.Length; i++)
        {
            if (groundCollider[i].gameObject != gameObject)
            {
                grounded = true;
                if (!wasGrounded)
                {
                        audioManager.Play("Landing");
                    
                    animator.SetBool("isJumping", false);
                    canJump = true;
                }
            }
        }
    }
    private void flipdirection()
    {
        //filp x scale so that sprit faces the other direction
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }


}
