using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerrb;
    private Animator playerAnimation;
    private AudioSource actionSound;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpforce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerrb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnimation = GetComponent<Animator>();
        actionSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerrb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimation.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            actionSound.PlayOneShot(jumpSound, 1.0f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            gameOver = true;
            playerAnimation.SetBool("Death_b", true);
            playerAnimation.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            actionSound.PlayOneShot(crashSound, 1.0f);

        }
    }
}
