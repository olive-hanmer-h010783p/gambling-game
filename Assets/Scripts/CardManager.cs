using UnityEngine;

public class CardManager : MonoBehaviour
{
    //these are the locations where the cards will spawn for the player and dealer
    public GameObject[] spawnLocationsPlayer;
    public GameObject[] spawnLocationsDealer;
    // this is where the deck will be located
    public Transform deckLocation;

    // this is what the cards' prefabs are so the code can take them and spawn them in the game
    public GameObject[] cardPrefabs;
    public GameObject hiddenCardPrefab;

    void OnMouseDown()
    {
        Debug.Log("Creating A New Card...");
        //Creates a new card
        GameObject spawnedProjectile = Instantiate(cardPrefabs[0], deckLocation.position, Quaternion.identity);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
