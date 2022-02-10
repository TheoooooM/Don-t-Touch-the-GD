using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SavedData : MonoBehaviour
{

    public static int candy;
    public int newCandies;
    public static List<int> unlockedBirds;
    public string takeAllBirds;
    private string valueSeparator="%VALUE%";
    public int highscore;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Saving();
        }

        if (Input.GetKeyDown((KeyCode.C)))
        {
            Loading();
        }
    }

    void Saving()
    {
        candy += newCandies;
        
        foreach (var i in unlockedBirds)
        {
            takeAllBirds += i.ToString();
            string saveAllBirds = string.Join(valueSeparator, unlockedBirds);
        }

        string saveCandies = candy.ToString();
        string fullSave = string.Join(saveCandies, valueSeparator,takeAllBirds);
        
        File.WriteAllText(Application.dataPath + "/datasaved.txt", fullSave);
        Debug.Log("Sauvegarde effectuée "+" total gems = "+candy);
    }

    void Loading()
    {
        string saveString = File.ReadAllText(Application.dataPath + "/datasaved.txt");
        string[] content = saveString.Split(new[] {valueSeparator}, System.StringSplitOptions.None);
        candy = int.Parse(content[0]);
        for (int i = 2; i < content.Length; i++)
        {
            unlockedBirds[i-2]= int.Parse(content[i]) ;
        }
        Debug.Log("Chargement effectué");
    }
}
