using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class WanderState : State
{
    public WanderState(NavMeshAgent agent) : base(agent)
    {
    }

    public override void Process() // Update
    {
        // Váš job
    }

    public override State TryToChangeState()
    {
        var colliders = Physics.OverlapSphere(agent.transform.position, RPSGameManager.EnemyRange);

        var symbols = colliders.Select(col => col.GetComponent<RPSSymbol>());
        Debug.Log(string.Join(", ", symbols));

        var other = symbols.FirstOrDefault(symbol => symbol.transform != agent.transform);
        
        if(other != null)
        {
            // return AggroState(agent);
        }
        return this;
    }
}
