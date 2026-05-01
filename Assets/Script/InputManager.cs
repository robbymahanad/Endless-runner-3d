using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    [SerializeField] private PlayerMovement move;
    [SerializeField] private GameObject player;
    private float cooldown = 0.5f;
    private float lastPress;
    private Vector2 moveDir;
    private bool isPaused = false;
    private InputManager inputManager;


    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        inputManager = player.GetComponent<InputManager>();
        move = player.GetComponent<PlayerMovement>();
        input = new PlayerInput();
        lastPress = Time.time;

    }
    private void Update()
    {
        move.PlayerMove();
    }
    private void OnEnable()
    {
        input.Enable();
        
        input.Player.Jump.performed += Jump_performed;
        input.Player.Slide.performed += Slide_performed;
        input.Player.Left.performed += Left_performed;
        input.Player.Right.performed += Right_performed;
        input.Player.Jump.canceled += Jump_canceled;
        input.Player.Pause.performed += Pause_performed;
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!isPaused)
        {
            EventManager.Instance.Pause();
        }
        else { EventManager.Instance.Resume(); }
    }

    private void Jump_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        
    }

    private void Right_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(move.onGround)
        {
            if (move.currentLane < 2)
                move.currentLane++;
   
        }
        
    }

    private void Left_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (move.onGround)
        {

            if (move.currentLane > 0)
                move.currentLane--;
        }
    }

    private void Slide_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        move.Slide();
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (Time.time>lastPress)
        {
            move.PlayerJump();
            lastPress = Time.time + cooldown;
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;   // Freeze time
        isPaused = true;
        Debug.Log("is paused : " + isPaused);

    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;   // Resume time
        isPaused = false;
        Debug.Log("is paused : " + isPaused);

    }
    private void OnDisable()
    {
        input.Disable();
    }
}
