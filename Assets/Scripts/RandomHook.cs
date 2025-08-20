using UnityEngine;
using System.Collections;

public class RandomHook : MonoBehaviour
{
    [SerializeField] private float minTime = 1f;
    [SerializeField] private float maxTime = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(RandomTimerCoroutine());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator RandomTimerCoroutine()
    {
        float waitTime = Random.Range(minTime, maxTime);
        Debug.Log($"Waiting for {waitTime} seconds...");
        yield return new WaitForSeconds(waitTime);

        // Action after timer completes
        Debug.Log("Random timer finished!");
        // Place your hook logic here

        
    }
}
