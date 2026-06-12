using System;
using System.Linq;
using UnityEngine;

public class CityNode : Node
{
    public override void OnInConnectionDisabled(ConnectionLine connectionLine)
    {
        var type = connectionLine.Type;
        if (InConnections.All(connection => connection.Type != type || !connection.Active))
        {
            switch (type)
            {
                case ResourceType.Electricity:
                    Debug.Log("10 Points");
                    break;
                case ResourceType.Water:
                    Debug.Log("20 Points");
                    break;
                case ResourceType.Heat:
                    Debug.Log("20 Points");
                    break;
                case ResourceType.Communication:
                    Debug.Log("50 Points");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}