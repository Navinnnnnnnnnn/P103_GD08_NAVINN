using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//abstract members can't be used directly
//we inherit from them and implement them

public abstract class InputComponentBase : MonoBehaviour
{
    public abstract Vector2 GetInputDirection();
    public abstract Vector2 GetInputDirectionNormalized();
}

public class PlayerInputComponent : InputComponentBase
{
    private PlayerActions playerActions;
    public Animator animator;
    //private Vector2 inputDirection;
    private void Awake()
    {
        playerActions = new PlayerActions();
        playerActions.PlayerInput.Enable();
    }
    // Start is called before the first frame update
    void Start()
    {
        //rigidbody = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        //inputDirection = Vector2.zero;
        //if (Input.GetKey(KeyCode.W))
        //{
        //    //transform.position += new Vector3(1, 0, 0);
        //    inputDirection.y += 1;
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    //transform.position -= new Vector3(1, 0, 0);
        //    inputDirection.y -= 1;
        //}
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    //transform.position += new Vector3(0,0, 1);\
        //    inputDirection.x -= 1;
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    //transform.position -= new Vector3(0, 0, 1);
        //    inputDirection.x += 1;
        //}
        ////transform.position += new Vector3(inputDirection.x, 0, inputDirection.y);

        
    }

    public override Vector2 GetInputDirection()
    {
        return playerActions.PlayerInput.Movement.ReadValue<Vector2>();
    }

    public override Vector2 GetInputDirectionNormalized()
    {
        return GetInputDirection().normalized;
    }


}

