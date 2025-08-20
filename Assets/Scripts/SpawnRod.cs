using System.Numerics;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnRod : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Detector detector;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private float minTime = 1f;
    [SerializeField] private float maxTime = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (spriteRenderer != null)
            spriteRenderer.enabled = false;


        detector = FindObjectOfType<Detector>();
        playerMovement = FindObjectOfType<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rod(InputAction.CallbackContext context)
    {
        if (context.performed && spriteRenderer != null)
        {
            if (playerMovement != null)
            {
                playerMovement.canMove = false; // Disable player movement while fishing
            }

            if(detector.overWater)
            {
                //Start fishing action
                //randomhook
                Debug.Log("Rod action performed");
                spriteRenderer.enabled = !spriteRenderer.enabled;
                StartCoroutine(RandomTimerCoroutine());
            }
            else
            {
                //start dumbass fishing animation
                Debug.Log("Rod action performed unsuccesfully");
                spriteRenderer.enabled = !spriteRenderer.enabled;
                StartCoroutine(SetTimerCoroutine());
            }

        }

        spriteRenderer.enabled = spriteRenderer.enabled;
    }

    private IEnumerator SetTimerCoroutine()
    {
        yield return new WaitForSeconds(1f); // Wait for 1 second

        // Action after timer completes
        Debug.Log("1 second timer finished!");
        if (playerMovement != null)
            playerMovement.canMove = true; // Re-enable player movement
        // Add any other logic you want to trigger after 1 second here
        spriteRenderer.enabled = !spriteRenderer.enabled;
    }

    public IEnumerator RandomTimerCoroutine()
    {
        float waitTime = Random.Range(minTime, maxTime);
        Debug.Log($"Waiting for {waitTime} seconds...");
        yield return new WaitForSeconds(waitTime);

        // Action after timer completes
        Debug.Log("Random timer finished!");
        // Place your hook logic here
        spriteRenderer.enabled = !spriteRenderer.enabled;
        if (playerMovement != null)
            playerMovement.canMove = true;
    }
}
