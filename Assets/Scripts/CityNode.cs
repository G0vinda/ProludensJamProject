using System;
using System.Linq;
using UnityEngine;

public class CityNode : Node
{
    [SerializeField] private GameObject electricityVfx;
    [SerializeField] private GameObject communitcationVfx;
    [SerializeField] private GameObject heatVfx;
    [SerializeField] private GameObject waterVfx;
    
    public override void OnInConnectionDisabled(ConnectionLine connectionLine)
    {
        var type = connectionLine.Type;
        if (InConnections.All(connection => connection.Type != type || !connection.Active))
        {
            switch (type)
            {
                case ResourceType.Electricity:
                    Instantiate(electricityVfx, transform.position, Quaternion.identity);
                    Score.Increase(10);
                    break;
                case ResourceType.Water:
                    Instantiate(waterVfx, transform.position, Quaternion.identity);
                    Score.Increase(20);
                    break;
                case ResourceType.Heat:
                    Instantiate(heatVfx, transform.position, Quaternion.identity);
                    Score.Increase(20);
                    break;
                case ResourceType.Communication:
                    Instantiate(communitcationVfx, transform.position, Quaternion.identity);
                    Score.Increase(50);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}