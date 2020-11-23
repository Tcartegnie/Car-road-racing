using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDebugger : MonoBehaviour
{
    public Score score;
    public DifficultyManager difficulty;
    [Space]
    public Text DiffcultyDisplayer;

    // Update is called once per frame
    void Update()
    {
        DiffcultyDisplayer.text = difficulty.GetDifficulty().ToString();
        if(Input.GetKeyDown(KeyCode.U))
		{
            score.SetScore(980);

        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            score.SetScore(1980);

        }
    }
}
