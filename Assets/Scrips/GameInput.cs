using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class GameInput : MonoBehaviour
{
    
    public event EventHandler OnInteractAction;
    public event EventHandler OnAlternateInteractAction;
     PlayerInputSystem playerInputAction;
    private void Awake(){
     //create a new PlayerInputSystem
        playerInputAction = new PlayerInputSystem();
        playerInputAction.Player.Enable();
        playerInputAction.Player.Interact.performed+=Interact_performed;
        playerInputAction.Player.AlternateInteract.performed+=AlternateInteract_alternate;
    }

    private void AlternateInteract_alternate(InputAction.CallbackContext context)
    {
        OnAlternateInteractAction?.Invoke(this,EventArgs.Empty);
    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
       
       OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    //Get key input and return Vector

    public Vector2 getMovementVector(){
        //get Input value by Vector2
        Vector2 inputVector= playerInputAction.Player.Move.ReadValue<Vector2>();
        inputVector=inputVector.normalized;
        return inputVector;
    }
}
