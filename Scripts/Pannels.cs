using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Pannels : MonoBehaviour
{
    [Header("Text Objects")]
    public TextMeshProUGUI buttonText;
    public TextMeshProUGUI rollText;
    public TextMeshProUGUI id;

    [Header("Images")]
    public Image spinner;
    public Sprite[] diceFaces;

    [Header("Variables")]
    public int diceLevel;
    public int position;
    public int min = 0;
    public int max = 1;

    [Header("Objects")]
    public PlayerConroller pc;


    public void updateUI()
    {
        switch (diceLevel) 
        {
            case 0:
                buttonText.text = $"Unlock: {(position * 10)}";
                rollText.text = "";
                id.text = "Locked";
                min = 0;
                max = 0;
                break;
            case 1:
                buttonText.text = $"Upgrade: {(diceLevel + 1) * (position * 10)}";
                rollText.text = "1";
                id.text = "Coin";
                min = 0;
                max = 1;
                break;
            case 2:
                buttonText.text = $"Upgrade: {(diceLevel + 1) * (position * 10)}";
                rollText.text = "4";
                id.text = "D4";
                min = 1;
                max = 4;
                break;
            case 3:
                buttonText.text = $"Upgrade: {(diceLevel + 1) * (position * 10)}";
                rollText.text = "6";
                id.text = "D6";
                min = 1;
                max = 6;
                break;
            case 4:
                buttonText.text = $"Upgrade: {(diceLevel + 1) * (position * 10)}";
                rollText.text = "8";
                id.text = "D8";
                min = 1;
                max = 8;
                break;
            case 5:
                buttonText.text = $"Upgrade: {(diceLevel + 1) * (position * 10)}";
                rollText.text = "10";
                id.text = "D10";
                min = 1;
                max = 10;
                break;
            case 6:
                buttonText.text = $"Upgrade: {(diceLevel + 1) * (position * 10)}";
                rollText.text = "12";
                rollText.color = Color.white;
                id.text = "D12";
                min = 1;
                max = 12;
                break;
            case 7:
                buttonText.text = $"Upgrade: {(diceLevel + 1) * (position * 10)}";
                rollText.text = "20";
                rollText.color = Color.white;
                id.text = "D20";
                min = 1;
                max = 20;
                break;
            case 8:
                buttonText.text = "Maxed Out";
                buttonText.GetComponentInParent<Button>().interactable = false;
                rollText.text = "100";
                rollText.color = Color.white;
                id.text = "D100";
                min = 1;
                max = 100;
                break;
        }
        spinner.sprite = diceFaces[diceLevel];
    }



    public int Roll()
    {
        int result = Random.RandomRange(min, (max + 1));
        Debug.Log(result);
        if (diceLevel > 0)
        {
            rollText.text = result.ToString();
        }
        
        return result;
    }

    public void Upgrade()
    {
        if (pc.gold >= ((diceLevel + 1) * (position * 10)) && diceLevel < 8)
        {
            pc.gold -= ((diceLevel + 1) * (position * 10));
            diceLevel++;
            pc.goldText.text = pc.gold.ToString();
            updateUI();
        }
        else
        {
            StartCoroutine("fade");
        }
    }

    IEnumerator fade()
    {
        float elapsedTime = 0;
        float waitTime = 3f;

        while (elapsedTime < waitTime)
        {
            buttonText.color = Color.Lerp(Color.black, Color.red, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        updateUI();
        // Make sure we got there
        yield return null;
    }



    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<PlayerConroller>();
        updateUI();
    }

}
