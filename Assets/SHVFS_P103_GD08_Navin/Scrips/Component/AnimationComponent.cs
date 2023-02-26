using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationComponent : MonoBehaviour
{
    public InputComponentBase InputComponentBase;
    [SerializeField]
    private Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InputComponentBase.GetInputDirectionNormalized().magnitude > 0f)
        {
            animator.Play("Walk");
        }
        else
        {
            animator.Play("Idle");
        }
    }
}
