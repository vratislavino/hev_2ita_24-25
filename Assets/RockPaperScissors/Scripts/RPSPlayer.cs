using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class RPSPlayer : MonoBehaviour
{
    Camera cam;
    NavMeshAgent agent;

    [Header("Symbol properties")]
    [SerializeField]
    private float interval;
    private RPSSymbol symbol;


    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        symbol = GetComponent<RPSSymbol>();
        StartCoroutine(ChangeSymbolRoutine());
    }

    private IEnumerator ChangeSymbolRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(interval);
            symbol.ChangeSymbol(symbol.GenerateSymbol(false));
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit, 150f))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
