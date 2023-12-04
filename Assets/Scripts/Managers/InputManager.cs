using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class InputManager
{
    private static Controls _controls;
    private static float jumpTimer = 0;
    public static void Init(Player myPlayer)
    {
        _controls = new Controls();

        _controls.Game.Movement.performed += ctx => 
        {
            myPlayer.SetMovementDirection(ctx.ReadValue<Vector2>());
        
        };

        _controls.Jumping.Jump.performed += ctx =>
        {
            /**
                jumpTimer += Time.deltaTime;
                if (jumpTimer > 1) jumpTimer = 1;
                Debug.Log("Jump Power is at " + jumpTimer);
            
            if (_controls.Jumping.Jump.WasReleasedThisFrame())
            {
            **/
                myPlayer.Jump(/**jumpTimer**/);
            //}
            
        };


        _controls.Game.Attack.performed += ctx =>
        {
            myPlayer.AttackStart();


        };

        


    }
    public static void EnableGame()
    {
        _controls.Game.Enable();
        _controls.Jumping.Enable();
    }
    public static void DisableGame()
    {
        _controls.Game.Disable();
        _controls.Jumping.Disable();
    }
    
    
    
}
