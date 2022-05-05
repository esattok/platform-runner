using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveHorizontal : MonoBehaviour
{
    float speed = 100f;
    [SerializeField] float pos = -8.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveX(pos, 2.0f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    private void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * speed);
    }
}
