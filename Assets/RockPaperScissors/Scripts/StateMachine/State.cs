using UnityEngine;
using UnityEngine.AI;

public abstract class State
{
    protected NavMeshAgent agent;
    protected RPSSymbol symbol;

    public State(NavMeshAgent agent)
    {
        this.agent = agent;
        this.symbol = agent.GetComponent<RPSSymbol>();
    }

    public virtual void InitState() { }

    public abstract void Process();

    public abstract State TryToChangeState();
}
