using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class HoverScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Vector3 startingScale;
        [SerializeField] private Vector3 upsizedScale = new Vector3(1.2f, 1.2f, 1.2f);
        [SerializeField] private float connectorScaleMultiplier = 1.2f;

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
                var localScale = connection.transform.localScale;
                localScale.y *= connectorScaleMultiplier;
                connection.transform.localScale = localScale;
            }
        }
        
        public void OnPointerExit(PointerEventData eventData)
        {
            gameObject.transform.localScale = startingScale;
            
            var connections = gameObject.GetComponent<Node>().OutConnections;

            foreach (var connection in connections)
            {
                var localScale = connection.transform.localScale;
                localScale.y /= connectorScaleMultiplier;
                connection.transform.localScale = localScale;
            }
        }
    }
}