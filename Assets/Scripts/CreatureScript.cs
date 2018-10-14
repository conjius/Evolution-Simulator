using UnityEngine;

public class CreatureScript : MonoBehaviour
{
    public int Index;
    public float MoveSpeed;
    public int Level;
    public int Health;
    public Rigidbody Rb;
    private int _frameCounter;
    public bool IsFighting;
    public GameManagerScript GameManager;

    // Use this for initialization
    private void Awake()
    {
        GameManager = GameObject.Find("Game Manager")
            .GetComponent<GameManagerScript>();
        _frameCounter = 0;
    }


    // Update is called once per frame
    private void Update()
    {
        if (++_frameCounter < 60) return;
        _frameCounter = 0;
        Rb.AddForce(Random.insideUnitSphere * MoveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Creature")) return;
        if (other.gameObject.GetComponent<CreatureScript>().IsFighting) return;
        IsFighting = true;
        GameManager.Fight(gameObject, other.gameObject);
        IsFighting = false;
    }
}