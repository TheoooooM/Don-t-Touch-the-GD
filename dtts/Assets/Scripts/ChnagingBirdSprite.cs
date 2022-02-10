using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChnagingBirdSprite : MonoBehaviour
{
    public bool unlocked = false;

    public int cost;

    [SerializeField] int id;

    public Sprite mySprite;
    // Start is called before the first frame update
    void Start()
    {
        if (SavedData.unlockedBirds.Contains(id))
        {
            unlocked = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Buy()
    {
        

        if (!unlocked)
        {
            if (SavedData.candy>=cost)
            {
                SavedData.candy -= cost;
                unlocked = true;
                SavedData.unlockedBirds.Add(id);
            }
        }
        else
        {
            //sprite du perso = mysprite;
        }
    }
    
    
}
