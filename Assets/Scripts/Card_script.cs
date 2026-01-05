using UnityEngine;

public class Card_script : MonoBehaviour
{
    private string cardsuit;
    private string cardvalue;
    private string currentcard;

    // creates a blank hand for the player with 15 spaces as that is the max hand available without going over 21
    private string[] cardsinhand = { "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
    // variable which holds current hand value
    private int currentscore;
    // this does the same as the player class just for the dealer
    private string[] dealercardsinhand = { "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A" };
    private int dealercurrentscore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            // random variable which allows for the card value to be chosen between 0 and 11 if 0 the card is an ace
            int card = Random.Range(0, 13);
            currentscore += card;

            int suit = Random.Range(0, 3);
            if (suit == 0)
            {
                cardsuit = "hearts";
            }
            else if (suit == 1)
            {
                cardsuit = "diamonds";
            }
            else if (suit == 2)
            {
                cardsuit = "spades";
            }
            else if (suit == 3)
            {
                cardsuit = "clubs";
            }

            Debug.Log(card);
            Debug.Log(cardsuit);
            Debug.Log(currentscore + " score");

        }
    }
    
}