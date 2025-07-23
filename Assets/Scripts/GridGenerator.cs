using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform cardHolder;

    private List<GameObject> spawnedCards = new List<GameObject>();
    public int rows, cols;
    private void Start()
    {
        GenerateGrid(rows, cols);
    }
    public void GenerateGrid(int rows, int columns)
    {
        ClearGrid();

        RectTransform holderRect = cardHolder.GetComponent<RectTransform>();
        float parentHeight = holderRect.rect.height;
        float parentWidth = holderRect.rect.width;

        float rowHeight = parentHeight / rows;
        float cardWidth = parentWidth / columns;

        for (int r = 0; r < rows; r++)
        {
            GameObject rowObject = new GameObject("Row_" + r, typeof(RectTransform));
            rowObject.transform.SetParent(cardHolder, false);
            RectTransform rowRect = rowObject.GetComponent<RectTransform>();

            // Anchor row fully to width, and place vertically based on index
            rowRect.anchorMin = new Vector2(0, 1);
            rowRect.anchorMax = new Vector2(1, 1);
            rowRect.pivot = new Vector2(0.5f, 1);
            rowRect.sizeDelta = new Vector2(0, rowHeight);
            rowRect.anchoredPosition = new Vector2(0, -r * rowHeight);

            for (int c = 0; c < columns; c++)
            {
                GameObject card = Instantiate(cardPrefab, rowObject.transform);
                RectTransform cardRect = card.GetComponent<RectTransform>();

                cardRect.anchorMin = new Vector2(0, 0);
                cardRect.anchorMax = new Vector2(0, 1);
                cardRect.pivot = new Vector2(0, 0.5f);
                cardRect.sizeDelta = new Vector2(cardWidth, 0);
                cardRect.anchoredPosition = new Vector2(cardWidth * c, 0);

                spawnedCards.Add(card);
            }
        }
    }




    public void ClearGrid()
    {
        foreach (var card in spawnedCards)
        {
            if (card != null)
                Destroy(card);
        }
        spawnedCards.Clear();
    }

    public List<GameObject> GetAllCards()
    {
        return spawnedCards;
    }
}
