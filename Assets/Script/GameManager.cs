using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject rain;
    public GameObject endPanel;
    public Text totalScoreTxt;
    public Text timeText;
    int totlaScore;

    float totalTime = 30.0f;
    private void Awake(){
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeRain",0,1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(totalTime>0f){
            totalTime -= Time.deltaTime;
        }else{
            totalTime=0f;
            endPanel.SetActive(true);
            Time.timeScale=0f;
        }
        timeText.text = totalTime.ToString("N2");
    }

    void MakeRain(){
        Instantiate(rain);
    }

    public void AddSocre(int score){
        totlaScore += score;
        totalScoreTxt.text = totlaScore.ToString();
    }
}
