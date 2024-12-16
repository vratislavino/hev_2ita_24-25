using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class FleeState : State
{
    RPSSymbol target; // I am afraid of this man

    public FleeState(NavMeshAgent agent, RPSSymbol target) : base(agent) 
    {
        this.target = target;
        this.agent.speed = 2f;
    }

    public override void Process()
    {
        Debug.Log("<color=red>I'm gonna leave your ass</color>");
        var dir = target.transform.position - agent.transform.position;
        dir *= -1;
        var newTarget = agent.transform.position + dir;
        agent.SetDestination(newTarget);
    }

    public override State TryToChangeState()
    {
        var wouldWin = symbol.CurrentSymbol.WouldWin(target.CurrentSymbol);
        if (!wouldWin.HasValue)
        {
            return new WanderState(agent);
        }
        else
        {
            if (wouldWin.Value)
            {
                return new AggroState(agent, target);
            }
            else
            {
                return this;
            }
        }
    }
}
