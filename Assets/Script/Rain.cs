using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SocialPlatforms.Impl;

public class Rain : MonoBehaviour
{
    float size = 1.0f;
    int score = 1;
    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        PositionRandom();

        SetType();
    }

    private void SetType()
    {
        int type = Random.Range(1, 5); //최댓값은 포함이 안된다.

        renderer = GetComponent<SpriteRenderer>();
        if(type==1){
            size = 0.8f;
            score = 1;
            renderer.color = new Color(100 / 255f, 100 / 255f, 1f, 1f);
        }else if(type==2){
            size = 1.0f;
            score = 2;
            renderer.color = new Color(130 / 255f, 130 / 255f, 1f, 1f);
        }else if(type==3){
            size = 1.2f;
            score = 3;
            renderer.color = new Color(150 / 255f, 150 / 255f, 1f, 1f);
        }else if(type==4){
            size = 0.8f;
            score = -5;
            renderer.color = new Color(255 / 255.0f, 100.0f / 255.0f, 100.0f / 255.0f, 255.0f / 255.0f);
        }
    }

    private void PositionRandom()
    {
        float x = Random.Range(-2.4f, 2.4f);
        float y = Random.Range(3.0f, 5.0f);

        transform.position = new Vector3(x, y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")){
            Destroy(this.gameObject);
        }else if(other.gameObject.CompareTag("Player")){
            GameManager.Instance.AddSocre(score);
            Destroy(this.gameObject);
        }
    }
}
