using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DZscript : MonoBehaviour
{
    public GameObject newBall;
    public int counter = 0;
    public Image ball1;
    public Image ball2;
    public Image ball3;
    public GameObject GameUI;
    public GameObject GameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

 
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Rigidbody>().CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
            Instantiate(newBall);
            counter++;
        }

        switch(counter){
            case 1:
                ball1.GetComponent<Image>().color = new Color32(255,255,225,100);
                break;
            case 2:
                ball2.GetComponent<Image>().color = new Color32(255,255,225,100);
                break;
            case 3:
                ball3.GetComponent<Image>().color = new Color32(255,255,225,100);
                GameUI.SetActive(false);
                GameOverUI.SetActive(true);

                if(Input.GetKeyDown(KeyCode.R)){
                    SceneManager.LoadScene("Level01");
                }
                break;
            default:
                break;
        }


    }
}
