using UnityEngine;
using UnityEngine.AI;

public class AggroState : State
{
    public AggroState(NavMeshAgent agent) : base(agent)
    {
    }

    public override void Process()
    {
        Debug.Log("I'm gonna get your ass");
    }

    public override State TryToChangeState()
    {
        return this;
    }
}
