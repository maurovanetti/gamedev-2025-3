using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Vector3 spawnPosition;
    public float delay; // seconds
    public float period; // seconds
    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", delay, period);
    }

    void SpawnObstacle()
    {
        if (playerController.isGameOver == false)
        {
            Instantiate(
                obstaclePrefab,
                spawnPosition,
                obstaclePrefab.transform.rotation
                );
        }
    }

    void Update()
    {

    }
}
