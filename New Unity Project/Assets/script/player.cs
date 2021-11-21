using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [Range(0f, 0.1f)] public float jumpAmount;
    public Rigidbody2D rb;
    public GameObject pause;
    public int count = 0;
    public bool flag = false;
    public bool flag1 = false;
    public static int bestScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bestScore< score.scoreAmount)
        {
            bestScore = score.scoreAmount;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += new Vector3(0, jumpAmount, 0);
            if (count == 0)
            {
                transform.Rotate(0, 0, 30);
                count+=1;
                flag = true;

            }
            flag1 = false;


        }
        else
        {
            if (count == 1 && flag)
            {
                transform.Rotate(0, 0, -30);
                flag = false;
                count = 0;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        flag1 = true;
        if (collision.gameObject.tag == "deathZone")
        {
            SceneManager.LoadScene("game over");

        }
        if (collision.gameObject.tag == "score" &&flag)
        {
            score.scoreAmount += 1;
            Debug.Log(score.scoreAmount);
        }
    }

    public void restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
