using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int blueScore = 0, redScore = 0;
    public Text BlueScoreCounter;
    public Text RedScoreCounter;

    private void Update()
    {
        BlueScoreCounter.text = "" + blueScore;
        RedScoreCounter.text = "" + redScore;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BlueGate") redScore++;
        if (collision.tag == "RedGate") blueScore++;
    }
}
