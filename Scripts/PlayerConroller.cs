using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerConroller : MonoBehaviour
{
    public bool gameOver = false;
    public GameObject rollButton;

    public GameObject gameOverText;

    public int rolls = 100;
    public int madeLastRoll;

    public TextMeshProUGUI madeLastText;

    public TextMeshProUGUI rollsRemaining;
    public TextMeshProUGUI goldText;

    public int gold;
    public Pannels[] p;

    public GameObject leaderboard;

    private void Awake()
    {
        p = FindObjectsOfType<Pannels>();
        gameOverText.SetActive(false);
    }

    public void Roll()
    {
        if(rolls < 1)
        {
            rollsRemaining.text = "0";
            return;
        }
        madeLastRoll = 0;
        foreach(Pannels p in p)
        {
            madeLastRoll += p.Roll();
        }
        gold += madeLastRoll;
        madeLastText.text = madeLastRoll.ToString();

        rollsRemaining.text = rolls.ToString();
        goldText.text = gold.ToString();

        rolls--;

        if(rolls == 0)
        {
            End();
        }
    }

    private void Update()
    {
        goldText.text = gold.ToString();
    }

    void End()
    {
        leaderboard.SetActive(true);
        gameOverText.SetActive(true);
        Leaderboard.instance.SetLeaderboardEntry(gold);
    }

}
