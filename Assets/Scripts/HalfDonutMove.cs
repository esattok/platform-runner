using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HalfDonutMove : MonoBehaviour
{
    float pos = -0.88f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HalfDonutSequence());
    }

    IEnumerator HalfDonutSequence()
    {
        while (true)
        {
            transform.DOLocalMoveX(pos, 1.0f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.InOutSine);
            yield return new WaitForSeconds(Random.Range(3, 6));
            
        }
    }
}
