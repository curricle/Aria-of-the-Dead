using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Rigidbody2D enviro;
    private Transform playerTransform;
    private SpriteRenderer playerSprite;
    private Animator playerAnimator;
    private Vector2 moveInput;
    public bool isInputBlocked;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;    
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        playerSprite = GetComponent<SpriteRenderer>();
        isInputBlocked = true;
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enviro.linearVelocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context) {
        if(!isInputBlocked){
            if(enviro) {
                moveInput = context.ReadValue<Vector2>() * -1; 
                FlipPlayer();
                SetAnimState();
            }
            else {
                GetEnvironment();
            }
        }
    }

    void FlipPlayer() {
        if(moveInput.x > 0) {
            playerSprite.flipX = true;
        }
        if(moveInput.x < 0) {
           playerSprite.flipX = false;
        }
    }

    void SetAnimState() {
        var tempMoveX = moveInput.x;
        if(tempMoveX < 0) {
            tempMoveX *= -1;
        }
        playerAnimator.SetInteger("MoveX", (int)tempMoveX);
        playerAnimator.SetInteger("MoveY", (int)moveInput.y * -1);
    }

    void GetEnvironment() {
        enviro =  GameObject.FindWithTag("Environment").GetComponent<Rigidbody2D>();
        Debug.Log("Environment got!");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode) {
        GetEnvironment();
    }
}
