using UnityEngine;
using UnityEngine.AI;

public class AggroState : State
{
    private RPSSymbol target;

    public AggroState(NavMeshAgent agent, RPSSymbol target) : base(agent)
    {
        this.target = target;
        this.agent.speed = 6f;
        Debug.Log("I'm gonna get your ass");
    }

    public override void Process()
    {
        if(target != null)
            agent.SetDestination(target.transform.position);
    }

    public override State TryToChangeState()
    {
        if (target == null)
            return new WanderState(agent);

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
