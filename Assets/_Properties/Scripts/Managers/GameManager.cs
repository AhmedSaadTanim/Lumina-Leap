using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool hasGameStarted;
    public static bool hasGameFinished;
    public static int coinCounter;
    [SerializeField] GameObject refEndScene;
    [SerializeField] TextMeshProUGUI coinText;

    private void Awake()
    {
        Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;
        hasGameStarted = false;
        hasGameFinished = false;
    }

    private void Update()
    {
        if (hasGameStarted) 
        {
            coinText.text = coinCounter.ToString();
        }
        else if(hasGameFinished)
        {
            refEndScene.SetActive(true);
        }
    }

    public void StartGame()
    {
        hasGameStarted = true;
    }

    public void OnRestart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
