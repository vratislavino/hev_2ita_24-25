using UnityEngine;

public static class RPSExtensions
{
    public static bool? WouldWin(this Symbol s1, Symbol s2)
    {
        if (s1 == s2) return null; // remíza

        switch(s1)
        {
            case Symbol.Rock:
                return s2 == Symbol.Scissors;
            case Symbol.Paper:
                return s2 == Symbol.Rock;
            case Symbol.Scissors:
                return s2 == Symbol.Paper;
        }
        return null; // should not happen
    }
}
