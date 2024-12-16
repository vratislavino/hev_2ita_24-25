using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class RPSAttack : MonoBehaviour
{
    public float attackInterval = 0.5f;
    private RPSSymbol mySymbol;

    void Start()
    {
        mySymbol = GetComponent<RPSSymbol>();
        StartCoroutine(AttackRoutine());   
    }

    private IEnumerator AttackRoutine()
    {
        yield return new WaitForSeconds(attackInterval);
        DoAttack();
    }

    private void DoAttack()
    {
        // v�echny collidery v okol�
        var colliders = Physics.OverlapSphere(transform.position, 1.5f);
        // filtr na RPSSymboly
        var symbols = colliders.Select(col => col.GetComponent<RPSSymbol>());
        // vyhozen� objekt�, kter� jsou null (nem�ly PSSymbol komponentu)
        symbols = symbols.Where(symbol => symbol != null);
        // vyhozen� objektu, kter� nejsme my
        var other = symbols.FirstOrDefault(symbol => symbol.transform != transform);

        var wouldWin = mySymbol.CurrentSymbol.WouldWin(other.CurrentSymbol);
        if(wouldWin.HasValue && wouldWin.Value)
        {
            Destroy(other.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }
}
