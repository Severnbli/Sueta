using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    List<Transform> points = new List<Transform>();
    public GameObject collectiblePrefab;
    public int totalCollectibles = 5;
    private int _collectedCount = 0;
    public TextMeshProUGUI collectedText;
    public TextMeshProUGUI remainingText;
    private HashSet<int> occupiedIndices = new HashSet<int>();

    void Start()
    {
        GameObject[] pointsObject = GameObject.FindGameObjectsWithTag("Points");
        foreach (GameObject point in pointsObject)
        {
            Transform pointTransform = point.transform;
            points.Add(pointTransform);
        }

        for (int i = 0; i < totalCollectibles; i++)
        {
            SpawnCollectible();
        }
        UpdateUI();
    }

    void SpawnCollectible()
    {
        if (points.Count > 0)
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, points.Count);
            } while (occupiedIndices.Contains(randomIndex));

            occupiedIndices.Add(randomIndex);
            GameObject collectible = Instantiate(collectiblePrefab, points[randomIndex].position, Quaternion.identity);
            collectible.tag = "Collectible";
        }
    }

    public void Collect()
    {
        _collectedCount++;
        UpdateUI();

        if (_collectedCount >= totalCollectibles)
        {
            SceneManager.LoadScene("EndScreenVictory");
        }
    }

    void UpdateUI()
    {
        collectedText.text = "Collected mushrooms: " + _collectedCount;
        remainingText.text = "In total: " + (totalCollectibles - _collectedCount);
    }
}
