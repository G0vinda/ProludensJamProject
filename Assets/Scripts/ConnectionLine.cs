using UnityEngine;
using UnityEngine.Events;

public class ConnectionLine : MonoBehaviour, IDestructible
{
    [SerializeField] private UnityEvent onDisabled;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    public bool Active { get; set; } = true;
    public ResourceType Type { get; private set; }
    public Node From { get; private set; }
    public Node To { get; private set; }
    
    public void Connect(Node from, Node to)
    {
        Type = from.Type;
        From = from;
        To = to;
        transform.position = Vector3.Lerp(from.transform.position, to.transform.position, 0.5f);
        to.InConnections.Add(this);
        
        var distance = Vector3.Distance(from.transform.position, to.transform.position);

        var bounds = spriteRenderer.sprite.bounds;
        var spriteWidth = bounds.size.x;

        var scale = transform.localScale;
        scale.x = distance / spriteWidth;
        transform.localScale = scale;

        var direction = (to.transform.position - from.transform.position).normalized;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Disable()
    {
        Active = false;
        To.OnInConnectionDisabled(this);
        onDisabled?.Invoke();
    }
}