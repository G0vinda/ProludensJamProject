using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class HoverScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Vector3 startingScale;
        [SerializeField] private Vector3 upsizedScale;
        [SerializeField] private float connectorScaleMultiplier;

        private void Awake()
        {
            startingScale = transform.localScale;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            gameObject.transform.localScale = upsizedScale;
            var connections = gameObject.GetComponent<Node>().OutConnections;

            foreach (var connection in connections)
            {
                connection.transform.localScale *= connectorScaleMultiplier;
            }
        }
        
        public void OnPointerExit(PointerEventData eventData)
        {
            gameObject.transform.localScale = startingScale;
            
            var connections = gameObject.GetComponent<Node>().OutConnections;

            foreach (var connection in connections)
            {
                connection.transform.localScale /= connectorScaleMultiplier;
            }
        }
    }
}