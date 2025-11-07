using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float leftBound = -15.0f;
    public float speed; // m/s
    private PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Shift leftward
        if (playerController.isGameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        // Destroy if obstacle goes out of left bound
        if (transform.position.x < leftBound 
            && CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
