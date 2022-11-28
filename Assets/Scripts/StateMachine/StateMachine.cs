using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private AnimationBase anim;
    private InputBase input;
    private MovementBase movement;

    //States
    private MovementState movementState;

    private StateBase currentState;

    private void Awake()
    {
        anim = GetComponent<AnimationBase>();
        input = GetComponent<InputBase>();
        movement = GetComponent<MovementBase>();

        InitializeStates();
    }

    private void InitializeStates()
    {
        movementState = new MovementState(anim, input, movement);
        currentState = movementState;
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
        }
    }

    public void ChangeState(StateBase newState)
    {
        if (currentState != null)
        {
            currentState.ExitState();
        }

        currentState = newState;
        currentState.EnterState();
    }
}
