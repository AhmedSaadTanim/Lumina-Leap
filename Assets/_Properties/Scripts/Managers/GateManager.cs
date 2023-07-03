using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum GateType
{
    increase,
    decrease
}

public class GateManager : MonoBehaviour
{
    public RawImage gateImage;
    public TextMeshProUGUI gateText;
    [SerializeField] Texture[] textures;
    public int gateValue;
    public GateType gateType;

    Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        Canvas canvas = transform.GetChild(transform.childCount - 1).gameObject.GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
        
        GenerateRandomValueAndSymbol();
        AddGateValueAndSymbol();
    }

    private void GenerateRandomValueAndSymbol()
    {
        int tempValue = Random.Range(1, 10);
        gateValue = tempValue * 100;

        int typeIndex = Random.Range(0, 2);
        gateType = typeIndex == 1 ? GateType.decrease : GateType.increase;
    }

    public void AddGateValueAndSymbol()
    {
        gateText.text = gateValue.ToString();

        switch(gateType)
        {
            case GateType.increase:
                gateImage.texture = textures[0];
                break;

            case GateType.decrease:
                gateImage.texture = textures[1];
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.playerStats.PassedGate(gateType, gateValue);
            Destroy(transform.parent.gameObject);
        }
    }
}
