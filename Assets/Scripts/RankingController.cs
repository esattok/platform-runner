using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankingController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform[] opponents;
    [SerializeField] float checkInterval = 0.5f;
    [SerializeField] TMP_Text rankText;
    int rank;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(CalculateRanking), 0, checkInterval);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void CalculateRanking()
    {
        rank = 1;

        for (int i = 0; i < opponents.Length; i++)
        {
            if (opponents[i].position.z > player.position.z)
            {
                rank++;
            }
        }

        rankText.SetText("Rank: " + rank);
    }
}
