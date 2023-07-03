using UnityEngine;
using TMPro;
using System.Collections;

public class Wall : MonoBehaviour
{
    public int wallLevel;
    [SerializeField] TextMeshProUGUI wallText;

    float destroyDelay = 0.5f;
    Player player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        GenerateRandomValue();
        wallText.text = wallLevel.ToString();
    }

    private void GenerateRandomValue()
    {
        int tempValue = Random.Range(1, 10);
        wallLevel = tempValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (player.playerStats.playerLevelScore >= wallLevel)
            {
                AudioManager.PlayClipOnce(6);
                StartCoroutine("DestroySelf");
            }
            else
            {
                GameManager.hasGameStarted = false;
                AudioManager.PlayClipOnce(5);
                StartCoroutine("DelayDeath");
                player.playerAnimation.ChangeAnimationState(States.PLAYER_FAIL);

                Instantiate(player.playerStats.hitFx, player.transform.GetChild(0).transform.position + new Vector3(0, 1f, 0), Quaternion.identity);

                Handheld.Vibrate();
            }
        }
    }

    IEnumerator DelayDeath()
    {
        yield return new WaitForSeconds(1f);
        GameManager.hasGameFinished = true;
    }
    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
}
