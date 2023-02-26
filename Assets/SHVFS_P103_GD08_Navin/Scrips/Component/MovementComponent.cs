using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    
    [SerializeField]
    public InputComponentBase InputComponent;
    [SerializeField]
    private float movementSpeed = 5;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float playerWidth;
    [SerializeField]
    private float playerHeight;
   
    private float movementDistance => movementSpeed * Time.deltaTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

        //if (!(InputComponent.GetInputDirectionNormalized().magnitude > 0f)) return;

        //var movementDirection = new Vector3(InputComponent.GetInputDirectionNormalized().x, 0f, InputComponent.GetInputDirectionNormalized().y);
        //var targetLookRotation = Vector3.Slerp(transform.forward, movementDirection, Time.deltaTime * rotationSpeed);
        //transform.rotation = Quaternion.LookRotation(targetLookRotation, Vector3.up);
        //var canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerWidth, movementDirection, movementDistance);

        

        var movementDirection = new Vector3(InputComponent.GetInputDirectionNormalized().x, 0f, InputComponent.GetInputDirectionNormalized().y);
        var targetLookRotation = Vector3.Slerp(transform.forward, movementDirection, Time.deltaTime * rotationSpeed);
        transform.rotation = Quaternion.LookRotation(targetLookRotation, Vector3.up);


        if (TryMove(movementDirection)) return;

        if (TryMove(new Vector3(movementDirection.x, 0f, 0f).normalized)) return;

        TryMove(new Vector3(0f, 0f, movementDirection.z).normalized);



    }
    private bool TryMove(Vector3 direction)
    {
        var hits = Physics.CapsuleCastAll(transform.position, transform.position + Vector3.up * playerHeight, playerWidth, direction, movementDistance);

        if(hits.Length >= 1)
        {
            if (hits.All(hit => hit.transform.GetComponent<StructureComponent>() == null))
            {
                Move(direction);
                return true;

            }

            return false;

        }

        Move(direction);
        return true;
      
    }

    private void Move(Vector3 direction)
    {
        var targetPosition = transform.position + movementSpeed * direction * Time.deltaTime;
        transform.position = targetPosition;

    }
}