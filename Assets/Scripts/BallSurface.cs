using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallSurface : MonoBehaviour
{
    public GameObject floor;
    public float score = 0f;
    public float HighScore = 0f;
    public TMP_Text displyTxt;
    public TMP_Text HighestScore;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0.1f, 0, 0.1f);
        if (displyTxt == null)
        {
            displyTxt = GameObject.FindWithTag("ScoreDisplay")
                .GetComponent<TMP_Text>();
        }

        if (HighestScore == null)
        {
            HighestScore = GameObject.FindWithTag("HighScore")
                .GetComponent<TMP_Text>();
        }

        HighestScore.text = "HighestScore: " + PlayerPrefs.GetFloat("HighScore"); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position.Set(0,
            floor.transform.position.y + 0.17501f
            , 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        score += collision.gameObject
            .GetComponent<BounceBackBumper>().value;

        displyTxt.text = "Score: " + score;

        if(score > PlayerPrefs.GetFloat("HighScore", 0)){
            //PlayerPrefs.GetFloat("HighScore");
            PlayerPrefs.SetFloat("HighScore", score); 
        };
    }
}
