using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
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
                new Vector3(Random.Range(-40f, 40f),
                    Random.Range(10f, 90f),
                    Random.Range(-40f, 40f)),
                Quaternion.identity);
            _creatures[i].GetComponent<CreatureScript>().Index = i;
        }
    }

    private static void Win(GameObject winner, GameObject loser)
    {
        Destroy(loser);
        var winnerScript = winner.GetComponent<CreatureScript>();
        winnerScript.Level++;
        winner.transform.localScale =
            new Vector3(winner.transform.localScale.x *1.1f,
                winner.transform.localScale.y *1.1f,
                winner.transform.localScale.z *1.1f);
        winnerScript.Rb.mass*=1.33f;
    }

    public void Fight(GameObject creature1, GameObject creature2)
    {
        var script1 = creature1.GetComponent<CreatureScript>();
        var script2 = creature2.GetComponent<CreatureScript>();
        if (script1.Level == script2.Level)
        {
            var winner = Random.Range(1, 3);
            switch (winner)
            {
                case 1:
                    Win(creature1, creature2);
                    break;
                case 2:
                    Win(creature2, creature1);
                    break;
                default:
                    Win(creature2, creature1);
                    break;
            }
        }
        else
        {
            var winner = script1.Level > script2.Level ? 1 : 2;
            switch (winner)
            {
                case 1:
                    Win(creature1, creature2);
                    break;
                case 2:
                    Win(creature2, creature1);
                    break;
                default:
                    Win(creature2, creature1);
                    break;
            }
        }
    }
}