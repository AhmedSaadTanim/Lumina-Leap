using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static bool cameraViewOn;

    [Header ("Audio")]
    [SerializeField] AudioSource footstepSound;

    [Header ("Movement")]
    [SerializeField] Transform playerTransform;
    [SerializeField] Animator animator;
    public Vector3 endOfPath;
    public float limitValue;
    [SerializeField] GameObject canvasPlayer, celebrateVFX, arm, trophy, placeholder;

    Player player;
    bool isRunning, canMove, isSwitched;

    private void Start()
    {
        cameraViewOn = false;
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (GameManager.hasGameStarted)
        {
            if (!isRunning)
            {
                player.playerAnimation.ChangeAnimationState(States.PLAYER_RUN);
                footstepSound.enabled = true;
                isRunning = true;
                canMove = true;
            }

            if (Input.GetMouseButton(0) && canMove)
            {
                MovePlayer();
            }

            if (Vector3.Distance(transform.position, endOfPath) == 0)
            {
                canMove = false;
                OnReachedEndLine();
            }
        }
        else
        {
            footstepSound.enabled = false;
        }
    }

    private void OnReachedEndLine()
    {
        player.playerAnimation.ChangeAnimationState(States.PLAYER_VICTORY);
        footstepSound.enabled = false;
        cameraViewOn = true;
        celebrateVFX.SetActive(true);

        GameManager.hasGameStarted = false;
        GameManager.hasGameFinished = true;

        canvasPlayer.SetActive(false);
        SwitchPosition();
    }

    private void SwitchPosition()
    {
        if(!isSwitched)
        {
            isSwitched = true;

            trophy.transform.SetParent(arm.transform);
            trophy.transform.localScale = placeholder.transform.localScale;
            trophy.transform.localRotation = placeholder.transform.localRotation;
            trophy.transform.localPosition = placeholder.transform.localPosition;
        }
    }
    private void MovePlayer()
    {
        float halfScreen = Screen.width / 2;
        float xPos = (Input.mousePosition.x - halfScreen) / halfScreen;

        float finalXPos = Mathf.Clamp(xPos * limitValue, -limitValue, limitValue);
        playerTransform.localPosition = new Vector3(finalXPos, 0, 0);

    }
}
