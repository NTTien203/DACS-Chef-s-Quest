using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class GameInput : MonoBehaviour
{
    
    //singleton pattern
    // public static GameInput instance 
    //     { get; set; }
    // private void Awake(){
    //     if(instance!=null|| instance!=this){
    //         Destroy(this);
    //     }
    //     else instance=this;
    // }    
     PlayerInputSystem playerInputAction;
    private void Awake(){
     
        playerInputAction = new PlayerInputSystem();
        playerInputAction.Player.Enable();
    }
    //Get key input and return Vector
    public Vector2 getMovementVector(){
        Vector2 inputVector= playerInputAction.Player.Move.ReadValue<Vector2>();
       Debug.Log(playerInputAction.Player.Move.ReadValue<Vector2>());
        inputVector=inputVector.normalized;
        return inputVector;
    }
}
