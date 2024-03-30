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
        //Moving
        Vector2 inputVector=gameInput.getMovementVector();
        Vector3 moveDir= new Vector3(inputVector.x,0,inputVector.y);
        transform.position+=moveDir*moveSpeed*Time.deltaTime;
       // Debug.Log(inputVector);
        //inputVector=inputVector.normalized;
        //rotate Player;
        float rotateSpeed=10f;
        transform.forward=Vector3.Slerp(transform.forward,moveDir,Time.deltaTime*rotateSpeed);
        
    }
}
