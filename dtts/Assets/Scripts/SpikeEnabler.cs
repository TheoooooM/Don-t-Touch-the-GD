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
        return Vector2Int.zero;
    }

    public void EnableSpikes(bool rightSide, int score)
    {
        
    }
}
