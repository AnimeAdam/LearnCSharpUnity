using UnityEngine;

public interface LocomotionContext
{
    void SetState(LocomotionState newState);
}

public interface LocomotionState
{
    void Jump(LocomotionContext context);
    void Fall(LocomotionContext context);
    void Land(LocomotionContext context);
    void Crouch(LocomotionContext context);
}

public class LocomotionStatePattern : MonoBehaviour, LocomotionContext
{
    LocomotionState currentState;

    public void Crouch() => currentState.Crouch(this);

    public void Fall() => currentState.Fall(this);

    public void Jump() => currentState.Jump(this);

    public void Land() => currentState.Land(this);

    void LocomotionContext.SetState(LocomotionState newState)
    {
        currentState = newState;
    }
}

public class GroundedState : LocomotionState
{
    public void Crouch(LocomotionContext context)
    {
        context.SetState(new CrouchingState());
    }

    public void Fall(LocomotionContext context)
    {
        context.SetState(new InAirState());
    }

    public void Jump(LocomotionContext context)
    {
        context.SetState(new InAirState());
    }

    public void Land(LocomotionContext context)
    {
    }
}

public class InAirState : LocomotionState
{
    public void Crouch(LocomotionContext context)
    {
        throw new System.NotImplementedException();
    }

    public void Fall(LocomotionContext context)
    {
        throw new System.NotImplementedException();
    }

    public void Jump(LocomotionContext context)
    {
        throw new System.NotImplementedException();
    }

    public void Land(LocomotionContext context)
    {
        throw new System.NotImplementedException();
    }
}

public class CrouchingState : LocomotionState
{
    public void Crouch(LocomotionContext context)
    {
        throw new System.NotImplementedException();
    }

    public void Fall(LocomotionContext context)
    {
        throw new System.NotImplementedException();
    }

    public void Jump(LocomotionContext context)
    {
        throw new System.NotImplementedException();
    }

    public void Land(LocomotionContext context)
    {
        throw new System.NotImplementedException();
    }
}