using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float score;
    private PlayerController playerScriptController;

    public Transform startingPoint;
    public float lerpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        playerScriptController = GameObject.Find("Player").GetComponent<PlayerController>();
        score = 0;
        playerScriptController.gameOver = true;
        StartCoroutine(PlayIntro());
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScriptController.speedUp)
        {
            score += 2;
        }
        else
        {
            score += 1;
        }
        Debug.Log("Score: "+score);
    }

    IEnumerator PlayIntro()
    {
        Vector3 startPos = playerScriptController.transform.position;
        Vector3 endPos = startingPoint.position;
        float journerLength = Vector3.Distance(startPos,endPos);
        float startTime = Time.time;

        float distanceCovered = (Time.time - startTime) * lerpSpeed;
        float fractionOfJourney = distanceCovered / journerLength;

        playerScriptController.GetComponent<Animator>().SetFloat("Speed_Multiplier", 0.5f);

        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / journerLength;
            playerScriptController.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
            yield return null;
        }

        playerScriptController.GetComponent<Animator>().SetFloat("Speed_Multiplier", 1.0f);
        playerScriptController.gameOver = false;
    }
}
