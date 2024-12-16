using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.AI;

public class WanderState : State
{
    Vector3 target;

    public WanderState(NavMeshAgent agent) : base(agent)
    {
        this.agent.speed = 3.5f;
    }

    public override void InitState()
    {
        GenerateRandomTarget();
    }

    private void GenerateRandomTarget()
    {
        Vector3 point = new Vector3(
            Random.Range(0, 100f),
            100f,
            Random.Range(0, 100f)
            );

        if(Physics.Raycast(point, Vector3.down, out RaycastHit hit, 105f))
        {
            if(hit.collider.name.Contains("Terrain"))
            {
                target = hit.point;
            } else {
                GenerateRandomTarget();
            }

        } else
        {
            GenerateRandomTarget();
        }
    }

    public override void Process() // Update
    {
        if(Vector3.Distance(agent.transform.position, target) < 1f)
        {
            GenerateRandomTarget();
        }

        agent.SetDestination(target);
    }

    public override State TryToChangeState()
    {
        var colliders = Physics.OverlapSphere(agent.transform.position, RPSGameManager.EnemyRange);

        var symbols = colliders.Select(col => col.GetComponent<RPSSymbol>());

        symbols = symbols.Where(symbol => symbol != null);

        var other = symbols.FirstOrDefault(symbol => symbol.transform != agent.transform);
        
        if(other != null)
        {
            var wouldWin = symbol.CurrentSymbol.WouldWin(other.CurrentSymbol);
            if(wouldWin.HasValue)
            {
                if(wouldWin.Value == true)
                {
                    return new AggroState(agent, other);
                } else
                {
                    return new FleeState(agent, other);
                }
            } else
            {
                return this;
            }
        }
        return this;
    }
}
