using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float moveSpeed;
    [SerializeField] GameInput gameInput;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      movementHandle();
        interractHanddle();
    }

    void movementHandle(){
         float rotateSpeed=10f;
         float playerRadius=.7f;
         float moveDistance=0.1f;
        //Moving
        Vector2 inputVector=gameInput.getMovementVector();
        Vector3 moveDir= new Vector3(inputVector.x,0,inputVector.y);
        //transform.position+=moveDir*moveSpeed*Time.deltaTime;
        inputVector=inputVector.normalized;
       bool canMove=!Physics.CapsuleCast(transform.position,transform.position+Vector3.up,playerRadius,moveDir,moveDistance);
       if(canMove){
           transform.position+=moveDir*moveSpeed*Time.deltaTime;
        }
         //rotate Player;
        transform.forward=Vector3.Slerp(transform.forward,moveDir,Time.deltaTime*rotateSpeed);
        
    }
    void interractHanddle(){
       float interactDistance=2f;
        Vector3 lastInterract= new Vector3();
        Vector2 inputVector=gameInput.getMovementVector();
        Vector3 moveDir= new Vector3(inputVector.x,0,inputVector.y);
        if(moveDir!=Vector3.zero){
            lastInterract=moveDir;
        }
       if(Physics.Raycast(transform.position,lastInterract,out RaycastHit raycastHit,interactDistance)){
            if(raycastHit.transform.TryGetComponent(out ClearCounter clearCounter)){
                clearCounter.Interact();
            }
       }else{
            Debug.Log(".");
       }
    }
}
