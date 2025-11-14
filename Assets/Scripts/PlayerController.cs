using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Game-wise concepts
    public bool isGameOver;

    // Audio
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource sfxAudioSource;
    public AudioSource musicAudioSource;

    // Own animations and body
    private Rigidbody body;
    public float jumpForce;
    public float gravityFactor;
    private bool isOnGround;    
    private Animator animator;

    // Particles
    public ParticleSystem explosionParticles;
    public ParticleSystem jumpParticles;
    public ParticleSystem dirtParticles;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Physics.gravity *= gravityFactor;
        isOnGround = true;
        isGameOver = false;
        sfxAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!isGameOver && isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump_trig");
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            jumpParticles.Play();
            dirtParticles.Stop();
            sfxAudioSource.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidingObject = collision.gameObject;
        if (collidingObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            animator.SetBool("Death_b", true);
            int deathType = Random.Range(1, 3);
            animator.SetInteger("DeathType_int", deathType);
            Debug.Log("GAME OVER!");
            explosionParticles.Play();
            dirtParticles.Stop();
            sfxAudioSource.PlayOneShot(crashSound, 1.0f);
            musicAudioSource.Stop();
        } 
        else if (collidingObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticles.Play();
        }
    }
}
