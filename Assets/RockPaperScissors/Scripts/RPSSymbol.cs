using UnityEngine;

public class RPSSymbol : MonoBehaviour
{
    private Symbol currentSymbol;

    [SerializeField]
    private MeshRenderer symbolRenderer;

    [SerializeField]
    private Material[] materials;


    void Start()
    {
        ChangeSymbol(GenerateSymbol(true));
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

