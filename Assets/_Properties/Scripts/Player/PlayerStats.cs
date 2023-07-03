using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header ("Player VFX")]
    [SerializeField] GameObject[] auras;
    [SerializeField] float auraDuration;
    [SerializeField] float transformDuration;
    [SerializeField] TextMeshProUGUI playerLevel;
    public GameObject hitFx;
    public int playerLevelScore;

    GameObject currentAura;
    float elapsedTime;
    bool gateTrigger;
    Vector3 targetScale;
    Player player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        playerLevelScore = 1;
        playerLevel.text = playerLevelScore.ToString();
    }

    private void Update()
    {
        if(gateTrigger)
        {
            elapsedTime += Time.deltaTime;
            UpdateScale();
        }
    }

    private void UpdateScale()
    {
        float percentage = elapsedTime / transformDuration;
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, percentage);

        if (transform.localScale == targetScale)
        {
            gateTrigger = false;
            elapsedTime = 0;
        }
    }

    public void SpawnAura(int index)
    {
        currentAura = Instantiate(auras[index], transform.GetChild(0).transform);
        StartCoroutine("DestroyAura");
    }

    IEnumerator DestroyAura()
    {
        yield return new WaitForSeconds(auraDuration);
        Destroy(currentAura);
    }

    public void PassedGate(GateType gateType, int gateValue)
    {
        targetScale = LevelCalculator.CalculateSize(gateType, gateValue, transform);
        gateTrigger = true;
        AudioManager.PlayClipOnce(4);

        if(gateType == GateType.increase)
        {
            SpawnAura(0);
            player.playerMovement.limitValue -= 0.1f;
            playerLevelScore += (gateValue / 100);
        }
        else
        {
            SpawnAura(1);
            player.playerMovement.limitValue += 0.1f;
            playerLevelScore -= (gateValue / 100);
        }

        playerLevel.text = playerLevelScore.ToString();
    }
}
