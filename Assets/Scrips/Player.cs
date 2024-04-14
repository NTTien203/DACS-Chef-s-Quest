using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //sigleton pattern
    // public static Player instance 
    //      { get; set; }
    // private void Awake(){
    //     if(instance!=null|| instance!=this){
    //         Destroy(this);
    //     }
    //     else instance=this;  
    // }   
    public float moveSpeed;
    [SerializeField] GameInput gameInput;
    [SerializeField]LayerMask counterLayerMask;
    ClearCounter selectedCounter;
    
    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;

    public class OnSelectedCounterChangedEventArgs : EventArgs{
        public ClearCounter selectedCounter;
    }
    void Start()
    {
        gameInput.OnInteractAction +=GameInput_OnInteractAction;
    }
    //Game Interact Action : E
    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        if(selectedCounter!=null){
            selectedCounter.Interact();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        movementHandle();
        interractHanddle();
    }
    //Movement Player
    void movementHandle(){
         float rotateSpeed=10f;
         float playerRadius=.7f;
         float moveDistance=0.1f;
        //Moving
        Vector2 inputVector=gameInput.getMovementVector();
        Vector3 moveDir= new Vector3(inputVector.x,0,inputVector.y);
        inputVector=inputVector.normalized;
       bool canMove=!Physics.CapsuleCast(transform.position,transform.position+Vector3.up,playerRadius,moveDir,moveDistance);
       if(canMove){
           transform.position+=moveDir*moveSpeed*Time.deltaTime;
        }
         //rotate Player;
        transform.forward=Vector3.Slerp(transform.forward,moveDir,Time.deltaTime*rotateSpeed);
        
    }
    //Interact obj method
    void interractHanddle(){
       float interactDistance=2f;
        Vector3 lastInterract= new Vector3();
        Vector2 inputVector=gameInput.getMovementVector();
        Vector3 moveDir= new Vector3(inputVector.x,0,inputVector.y);
        if(moveDir!=Vector3.zero){
            lastInterract=moveDir;
        }
       if(Physics.Raycast(transform.position,lastInterract,out RaycastHit raycastHit,interactDistance,counterLayerMask)){
            if(raycastHit.transform.TryGetComponent(out ClearCounter clearCounter)){
                if(selectedCounter!=clearCounter){
                    setSelectedCounter(selectedCounter);
                }
            }else
            {
                setSelectedCounter(null);
            }
       }else{
        setSelectedCounter(null);
       }
    }
//Chosing the Counter 
    private void setSelectedCounter(ClearCounter selectedCounter){
        this.selectedCounter=selectedCounter;
        OnSelectedCounterChanged?.Invoke(this,new OnSelectedCounterChangedEventArgs{
            selectedCounter=selectedCounter,
        });
    }

    
}
