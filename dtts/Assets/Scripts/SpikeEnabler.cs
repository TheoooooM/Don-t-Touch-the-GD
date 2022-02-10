using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeEnabler : MonoBehaviour
{
    [SerializeField] private Transform rightSpikesTransform;
    [SerializeField] private Transform leftSpikesTransform;
    private List<GameObject> rightSpikesList = new List<GameObject>();
    private List<GameObject> leftSpikesList = new List<GameObject>();
    private List<GameObject> spikesPool = new List<GameObject>();

    void Start()
    {
        foreach (Transform child in rightSpikesTransform)
        {
            rightSpikesList.Add(child.gameObject);
        }
        foreach (Transform child in leftSpikesTransform)
        {
            leftSpikesList.Add(child.gameObject);
        }
    }

    private Vector2Int GetNumberOfSpikesToActivate(int score)
    {
        if (score < 20) return new Vector2Int(2, 3);
        if (score < 40) return new Vector2Int(3, 4);
        if (score < 60) return new Vector2Int(4, 5);
        if (score < 70) return new Vector2Int(5, 6);
        return score < 80 ? new Vector2Int(6, 7) : new Vector2Int(7, 7);
    }

    private void FillSpikePool(bool rightSide)
    {
        spikesPool.Clear();
        if (rightSide)
        {
            foreach (var obj in rightSpikesList)
            {
                spikesPool.Add(obj);
            }
        }
        else
        {
            foreach (var obj in leftSpikesList)
            {
                spikesPool.Add(obj);
            }
        }
    }

    private void ClearSpikes()
    {
        foreach (var obj in rightSpikesList)
        {
            obj.SetActive(false);
        }
        foreach (var obj in leftSpikesList)
        {
            obj.SetActive(false);
        }
    }

    public void EnableSpikes(bool rightSide, int score)
    {
        ClearSpikes();
        FillSpikePool(rightSide);
        var spikeRange = GetNumberOfSpikesToActivate(score);
        int numberOfSpikesToActivate = Random.Range(spikeRange.x, spikeRange.y+1);
        int number = 0;
        for (int i = 0; i < numberOfSpikesToActivate; i++)
        {
            number = Random.Range(0, spikesPool.Count);
            spikesPool[number].SetActive(true);
            spikesPool.Remove(spikesPool[number]);
        }
    }
}
