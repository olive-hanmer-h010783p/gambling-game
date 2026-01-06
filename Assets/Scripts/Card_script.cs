using UnityEngine;

public class Card_script : MonoBehaviour
{
    private string cardsuit;
    private string cardvalue;
    private string currentcard;

    // creates a blank hand for the player with 15 spaces as that is the max hand available without going over 21
    private string[] cardsinhand = { "N/A", "N/A", "N/A", "N/A", "N/A"};
    // variable which holds current hand value
    private int currentscore;
    // this does the same as the player class just for the dealer
    private string[] dealercardsinhand = { "N/A", "N/A", "N/A", "N/A", "N/A"};
    private int dealercurrentscore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    int cardmaker(string[] handcard)
    {
        int score = 0;

        for (int i = 0; i < 2; i++)
        {
            // random variable which allows for the card value to be chosen between 0 and 11 if 0 the card is an ace
            int card = Random.Range(1, 13);


            int suit = Random.Range(0, 3);
            switch (suit)
            {
                case 0:
                    cardsuit = "hearts";
                    break;

                case 1:
                    cardsuit = "diamonds";
                    break;

                case 2:
                    cardsuit = "spades";
                    break;

                case 3:
                    cardsuit = "clubs";
                    break;

                //speeve
                default:
                    cardsuit = "speeve";
                    break;
            }

            switch (card)
            {
                case 1:
                    cardvalue = "Ace";
                    if (score + 11 > 21)
                    {
                        score += 1;
                    }
                    else
                    {
                        score += 11;
                    }
                    break;

                case 11:
                    cardvalue = "Jack";
                    score += 10;
                    break;

                case 12:
                    cardvalue = "Queen";
                    score += 10;
                    break;

                case 13:
                    cardvalue = "King";
                    score += 10;
                    break;

                default:
                    cardvalue = card.ToString();
                    score += card;
                    break;
            }
            currentcard = cardvalue + " of " + cardsuit;
            handcard[i] = currentcard;
            Debug.Log(card);
        }
        return score;

    }

    void Start()
    {
            currentscore = cardmaker(cardsinhand);
            dealercurrentscore = cardmaker(dealercardsinhand);

            Debug.Log(cardsuit);
            Debug.Log(currentscore + " score");
            Debug.Log(cardsinhand[0]);
            Debug.Log(cardsinhand[1]);
            Debug.Log(cardsuit + " dealer");
            Debug.Log(dealercurrentscore + " score" + " dealer");
            Debug.Log(dealercardsinhand[0] + " dealer");

    }
    
    
    void call()
    {

    }

    void stand()
    {

    }

}