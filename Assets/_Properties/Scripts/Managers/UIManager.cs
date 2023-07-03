using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject startPanel, gamePanel;

    private void Update()
    {
        if(GameManager.hasGameStarted)
        {
            startPanel.SetActive(false);
            gamePanel.SetActive(true);
        }

        if(GameManager.hasGameFinished)
        {
            gamePanel.SetActive(false);
            AudioManager.audioSource.Stop();
        }
    }
}
