using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public static gameController Instance;

    public GameObject Enemy;

    public Text scoreText;

    private int score = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Score: {score}";
    }

    public void OnKill()
    {
        score++;
        Instantiate(Enemy, transform.position + new Vector3(Random.Range(-1, 1), -1 ,Random.Range(-1, 1)), Quaternion.identity);
        Instantiate(Enemy, transform.position + new Vector3(Random.Range(-1, 1), -1, Random.Range(-1, 1)), Quaternion.identity);
    }
}
