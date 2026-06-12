using LitMotion;
using LitMotion.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class NodeScoreText : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private float animationDuration = 1f;
        [SerializeField] private float moveUpDistance = 50f;

        private MotionHandle moveHandle;
        private MotionHandle fadeHandle;

        [ContextMenu("Set Counter Test")]
        public void SetCounterTest()
        {
            SetCounter(19);
        }
        
        public void SetCounter(int score)
        {
            scoreText.text = score.ToString();

            AnimateText();
        }

        private void AnimateText()
        {
            if (moveHandle.IsActive()) moveHandle.Cancel();
            if (fadeHandle.IsActive()) fadeHandle.Cancel();

            // Reset alpha
            Color color = scoreText.color;
            color.a = 1f;
            scoreText.color = color;

            Vector3 startPos = scoreText.transform.localPosition;
            Vector3 targetPos = startPos + (Vector3.up * moveUpDistance);

            // Animate moving upwards
            moveHandle = LMotion.Create(startPos, targetPos, animationDuration)
                .WithEase(Ease.OutCubic)
                .BindToLocalPosition(scoreText.transform);

            // Animate fading out
            fadeHandle = LMotion.Create(1f, 0f, animationDuration)
                .WithEase(Ease.InQuad)
                .BindToColorA(scoreText);
        }

        private void OnDestroy()
        {
            if (moveHandle.IsActive()) moveHandle.Cancel();
            if (fadeHandle.IsActive()) fadeHandle.Cancel();
        }
    }
}