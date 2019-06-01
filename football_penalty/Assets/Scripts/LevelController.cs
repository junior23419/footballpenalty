using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelController : MonoBehaviour
{
    public BallController ballController;
    int kickSequence;
    int[] scores;
    int[] shotsRemaining;
    public ScoreController[] scoreControllers;
    public Text winnerText;

    // Start is called before the first frame update
    void Start()
    {
        ResetLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetLevel()
    {
        winnerText.gameObject.SetActive(false);
        ballController.ResetPosition();
        shotsRemaining = new int[2] { 5, 5 };
        scores = new int[2] { 0, 0 };
        kickSequence = 0;
        foreach (ScoreController controller in scoreControllers)
            controller.Clear();
    }

    IEnumerator WaitToDeclareNoGoal()
    {
        yield return new WaitForSeconds(2F);
        OnPlayerFinishKicking(false);
    }

    public void OnPlayerStartKicking()
    {
        StartCoroutine("WaitToDeclareNoGoal");
    }

    public void OnPlayerFinishKicking(bool isGoal)
    {
        if (isGoal)
        {
            StopCoroutine("WaitToDeclareNoGoal");
            scores[kickSequence % 2] += 1;
        }
        scoreControllers[kickSequence % 2].AddOne(isGoal);
        shotsRemaining[kickSequence % 2] -= 1;
        kickSequence += 1;
        Debug.Log("score" + scores[0].ToString() +" "+ scores[1].ToString());
        ballController.ResetPosition();
        CheckIfTheGameIsEndable();
    }

    private void CheckIfTheGameIsEndable()
    {
        int scoreDiff = scores[0] - scores[1];
        if(scoreDiff > 0)
        {
            if(scoreDiff > shotsRemaining[1])
            {
                //end P1 wins
                GameIsDone("Liverpool");
            }
        }
        else if(scoreDiff < 0)
        {
            scoreDiff *= -1;
            if (scoreDiff > shotsRemaining[0])
            {
                //end P2 wins
                GameIsDone("Tottenham Hotspur");
            }
        }
        else if(shotsRemaining[1] <=0)
        {
            shotsRemaining[0] += 1;
            shotsRemaining[1] += 1;
        }
    }

    private void GameIsDone(string winner)
    {
        winnerText.text = winner +  " wins";
        winnerText.gameObject.SetActive(true);
        ballController.SetFootballControlStatus(false);
    }
}
