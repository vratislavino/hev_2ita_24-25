using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : MonoBehaviour
{
    State currentState;

    void Start()
    {
        currentState = new WanderState(GetComponent<NavMeshAgent>());
        currentState.InitState();
    }

    void Update()
    {
        if(currentState != null)
        {
            currentState.Process();
            var newState = currentState.TryToChangeState();
            if(newState != currentState)
            {
                currentState = newState;
                currentState.InitState();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RPSGameManager.EnemyRange);
    }
}
