using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerInputSystem inputsystem;

    private void Awake(){
        inputsystem= new PlayerInputSystem();
        inputsystem.Player.Enable();
    }

    public Vector2 getValue(){
        Vector2 inputVector = inputsystem.Player.Move.ReadValue<Vector2>();
            //Debug.Log(inputVector);
        return inputVector;
    }
}
