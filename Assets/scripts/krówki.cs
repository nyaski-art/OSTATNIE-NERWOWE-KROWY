using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class krówki : MonoBehaviour
{
    public TextMeshProUGUI textsecretWord;
    public TextMeshProUGUI textwordLength;
    public TextMeshProUGUI textLivesCounter;
    public string secretWord = "hello";
    public int playerLives = 3;
    public void OnButtonClick(TMP_InputField input)
    {
        if (playerLives <= 0)
        {
            return;
        }
        if (input.text == secretWord)
        {
            Win();
            return;

        }
        //Debug.Log("input was: " + input.text);
        if (secretWord.Length != input.text.Length)
        {
            removeLife();
            Debug.Log("wrong Length, try again");
            textsecretWord.text = "wrong, kys, try again";
        }
        else 
        { 
            int bulls = CountBulls(secretWord, input.text);
            int cows = CountCows(secretWord, input.text);

            textsecretWord.text = "Bulls: " + bulls + "Cows: " + cows + " Try Again";
        }
        input.text = "";
    }
    public int CountBulls(string origin, string guess)
    {
        int bullsCount = 0;
        for (int i = 0; i < origin.Length; i++)
        {
            if (origin[i] == guess[i])
            {
                bullsCount++;
            }
        }
        return bullsCount;
    }
    public int CountCows(string origin, string guess)
    {
        int cowsCount = 0;
        for (int i = 0; i < origin.Length; i++)
        {
            if (origin.Contains(guess[i] + "") && origin[i] != guess[i])
            { cowsCount++; }
        }
        return cowsCount;
    }
    public void removeLife()
    {
        playerLives--;
        textLivesCounter.text = "U have" + playerLives + " lives left";
        if (playerLives <= 0)
        {
            textsecretWord.text = "the word was: " + secretWord;
            textwordLength.text = "Game Over";
            textLivesCounter.text = "you have no lives left";
        }
    }

    public void Win()
{
    textsecretWord.text = "The word was: " + secretWord;
    textwordLength.text = "Bravo!";
    textLivesCounter.text = "You have" + playerLives + "lives left";
}

    // Start is called before the first frame update
    void Start()
    {
       
        textsecretWord.text = "the secret word is [" + secretWord + "]";
        textwordLength.text = "The length of secret word is" + secretWord.Length;
        textLivesCounter.text = "you have " + playerLives + "lives left";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
