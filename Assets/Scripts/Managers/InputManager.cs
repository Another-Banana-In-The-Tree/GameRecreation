using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    private static Controls _controls;

    public static void Init(Player myPlayer)
    {
        _controls = new Controls();

        _controls.Game.Movement.performed += ctx => 
        {
            myPlayer.SetMovementDirection(ctx.ReadValue<Vector3>());
        
        };

        _controls.Game.Jump.started += ctx =>
        {
            myPlayer.Jump();
        };

        _controls.Enable();


    }
    
    
    
}
