using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 vec2;
    [SerializeField]
    private float flapPow = 350f;//?H??????????
    private string killZoneTag = "KillZone";
    private bool fallingFlag = false;

    // Audio
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip playerJumpAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        vec2 = new Vector2(0f, flapPow);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.IsPause)
        {
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            return;
        }
        else { rb.isKinematic = false; }

        if (!fallingFlag)
        {
            if (Input.GetKeyDown("space"))//?X?y?[?X?L?[????????????
            {
                rb.velocity = Vector2.zero;//?v???C???[?????x????????
                rb.AddForce(vec2);//????
                audioSource.PlayOneShot(playerJumpAudioClip);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == killZoneTag)
        {
            GameManager.instance.isDead = true;
        }
    }

    public void FallPlayer()
    {
        fallingFlag = true;
    }
}
