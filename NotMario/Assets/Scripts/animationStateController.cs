 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isRightstrafingHash;
    int isLeftstrafingHash;
    int isRightstrafewalkingHash;
    int isLeftstrafewalkingHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isRightstrafingHash = Animator.StringToHash("isRightstrafing");
        isLeftstrafingHash = Animator.StringToHash("isLeftstrafing");
        isLeftstrafewalkingHash = Animator.StringToHash("isLeftstrafewalking");
        isRightstrafewalkingHash = Animator.StringToHash("isRightstrafewalking");
    }

    // Update is called once per frame
    void Update()
    {
        
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        bool isRunning = animator.GetBool("isRunning");
        bool runPressed = Input.GetKey("left shift");
        bool isRightstrafing = animator.GetBool("isRightstrafing");
        bool rightpressed = Input.GetKey("d");
        bool leftpressed = Input.GetKey("a");
        bool isLeftstrafing = animator.GetBool("isLeftstrafing");
        bool isRightstrafewalking = animator.GetBool("isRightstrafewalking");
        bool rightwalkpressed = Input.GetKey("d");
        bool isLeftstrafewalking = animator.GetBool("isLeftstrafewalking");
        bool Leftwalkpressed = Input.GetKey("a");



        if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }
        if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }
        if (!isRunning && (forwardPressed && runPressed))
        {
            animator.SetBool(isRunningHash, true);
        }
        if (isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool(isRunningHash, false); 
        }
        if (!isRightstrafing && (rightpressed && runPressed))
        {
            animator.SetBool(isRightstrafingHash, true);
        }
        if (isRightstrafing && (!rightpressed || !runPressed))
        {
            animator.SetBool(isRightstrafingHash, false);
        }
        if (!isLeftstrafing && (leftpressed && runPressed))
        {
            animator.SetBool(isLeftstrafingHash, true);
        }
        if (isLeftstrafing && (!leftpressed || !runPressed))
        {
            animator.SetBool(isLeftstrafingHash, false);
        }
       /* if (!isLeftstrafewalking && (leftpressed && forwardPressed))
        {
            animator.SetBool(isLeftstrafewalkingHash, true);
        }
        if (isLeftstrafewalking && (!leftpressed || !forwardPressed))
        {
            animator.SetBool(isLeftstrafewalkingHash, false);
        }
        if (!isRightstrafewalking && (rightpressed && forwardPressed))
        {
            animator.SetBool(isLeftstrafewalkingHash, true);
        }
        if (isRightstrafewalking && (!rightpressed || !forwardPressed))
        {
            animator.SetBool(isRightstrafewalkingHash, false);
        }
        */

        
    }
}
