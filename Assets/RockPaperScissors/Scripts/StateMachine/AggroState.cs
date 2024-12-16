using UnityEngine;
using UnityEngine.AI;

public class AggroState : State
{
    private RPSSymbol target;

    public AggroState(NavMeshAgent agent, RPSSymbol target) : base(agent)
    {
        this.target = target;
        this.agent.speed = 6f;
    }

    public override void Process()
    {
        Debug.Log("I'm gonna get your ass");
        agent.SetDestination(target.transform.position);
    }

    public override State TryToChangeState()
    {
        var wouldWin = symbol.CurrentSymbol.WouldWin(target.CurrentSymbol);
        if (!wouldWin.HasValue)
        {
            return new WanderState(agent);
        } else
        {
            if (wouldWin.Value)
            {
                return this;
            } else
            {
                return new FleeState(agent, target);
            }
        }
    }
}
