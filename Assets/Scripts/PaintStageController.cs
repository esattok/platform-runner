using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using TMPro;

public class PaintStageController : MonoBehaviour
{

    [SerializeField] Camera cam;
    [SerializeField] GameObject cursor;
    [SerializeField] Animator animator;
    [SerializeField] RankingController rankingController;
    [SerializeField] TMP_Text percText;
    [SerializeField] ColorMatchController colorMatchController;
    [SerializeField] float checkPercInterval = 0.25f;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<Player>();


        if (player)
        {
            rankingController.CalculateRanking();
            rankingController.gameObject.SetActive(false);

            cam.GetComponent<CinemachineBrain>().enabled = false;
            cam.orthographic = true;
            cam.orthographicSize = 15;
            cam.transform.position = new Vector3(0.11f, -4.7f, 433.2f);
            cam.transform.eulerAngles = new Vector3(0, 0, 0);

            cursor.transform.position = new Vector3(0, -4.5f, 462);

            player.transform.position = new Vector3(6.74f, -6.97f, 444.84f);
            player.transform.eulerAngles = new Vector3(0, -70f, 0);
            player.IsMoving = false;
            animator.SetTrigger("PaintStage");

            percText.gameObject.SetActive(true);

            var opponents = FindObjectsOfType<Opponent>();
            foreach (var opponent in opponents)
            {
                opponent.DisableCharacter();
                opponent.gameObject.SetActive(false);
            }

            colorMatchController.InvokeRepeating("CalculateColorMatchPercentage", 0, checkPercInterval);
        }

        else if (other.GetComponent<Opponent>())
        {
            other.transform.position += transform.forward;
            other.GetComponent<Opponent>().DisableCharacter();
        }


    }
}
