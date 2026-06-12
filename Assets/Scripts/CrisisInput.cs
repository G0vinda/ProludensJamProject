using System.Linq;
using UnityEngine;

public class CrisisInput : MonoBehaviour
{
    [SerializeField] private GameObject stormPrefab;
    [SerializeField] private float stormRadius;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            OnClicked();
    }

    private void OnClicked()
    {
        Debug.Log("OnClicked");
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        Instantiate(stormPrefab, mouseWorldPos, Quaternion.identity);
        var hits = Physics2D.OverlapCircleAll(mouseWorldPos, stormRadius);
        
        CrisisVisualizer.Instance.StartDestruction(hits.Where(hit => hit.TryGetComponent<IDestructible>(out var _)).Select(hit => hit.GetComponent<IDestructible>()).ToArray());
    }
}