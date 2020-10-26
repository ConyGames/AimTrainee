using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody PlayerRigidBody;

    public AudioSource mainMusic;
    public bool SlowOnJump = true;

    [Header("Player Actions")]
        public bool Jumping = false;
        public bool CanJump = true; // Variable to determine if we shpould concider the player movement or not
        public bool Running = false;
    
    [Header("Forces")]
        [SerializeField] private float MovementForce = 0;
        [SerializeField] private float RunningSpeed = 0;
        [SerializeField] private float jumpForce = 0;
        private Vector3 HorizontalForce;
        private Vector3 VerticalForce;

    [Header("Scripts")]
        private PlayerAnimation playerAnimation;
        
        private float HorizontalMovement = 0;
        private float VerticalMovement = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PlayerRigidBody = this.gameObject.GetComponent<Rigidbody>();
        mainMusic = GameObject.Find("GameManager").GetComponent<AudioSource>();
        playerAnimation = gameObject.GetComponent<PlayerAnimation>();
    }

    void FixedUpdate()
    {
        RegisterMovements();
        CalCulateMoveMentForce();
        MovePlayer();
        JumpPlayer();
    }

    private void RegisterMovements(){
        HorizontalMovement = Input.GetAxis("Horizontal");
        VerticalMovement = Input.GetAxis("Vertical");
        Jumping = Input.GetKeyDown(KeyCode.Space);// Input.GetAxis("Jump");
    }

    private void CalCulateMoveMentForce(){
        HorizontalForce = Vector3.zero;
        VerticalForce = Vector3.zero;

        if (HorizontalMovement == 0 && VerticalMovement == 0 && !Jumping){
            playerAnimation.PlayerWalk(false);
            return;
        }
            
        playerAnimation.PlayerWalk(true);
        HorizontalForce = HorizontalMovement * transform.right;
        VerticalForce = VerticalMovement * transform.forward;
    }
    void MovePlayer(){

        if (HorizontalMovement == 0 && VerticalMovement == 0)
            return;

        if (Input.GetKey(KeyCode.LeftShift) && CanJump){
            if (!Running){
                Running = true;
                playerAnimation.PlayerRun(Running);
            }            
            transform.position += VerticalForce * Time.deltaTime * RunningSpeed;
            transform.position += HorizontalForce  * Time.deltaTime * MovementForce;
        }
        else {
            if (Running){
                Running = false;
                playerAnimation.PlayerRun(Running);
            }
            transform.position += (HorizontalForce + VerticalForce) * Time.deltaTime * MovementForce;
        }
    }

    void JumpPlayer(){
        if ( Jumping == false || CanJump == false){
            return;
        }
        if (SlowOnJump) 
            mainMusic.pitch = Time.timeScale = 0.6f;

        playerAnimation.PlayerJump(Jumping);
        if (Running){
            PlayerRigidBody.AddForce(transform.up * jumpForce * RunningSpeed, ForceMode.Acceleration);
            PlayerRigidBody.AddForce((HorizontalForce + VerticalForce) * jumpForce * RunningSpeed, ForceMode.Acceleration);
        }else {
            PlayerRigidBody.AddForce(transform.up * jumpForce * MovementForce, ForceMode.Acceleration);
            PlayerRigidBody.AddForce((HorizontalForce + VerticalForce) * jumpForce * MovementForce, ForceMode.Acceleration);
        }
        
    }

    private void RotateLocalPlayer(){
        transform.rotation = Camera.main.transform.rotation;
    }
}
