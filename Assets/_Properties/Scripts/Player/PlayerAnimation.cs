using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    string currentState;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void ChangeAnimationState(string newState)
    {
        if(currentState == newState)
            return;

        animator.Play(newState);
        currentState = newState;
    }
}
