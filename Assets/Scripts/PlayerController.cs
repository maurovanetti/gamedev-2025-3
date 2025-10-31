using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody body;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.AddForce(Vector3.up * 1000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
