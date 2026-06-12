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
                    Score.Increase(10);
                    break;
                case ResourceType.Water:
                    Score.Increase(20);
                    break;
                case ResourceType.Heat:
                    Score.Increase(20);
                    break;
                case ResourceType.Communication:
                    Score.Increase(50);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}