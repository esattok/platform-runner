using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Vector2 lastMousePosition;
    Vector2 delta;
    public static Action SwipeLeft;
    public static Action SwipeRight;
    public static Action SwipeUp;
    public static Action SwipeDown;
    [SerializeField] float ignoreValue = 100f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
            delta = Vector2.zero;
        }

        else if (Input.GetMouseButton(0))
        {
            delta = (Vector2)Input.mousePosition - lastMousePosition;
            if (delta.magnitude < ignoreValue) return;

            if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
            {
                if (delta.x > 0)
                {
                    SwipeRight?.Invoke();
                    
                }
                else
                {
                    SwipeLeft?.Invoke();
                    
                }
            }

            else
            {
                if (delta.y > 0)
                {
                    SwipeUp?.Invoke();
                    
                }
                else
                {
                    SwipeDown?.Invoke();
                    
                }
            }
        }
    }
}
