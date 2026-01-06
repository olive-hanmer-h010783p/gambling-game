using UnityEngine;

public class CardMovement : MonoBehaviour
{
    [SerializeField] private Transform goal;
    [SerializeField] private float speed;

    private Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Sets the card to move towards the place where it wants to be (Five nights at freddys)

        goal = GameObject.Find("1").GetComponent<Transform>();
        target = goal;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
