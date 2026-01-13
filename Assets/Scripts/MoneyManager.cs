using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private int maxChips;
    public int remainingChips;
    public int playersChips;
    public int bet;
    public TMPro.TextMeshProUGUI betAmount;
    public GameObject Call;
    public GameObject Stand;
    public GameObject Standby_Call;
    public GameObject Standby_Stand;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Call.SetActive(false);
        Stand.SetActive(false); 
        Standby_Call.SetActive(true);
        Standby_Stand.SetActive(true);
    }

    // Update is called once per frame

    public void Bet()
    {

    }


    public void BetUp(int scoreToAdd)
    {
        bet += scoreToAdd;
        if (bet > playersChips)
        {
            bet = playersChips;
        }
    }

    public void BetDown(int scoreToTake)
    {
        bet -= scoreToTake;
        if (bet < 0)
        {
            bet = 0;
        }

    }
    void Update()
    {
        betAmount.text = "" + bet;
        remainingChips = maxChips - playersChips;
    }
}
