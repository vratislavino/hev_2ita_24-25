using UnityEngine;
using UnityEngine.AI;

public abstract class State
{
    protected NavMeshAgent agent;

    public State(NavMeshAgent agent)
    {
        this.agent = agent;
    }

    public virtual void InitState() { }

    public abstract void Process();

    public abstract State TryToChangeState();
}
