using System.Numerics;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnRod : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Detector detector;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private RandomHook randomHook;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (spriteRenderer != null)
            spriteRenderer.enabled = false;

        if (randomHook == null)
            randomHook = FindObjectOfType<RandomHook>();

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
                if (randomHook != null)
                    StartCoroutine(randomHook.RandomTimerCoroutine());
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
    }
}
