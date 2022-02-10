using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuUIManager : MonoBehaviour
{
    public static MenuUIManager Instance;

    
    public GameObject loadedCanvas;
    public AudioSource AudioSource;
    
    [SerializeField] GameObject mainMenuCanvas;
    public GameObject inGameCanavs;
    [SerializeField] GameObject duelMenuCanvas;
    [SerializeField] GameObject spriteMenuCanvas;
    [SerializeField] GameObject shopMenuCanvas;
    [SerializeField] GameObject statMenuCanvas;

    public TextMeshProUGUI highscoreTxt;
    public TextMeshProUGUI playedGamesTxt;
    public TextMeshProUGUI deathHighscoreTxt;
    public TextMeshProUGUI deathPlayedGamesTxt;
    public TextMeshProUGUI scoreText;

    public List<GameObject> SpritePages = new List<GameObject>();
    int pageIndex;

    private void Awake()
    {
        Instance = this;
        loadedCanvas = mainMenuCanvas;
        Debug.Log(PlayerPrefs.GetInt("highScore"));
        highscoreTxt.text = $"Highscore : {PlayerPrefs.GetInt("highScore")}";
        playedGamesTxt.text = $"Played Games : {PlayerPrefs.GetInt("partyPlayed")}";
    }

    public void ChangeCanvas(GameObject canvasToLoad)
    {
        AudioSource.Play();
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
