using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuUIManager : MonoBehaviour
{
    GameObject loadedCanvas;

    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] GameObject inGameCanavs;
    [SerializeField] GameObject duelMenuCanvas;
    [SerializeField] GameObject spriteMenuCanvas;
    [SerializeField] GameObject shopMenuCanvas;
    [SerializeField] GameObject statMenuCanvas;

    public GameObject highscoreTxt;
    public GameObject playedGamesTxt;

    public List<GameObject> SpritePages = new List<GameObject>();
    int pageIndex;

    private void Awake()
    {
        loadedCanvas = mainMenuCanvas;
        //Add the playerpref for score
    }

    public void ChangeCanvas(GameObject canvasToLoad)
    {
        loadedCanvas.GetComponent<MenuUIMover>().MoveCanvas(false);
        StartCoroutine(WaitCanvasMove(canvasToLoad));
    }

    IEnumerator WaitCanvasMove(GameObject canvasToLoad)
    {
        yield return new WaitForSeconds(0.5f);
        canvasToLoad.GetComponent<MenuUIMover>().MoveCanvas(true);
        loadedCanvas = canvasToLoad;
    }

    public void SpritePageChange(bool next)
    {
        SpritePages[pageIndex].SetActive(false);
        if (next) pageIndex++;
        else pageIndex--;

        if (pageIndex < 0) pageIndex = 4;
        if (pageIndex > 4) pageIndex = 0;
        SpritePages[pageIndex].SetActive(true);
    }
}
