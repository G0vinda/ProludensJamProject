using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Node : MonoBehaviour, IDestructible
{
    [SerializeField] private ConnectionLine connectionLinePrefab;
    [field: SerializeField] public ResourceType Type { get; private set; }
    [SerializeField] private List<Node> outNodes;
    [SerializeField] private UnityEvent onDisabled;

    public List<ConnectionLine> InConnections { get; private set; } = new();
    public List<ConnectionLine> OutConnections { get; private set; }

    public bool Active { get; set; } = true;
    
    void Start()
    {
        OutConnections = new();
        foreach (var outNode in outNodes)
        {
            var newLine = Instantiate(connectionLinePrefab);
            newLine.Connect(this, outNode);
            OutConnections.Add(newLine);
        }
    }

    public virtual void OnInConnectionDisabled(ConnectionLine connectionLine)
    {
        var type = connectionLine.Type;
        if (InConnections.All(connection => connection.Type != type || !connection.Active))
        {
            CrisisVisualizer.Instance.AddDestructibleForNextTic(this);
        }
    }

    public void Disable()
    {
        Active = false;
        Debug.Log("Connection disabled");
        OutConnections.ForEach(connection => CrisisVisualizer.Instance.AddDestructibleForNextTic(connection));
        onDisabled?.Invoke();
    }
}