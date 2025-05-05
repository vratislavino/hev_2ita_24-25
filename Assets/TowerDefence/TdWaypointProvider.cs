using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TdWaypointProvider : MonoBehaviour
{
    private static TdWaypointProvider instance;
    public static TdWaypointProvider Instance => instance;


    [SerializeField]
    private List<Transform> waypoints;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if(waypoints == null || waypoints.Count == 0)
        {
            Debug.LogError("Zapomnìl jsi na waypointy!");
        }
    }

    public Transform GetNext(Transform current)
    {
        if (current == null) return waypoints.First();
        
        int index = waypoints.IndexOf(current);
        index++;
        if(index < waypoints.Count)
            return waypoints[index];

        return null;
    }

    public static void Ahoj() { }
}
