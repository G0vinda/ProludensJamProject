using UnityEngine;

public class CrisisInput : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            OnClicked();
    }

    private void OnClicked()
    {
        Debug.Log("OnClicked");
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject.TryGetComponent(out IDestructible destructible))
        {
            Debug.Log("Destructible found");
            CrisisVisualizer.Instance.AddDestructibleForNextTic(destructible);
        }
    }
}