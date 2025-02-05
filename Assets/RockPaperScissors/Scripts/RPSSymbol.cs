using UnityEngine;

public class RPSSymbol : MonoBehaviour
{
    private Symbol currentSymbol;
    public Symbol CurrentSymbol => currentSymbol;

    [SerializeField]
    private MeshRenderer symbolRenderer;

    [SerializeField]
    private Material[] materials;

    [SerializeField]
    private int lifeCount = 1;

    void Start()
    {
        ChangeSymbol(GenerateSymbol(true));
    }

    public void DoDamage()
    {
        lifeCount--;
        if (lifeCount <= 0)
        {
            Destroy(gameObject);
        }
    }

    public Symbol GenerateSymbol(bool completelyRandom)
    {
        if(completelyRandom)
        {
            return (Symbol)Random.Range(0, 3);
        } else
        {
            Symbol newSymbol = (Symbol)Random.Range(0, 3);
            if(newSymbol == currentSymbol)
            {
                return GenerateSymbol(completelyRandom);
            }
            return newSymbol;
        }
    }

    public void ChangeSymbol(Symbol newSymbol)
    {
        currentSymbol = newSymbol;
        symbolRenderer.material = materials[(int)currentSymbol];
    }
}

public enum Symbol
{
    Rock,
    Paper,
    Scissors
}

