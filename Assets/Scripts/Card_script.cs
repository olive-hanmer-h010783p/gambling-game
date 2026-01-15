using UnityEngine;

public class Card_script : MonoBehaviour
{
    private string cardsuit;
    private string cardvalue;
    private string currentcard;
    private bool acereduced = false;
    public bool standing = false;
    public MoneyManager M_Moneymanager;

    // creates a blank hand for the player with 15 spaces as that is the max hand available without going over 21
    private string[] cardsinhand = { "N/A", "N/A", "N/A", "N/A", "N/A"};
    // variable which holds current hand value
    private int currentscore;
    // this does the same as the player just for the dealer
    private string[] dealercardsinhand = { "N/A", "N/A", "N/A", "N/A", "N/A"};
    private int dealercurrentscore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void start()
    {
        currentscore += currentscore = cardmaker(cardsinhand);
        currentscore += currentscore = cardmaker(cardsinhand);
        dealercurrentscore += dealercurrentscore = cardmaker(dealercardsinhand);
        dealercurrentscore += dealercurrentscore = cardmaker(dealercardsinhand);
        Debug.Log("you have " + cardsinhand[0] + " " + cardsinhand[1] + " " + cardsinhand[2] + " " + cardsinhand[3] + " " + cardsinhand[4]);
        Debug.Log(currentscore);
        Debug.Log("the dealer has a " + dealercardsinhand[0]);
    }

    int cardmaker(string[] handcard)
    {
        int score = 0;

        // random variable which allows for the card value to be chosen between 1 and 13 if 1 the card is an ace
        int card = Random.Range(1, 13);

        // randomised the suit of the card so that it isnt just numbers
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

            //We am speeve
            default:
                cardsuit = "speeve";
                break;
        }

        //checks for specialised cards so that it can disply the cards properly in hand
        switch (card)
        {
            case 1:
                cardvalue = "Ace";
                if (score + 11 > 21)
                {
                    score += 1;
                    acereduced = true;
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

        

        //create the tag for the card to hold within the players hand.(will help with the prefabs for cards later
        currentcard = cardvalue + " of " + cardsuit;
        // go my chud i
        for (int i = 0; i < 5; i++)
        {
            if (handcard[i] == "N/A")
            {
                handcard[i] = currentcard;
                i = 5;
            }
        }

        if (currentscore == 21)
        {
            Debug.Log("I win YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY");
            for (int i = 0; i < 5; i++)
            {
                cardsinhand[i] = "N/A";
                dealercardsinhand[i] = "N/A";
                currentscore = 0;
                dealercurrentscore = 0;
                acereduced = false;
                standing = false;
            }
            M_Moneymanager.bet = M_Moneymanager.bet * 2;
            M_Moneymanager.playersChips = M_Moneymanager.bet;
            M_Moneymanager.Start();

        }
        return score;
    }

    public void call()
    {
        Debug.Log("Prick.");
        if (cardsinhand[4] == "N/A" && currentscore < 21 && standing == false)
        {
            currentscore += currentscore = cardmaker(cardsinhand);
        }

        // checks list for an ace in hand as if there is an ace it can change it to low ace.
        for (int i = 0; i < 5; i++)
        {
            if (cardsinhand[i] == "Ace of hearts" && currentscore > 21 && acereduced == false || cardsinhand[i] == "Ace of diamonds" && currentscore > 21 && acereduced == false || cardsinhand[i] == "Ace of spades" && currentscore > 21 && acereduced == false || cardsinhand[i] == "Ace of clubs" && currentscore > 21 && acereduced == false)
            {
                currentscore = currentscore - 10;
                acereduced = true;
            }
        }

        Debug.Log("you have " + cardsinhand[0] + " " + cardsinhand[1] + " " + cardsinhand[2] + " " + cardsinhand[3] + " " + cardsinhand[4]);
        Debug.Log(currentscore);

        if (currentscore > 21)
        {
            Debug.Log("you have busted and failed your game");
            for (int i = 0; i < 5; i++)
            {
                cardsinhand[i] = "N/A";
                dealercardsinhand[i] = "N/A";
                currentscore = 0;
                dealercurrentscore = 0;
                acereduced = false;
                standing = false;
            }
            M_Moneymanager.playersChips -= M_Moneymanager.bet;
            M_Moneymanager.Start();
        }

        if (currentscore <= 21 && cardsinhand[4] != "N/A")
        {
            Debug.Log("you got a 5 card hand well done");

            for (int i = 0; i < 5; i++)
            {
                cardsinhand[i] = "N/A";
                dealercardsinhand[i] = "N/A";
                currentscore = 0;
                dealercurrentscore = 0;
                acereduced = false;
                standing = false;
            }
            M_Moneymanager.bet = M_Moneymanager.bet * 2;
            M_Moneymanager.playersChips = M_Moneymanager.bet;
            M_Moneymanager.Start();
        }
    }

    public void stand()
    {
        acereduced = false;
        Debug.Log(dealercardsinhand[0] + " " + dealercardsinhand[1]);

        if (dealercurrentscore < 16)
        {
            dealercurrentscore += dealercurrentscore = cardmaker(dealercardsinhand);
            Debug.Log("the dealers hand is " + dealercardsinhand[0] + " " + dealercardsinhand[1] + " " + dealercardsinhand[2] + " " + dealercardsinhand[3] + " " + dealercardsinhand[4]);
            Debug.Log("Dealer Score: " + dealercurrentscore);
            // checks list for an ace in dealers hand as if there is an ace it can change it to low ace.
            for (int i = 0; i < 5; i++)
            {
                if (dealercardsinhand[i] == "Ace of hearts" && dealercurrentscore > 21 && acereduced == false || dealercardsinhand[i] == "Ace of diamonds" && dealercurrentscore > 21 && acereduced == false || dealercardsinhand[i] == "Ace of spades" && dealercurrentscore > 21 && acereduced == false || dealercardsinhand[i] == "Ace of clubs" && dealercurrentscore > 21 && acereduced == false)
                {
                    dealercurrentscore = dealercurrentscore - 10;
                    acereduced = true;
                }
            }
            stand();
        }
        else
        {
            if (dealercurrentscore > 21 || dealercurrentscore < currentscore)
            {
                Debug.Log("the dealer has been beat and you win");
                for (int i = 0; i < 5; i++)
                {
                    cardsinhand[i] = "N/A";
                    dealercardsinhand[i] = "N/A";
                    currentscore = 0;
                    dealercurrentscore = 0;
                    acereduced = false;
                    standing = false;
                }
                M_Moneymanager.bet = M_Moneymanager.bet * 2;
                M_Moneymanager.playersChips = M_Moneymanager.bet;
                M_Moneymanager.Start();
            }
            else if (dealercurrentscore == currentscore)
            {
                Debug.Log("draw you get your bet back");
                for (int i = 0; i < 5; i++)
                {
                    cardsinhand[i] = "N/A";
                    dealercardsinhand[i] = "N/A";
                    currentscore = 0;
                    dealercurrentscore = 0;
                    acereduced = false;
                    standing = false;
                }
                M_Moneymanager.Start();
            }
                

            else
            {
                Debug.Log("you lose");
                for (int i = 0; i < 5; i++)
                {
                    cardsinhand[i] = "N/A";
                    dealercardsinhand[i] = "N/A";
                    currentscore = 0;
                    dealercurrentscore = 0;
                    acereduced = false;
                    standing = false;
                }
                M_Moneymanager.playersChips -= M_Moneymanager.bet;
                M_Moneymanager.Start();
            }
        }
    }
}