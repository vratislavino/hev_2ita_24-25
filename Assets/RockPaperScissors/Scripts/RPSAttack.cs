using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class RPSAttack : MonoBehaviour
{
    public float attackInterval = 0.5f;
    private RPSSymbol mySymbol;

    private ParticleSystem attackParticleSystem;

    void Start()
    {
        attackParticleSystem = GetComponentInChildren<ParticleSystem>();
        mySymbol = GetComponent<RPSSymbol>();
        StartCoroutine(AttackRoutine());   
    }

    private IEnumerator AttackRoutine()
    {
        while(true)
        { 
            yield return new WaitForSeconds(attackInterval);
            attackParticleSystem?.Emit(50);
            DoAttack();
        }
    }

    private void DoAttack()
    {
        // v�echny collidery v okol�
        var colliders = Physics.OverlapSphere(transform.position, 1.5f);
        //Debug.Log(string.Join(",", colliders.Select(c=>c.name).ToList()));
        // filtr na RPSSymboly
        var symbols = colliders.Select(col => col.GetComponent<RPSSymbol>());
        // vyhozen� objekt�, kter� jsou null (nem�ly PSSymbol komponentu)
        symbols = symbols.Where(symbol => symbol != null);
        // vyhozen� objektu, kter� nejsme my
        var other = symbols.FirstOrDefault(symbol => symbol.transform != transform);

        if (other)
        {
            var wouldWin = mySymbol.CurrentSymbol.WouldWin(other.CurrentSymbol);
            if (wouldWin.HasValue && wouldWin.Value)
            {
                Debug.Log($"{gameObject.name} killed {other.gameObject.name}");
                other.DoDamage();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, 1.5f);
    }
}
