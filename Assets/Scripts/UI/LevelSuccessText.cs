using LitMotion;
using LitMotion.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class LevelSuccessText : MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private float animationDuration = 0.5f;
        [SerializeField] private Vector3 finalScale;
        
        private MotionHandle scaleHandle;

        private void Awake()
        {
            if (text != null)
            {
                text.transform.localScale = Vector3.zero;
            }
        }

        [ContextMenu("Show Text")]
        public void Show()
        {
            if (text == null) return;

            if (scaleHandle.IsActive())
            {
                scaleHandle.Cancel();
            }

            text.transform.localScale = Vector3.zero;

            scaleHandle = LMotion.Create(Vector3.zero, finalScale, animationDuration)
                .WithEase(Ease.OutBack)
                .BindToLocalScale(text.transform);
        }

        private void OnDestroy()
        {
            if (scaleHandle.IsActive())
            {
                scaleHandle.Cancel();
            }
        }
    }
}