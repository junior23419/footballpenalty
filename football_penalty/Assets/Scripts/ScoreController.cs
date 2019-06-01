using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour
{
    private List<Image> scores;
    private int firstReadySlot;
    Color white;
    Color black;
    Color green;
    // Start is called before the first frame update
    void Start()
    {
        white = new Color(255, 255, 255);
        black = new Color(0, 0, 0);
        green = new Color(0, 255, 0);
        scores = new List<Image>();
        foreach (Transform child in transform)
            scores.Add(child.gameObject.GetComponent<Image>());
        Clear();
    }

    public void Clear()
    {
        firstReadySlot = 0;
        foreach(Image score in scores)
        {
            score.color = white;
        }
    }

    public void AddOne(bool isGoal)
    {
        if(firstReadySlot == 5)
        {
            Clear();
        }
        scores[firstReadySlot].color = isGoal ? green : black;
        firstReadySlot += 1;

    }
}
