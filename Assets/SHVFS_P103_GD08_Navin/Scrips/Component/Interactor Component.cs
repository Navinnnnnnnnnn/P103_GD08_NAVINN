using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractorComponent : MonoBehaviour
{
    [SerializeField]
    private float interactMultiplier;
    [SerializeField]
    private float playerWidth;
    [SerializeField]
    private float playerHeight;

    private PlayerActions playerActions;
    private float interactDistance => interactMultiplier * Time.deltaTime;

    private void Awake()
    {
        playerActions = new PlayerActions();
        playerActions.PlayerInput.Enable();
    }


    void Update()
    {
        if (playerActions.PlayerInput.InteractPrimary.WasPressedThisFrame())
        {
            Debug.Log("Interacted!");
        }
    }


    private void TryInteract()
    {
        //var hits = Physics.CapsuleCastAll(transform.position, transform.position + Vector3.up * playerHeight, transform.forward, interactDistance);

        //if (hits.Length < 1) return;

        //foreach (var hit in hits)
        //{

        //    var interactable = hit.transform.GetComponent<InteractableComponent>();

        //    if (interactable == null) return;

        //    interactable.Interact();
        //}
        var hits = Physics.CapsuleCastAll(transform.position, transform.position + Vector3.up * playerHeight, playerWidth, transform.forward, interactDistance);

        if (hits.Length < 1) return;

        if (!hits.All(hit => hit.transform.GetComponent<InteractableComponentBase>() == null))

            foreach (var hit in hits)
            {
                var interactable = hit.transform.GetComponent<InteractableComponentBase>();

                if (interactable != null) return;

                interactable.Interact();
            }

    }
}
    //void OnCollisionStay(Collision collisionInfo)
    //{

    //    foreach (ContactPoint contact in collisionInfo.contacts)
    //    {
    //        Debug.DrawRay(contact.point, contact.normal * 10, Color.white);
    //        if (Input.GetKeyDown(KeyCode.E))
    //        {
    //            Debug.Log("Interacted!");
    //        }
    //    }
    //}

