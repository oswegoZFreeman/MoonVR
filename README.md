# MoonVR
 Known Issues:

 a. Looking in certain directions disables the players ability to jump. Cause unknown. Current speculation is that it has something to do with how the VR camera updates the players positional data when looking around, but this is ultimately just a wayward guess. It absolutely has to do with the direction the player is facing in the 3D space, as it happens both when the player manually orients where they're facing and when theu use the snap-turn on the controller.

    Attempted solutions:
        - none

 b. Jumping uses the coroutine loop function - which moves the player upwards a fixed amount (JumpForce) once each frame for a certain number of frames (jumpHeight). The issue with this is if the player is jumping up an incline, they would touch the ground sooner than when the jumping coroutine would finish (which the coroutine doesn't identify) - thus causing the player to continue rising after they have already touched the ground.

    Attempted solutions:

        1. Attempted setting this in the UpdateMovement function (updated every frame) where isJumping would be set to true after the jump function was invoked and would then check every frame for when the player was touching the ground but also a certain height above the height at which the jump began (as otherwise it would immediately cancel the jump if this height buffer weren't in place).

            if (isJumping)
            {
                if (transform.position.y > (initialYPosition + (.3 * jumpHeight)) && Controller.isGrounded)
                {
                    isJumping = false;
                    StopCoroutine("JumpCoroutine");
                }
            }

        The issue encountered with this solution was that it further exacerbated the issue where the player wouldn't jump when looking in certain directions. Reason for this unknown. Was also inconsistent when the player would be going up a very steep incline.

c. Movement is choppy and after moving around enough it gets rubber-bandy and weird. Might be because of my hardware not being able to handle the load, but also might be because the OVR default script is overbloated with movement adjustments and getting messy after enough input.

    Attempted solutions:
        -none

    Should test making a new script with the most basic implementation of movement to see if it's truly because of bloat in the OVR script or if it's just my computer.