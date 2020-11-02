using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    IPlayerInput input;
    AgentMovement movement;

    private void Start()
    {
        input = GetComponent<IPlayerInput>();
        movement = GetComponent<AgentMovement>();
        input.OnMovementDirectionInput += movement.HandleMovementDirection;
        input.OnMovementInput += movement.HandleMovement;
    }
}
