using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 direction;
    private Vector3 targetPosition;
    public TextMeshProUGUI goldText;

    [SerializeField] private float forwardSpeed;
    private readonly float sideSpeed = 10f;
    private float speedLimit;

    private int desiredLane = 1;
    private readonly float laneDistance = 3.5f;

    private float jumpForce;
    private float gravity;
    private float acceleration;

    public static int gold;

    public Animator playerAnimator;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        forwardSpeed = 17f;
        speedLimit = 25f;
        jumpForce = 10.5f;
        gravity = -25f;
        acceleration = .1f;
        gold = 0;
        goldText.text = gold.ToString();
    }

    private void Update()
    {
        if (!GameManager.isGameStarted || GameManager.gameOver)
        {
            return;
        }

        goldText.text = gold.ToString();

        Move();

        if (GameManager.gameOver)
        {
            playerAnimator.SetBool("isGameOver", true);
            forwardSpeed = 0f;
        }

        playerAnimator.SetBool("isGameStarted", true);
        playerAnimator.SetBool("isGrounded", characterController.isGrounded);

        direction.z = forwardSpeed;
        
        if (characterController.isGrounded)
        {
            if (SwipeManager.swipeUp)
            {
                Jump();
            }
        } 
        else 
        {
            direction.y += gravity * Time.deltaTime;
        }
        
        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if(desiredLane == 3)
            {
                desiredLane = 2;
            }
        } 
        else if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if(desiredLane == -1)
            {
                desiredLane = 0;
            }
        }
        
        targetPosition = (transform.position.z * transform.forward) + (transform.position.y * transform.up);

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        } 
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, sideSpeed * Time.deltaTime);
        characterController.center = characterController.center;
        
    }

    private void Move()
    {
        characterController.Move(direction * Time.deltaTime);

        if (forwardSpeed < speedLimit)
        {
            forwardSpeed += acceleration * Time.deltaTime;
        }
    }

    private void Jump()
    {
        direction.y = jumpForce;
        FindObjectOfType<AudioManager>().PlaySound("Jump");
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(!GameManager.gameOver)
        {
            if (hit.transform.CompareTag("Obstacle"))
            {
                GameManager.gameOver = true;
                FindObjectOfType<AudioManager>().PlaySound("GameOver");
            }
        }
    }

    
}
