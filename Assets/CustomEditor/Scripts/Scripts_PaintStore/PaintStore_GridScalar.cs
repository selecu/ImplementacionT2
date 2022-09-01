using UnityEngine;
using UnityEngine.UI;   
using System.Collections;


 namespace v1
{
    public class PaintStore_GridScalar : MonoBehaviour
    {
        [SerializeField]
        GameObject Canvas;
        [SerializeField]
        RectTransform CanvasRT;



        private GridLayoutGroup grid;
        private RectOffset gridPadding;
        private RectTransform parent;

        Vector2 lastSize;

        void Start()
        {
            grid = GetComponent<GridLayoutGroup>();
            gridPadding = grid.padding;
            lastSize = Vector2.zero;
            grid.cellSize = new Vector2(grid.cellSize.x * CanvasRT.localScale.x, grid.cellSize.y * CanvasRT.localScale.y);
            if (CanvasRT.localScale.x < 0.8)
            {
                grid.spacing = new Vector2(grid.spacing.x * CanvasRT.localScale.x + 70, grid.spacing.y);
            }
        }

    }

}
