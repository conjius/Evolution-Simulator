using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public float CreaturesMoveSpeed;
    public int NumberOfCreatures;
    public GameObject CreaturePrefab;
    private GameObject[] _creatures;

    // Use this for initialization
    private void Start()
    {
        _creatures = new GameObject[NumberOfCreatures];
        for (var i = 0; i < NumberOfCreatures; ++i)
        {
            _creatures[i] = Instantiate(
                CreaturePrefab,
                new Vector3(Random.Range(-10f, 10f),
                    Random.Range(1f, 5f),
                    Random.Range(-10f, 10f)),
                Quaternion.identity);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        for (var i = 0; i < NumberOfCreatures; ++i)
        {
            
        }
    }
}