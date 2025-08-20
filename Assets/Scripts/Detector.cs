using UnityEngine;
using UnityEngine.Tilemaps;

public class Detector : MonoBehaviour
{
    public GameObject interactionIcon;
    public bool overWater = false; // Assuming this is set elsewhere in your code
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactionIcon.SetActive(false); // Initially hide the interaction icon
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<TilemapCollider2D>() != null)
        {
            Debug.Log("Tilemap Collider 2D detected within radius!");
            // Add your interaction logic here
            overWater = true; // Set overWater to true when a Tilemap Collider 2D enters the trigger
            interactionIcon.SetActive(true); // Show the interaction icon when a Tilemap Collider 2D enters the trigger
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<TilemapCollider2D>() != null)
        {
            Debug.Log("Tilemap Collider 2D exited radius!");
            // Add your exit logic here
            overWater = false; // Set overWater to false when a Tilemap Collider 2D exits the trigger
            interactionIcon.SetActive(false); // Hide the interaction icon when a Tilemap Collider 2D exits the trigger
        }
    }
}
