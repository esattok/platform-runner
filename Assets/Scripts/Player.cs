using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] Animator animator;
    [SerializeField] string startTrigger; 

    private void Awake()
    {
        if (!string.IsNullOrEmpty(startTrigger))
            animator.SetTrigger(startTrigger);
    }

    private void OnEnable()
    {
        InputManager.SwipeLeft += MovePlayerLeft;
        InputManager.SwipeRight += MovePlayerRight;
    }

    private void OnDisable()
    {
        InputManager.SwipeLeft -= MovePlayerLeft;
        InputManager.SwipeRight -= MovePlayerRight;
    }
}
