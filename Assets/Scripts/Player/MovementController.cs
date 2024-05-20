using UnityEngine;

public class MovementController : MonoBehaviour
{
    #region Variables
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravity; 
    [SerializeField] private float speed;
    [SerializeField] private float speedMultiplier;
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController cc;
    private float verticalAxis;
    private float horizontalAxis;
    private Vector3 jump;
    private Vector3 movement;
    private IPlayerMovementControler iPlayerMovementControler;
    #endregion

    #region Methods

    void Start()
    {
        iPlayerMovementControler = GetComponent<IPlayerMovementControler>();
    }

    private void Update()
    {
        Jump();   
    }

    public void Crouch()
    {
        iPlayerMovementControler.IsCroushed = !animator.GetBool("CrouchBool");
        animator.SetBool("CrouchBool", iPlayerMovementControler.IsCroushed);        
    }

    public void Jump()
    {
        if (jump.y < -1 && cc.isGrounded) jump.y = -1;

        if (Input.GetKeyDown(KeyCode.Space) && cc.isGrounded) jump.y = jumpHeight;

        jump.y -= gravity * Time.deltaTime;

        cc.Move(jump * Time.deltaTime);
    }

    public void Move(bool isRunning)
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
        movement = Vector3.zero;        
        movement = horizontalAxis * transform.right + verticalAxis * transform.forward;

        movement.Normalize();

        if (iPlayerMovementControler.IsCroushed)
        {
            movement *= 0.9f;
        }
        else
        {
            movement += isRunning ? UpVelocity() : DownVelocity();
        }
        
        movement.y = jump.y;
        cc.Move(movement * Time.deltaTime);
    }

    public Vector3 UpVelocity()
    {              
        return movement *= speed * speedMultiplier;        
    }

    public Vector3 DownVelocity()
    {
        return movement *= speed;
    }
    #endregion
}
