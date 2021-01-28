using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet_DoubleJump : Feet,IJumpable,IMovable
{

    public int jumpCount=2;
    protected int jump_count = 0;
    protected override void updateJump(float vec)
    {
        can_jump = false;
        lastJumpState = jumpState;
        switch (jumpState)
        {
            case status.start_to_jump:
                jump_count++;
                jump_time_counter = 0;
                jumpState = status.jumping;
                can_jump = true;
                if (rd) rd.velocity = Vector2.up * jumpHeight;
                break;
            case status.jumping:
                if (vec != 0)
                {
                    jump_time_counter += Time.deltaTime;
                    if (jump_time_counter < jumpTime)
                    {
                        rd.velocity = Vector2.up * jumpHeight;
                        return;
                    }
                }
                else
                {
                    if (!isGround())
                    {
                        jumpState = status.in_flight;
                    }
                    else
                    {
                        jumpState = status.landed;
                    }
                }


                break;
            case status.in_flight:

                if (isGround())
                {
                    jumpState = status.landed;
                }
                else if (vec != 0 && jump_count<jumpCount)
                {
                    jumpState = status.start_to_jump;
                }
                
                break;
            case status.landed:
                if (vec == 0)
                    jumpState = status.ground;
                break;

            case status.ground:
                jump_count = 0;
                if (vec != 0) jumpState = status.start_to_jump;
                if (!isGround()) jumpState = status.in_flight;
                break;
        }
        //if (lastJumpState != jumpState)
        //    print(jumpState);
    }
}
