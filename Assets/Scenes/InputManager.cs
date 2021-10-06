using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] Actor player;

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            player.Move(context.ReadValue<Vector2>());
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started || context.performed)
        {
            player.Jump(true);
        }
        else
        {
            player.Jump(false);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            player.Attack(true);
        }
        else
        {
            player.Attack(false);
        }
    }
}
