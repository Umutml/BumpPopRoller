using Cinemachine;
using UnityEngine;

public class MainBall : MonoBehaviour
{
    Rigidbody ballRb;
    private AudioSource GameAudio;
    [SerializeField] float startForce;
    public CinemachineVirtualCamera vcam;
    private void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        GameAudio = GameObject.Find("GameManager").GetComponentInChildren<AudioSource>();
    }
    void Update()
    {
        Starter();
        CenterizeForce();
    }
    void Starter()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.instance.canStart)
        {
            ballRb.isKinematic = false;
            ballRb.AddForce(Vector3.forward * startForce);
            GameManager.instance.canStart = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.tag = "Touched";
            vcam.Follow = collision.transform; // Camera Target Changed
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            vcam.Follow = collision.gameObject.transform;
            
            for (int i = 0; i < GameManager.instance.SpawnCount; i++) // Taking clone count from gamemanager
            {
                GameManager.instance.activeBall++;
                GameObject cloneBall = Instantiate(collision.gameObject, collision.transform.position, Quaternion.identity);
                Rigidbody clonerb = cloneBall.GetComponent<Rigidbody>();
                clonerb.AddExplosionForce(GameManager.instance.expForce, transform.position, 10f, 0, ForceMode.Impulse);
            }
            GameAudio.Play();
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        ballRb.AddForce(Vector3.forward * GameManager.instance.constForce); // First ball
    }
    private void CenterizeForce()
    {
        if (transform.position.x >= 12.5f)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.left * 20);
        }
        if (transform.position.x <= -12.5f)                                 // If balls go left or right boundries add force to middle           
        {
            GetComponent<Rigidbody>().AddForce(Vector3.right * 20);
        }
    }
}
