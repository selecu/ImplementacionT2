using UnityEngine;
using UnityEngine.UI.Extensions;
using DG.Tweening;



namespace v1
{
    public class HighlightBehaviour_segundo : MonoBehaviour
    {

        public static HighlightBehaviour_segundo instance;

        public GameObject lineRendererPrefab;

        public Color[] colors;
        public int colorCounter;

        private void Awake()
        {
            instance = this;
            WordHunt_segundo.FoundWord += SetLineRenderer;
        }

        void SetLineRenderer(RectTransform t1, RectTransform t2)
        {

            GameObject line = Instantiate(lineRendererPrefab, transform);

            line.GetComponent<UILineRenderer>().color = colors[colorCounter];
            colorCounter = (colorCounter == colors.Length - 1) ? 0 : colorCounter + 1;

            // It is use the DG.Tweening library

            line.transform.DOScale(0, 0.3f).From().SetEase(Ease.OutBack);

            RectTransform[] points = new RectTransform[2];
            points.SetValue(t1, 0);
            points.SetValue(t2, 1);

            line.GetComponent<UILineConnector>().transforms = points;


        }

        private void OnDestroy()
        {
            WordHunt_segundo.FoundWord -= SetLineRenderer;
        }
    }
}


