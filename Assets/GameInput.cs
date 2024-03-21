using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameInput : MonoBehaviour
{
    //singleton pattern
    public static GameInput instance 
        { get; set; }
    private void Awake(){
        if(instance!=null|| instance!=this){
            Destroy(this);
        }
        else instance=this;
    }    
    //Get key input and return Vector
    public Vector2 getMovementVector(){
        Vector2 inputVector= new Vector2(0,0);
        if(Input.GetKey(KeyCode.W)){
            inputVector.y+=1;
        }
        if(Input.GetKey(KeyCode.S)){
             inputVector.y-=1;
        }
         if(Input.GetKey(KeyCode.A)){
             inputVector.x-=1;
        }
         if(Input.GetKey(KeyCode.D)){
             inputVector.x+=1;
        }
        inputVector=inputVector.normalized;
        return inputVector;
    }
}
