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

        for (int r = 0; r < rows; r++)
        {
            GameObject rowObject = new GameObject("Row_" + r);
            rowObject.transform.SetParent(cardHolder, false);
            RectTransform rowRect = rowObject.AddComponent<RectTransform>();
            rowRect.sizeDelta = new Vector2(0, 0);

            HorizontalLayoutGroup hlg = rowObject.AddComponent<HorizontalLayoutGroup>();
            hlg.childControlWidth = true;
            hlg.childControlHeight = true;
            hlg.childForceExpandWidth = true;
            hlg.childForceExpandHeight = true;


            for (int c = 0; c < columns; c++)
            {
                GameObject card = Instantiate(cardPrefab, rowObject.transform);
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
