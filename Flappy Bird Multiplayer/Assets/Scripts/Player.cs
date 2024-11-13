using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    const float jumpForce = 8;
    new Rigidbody2D rigidbody2D;
    UIManager managerUI;


    string[] powerUps = { "Shield" };

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        managerUI = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            rigidbody2D.velocity = Vector3.zero;
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            GameOver();

           
        }
        else if(collision.gameObject.tag == "Score")
        {
            GameManager.instance.Score++;
            managerUI.UpdateScoreText();

    
          
        }

        else if(collision.gameObject.tag == "powerUp")
        {
            ActivatePowerUp();
            
            Destroy(collision.gameObject);
        }
        
    }

    void GameOver()
    {
        
        if(PlayerPrefs.GetInt("Record") < GameManager.instance.Score)
        {
            PlayerPrefs.SetInt("Record", GameManager.instance.Score);
        }
        managerUI.GameOver();
       
    
        
    }

    void ActivatePowerUp()
    {

       int powerUpIndex = Random.Range(0, powerUps.Length);
        string powerUp = powerUps[powerUpIndex];
        Debug.Log("Power - up ativado:" + powerUp);

        switch(powerUp)
        {
            case "Shield":
                StartCoroutine(ActivateShield());

            break;
        }
    }

    IEnumerator ActivateShield()
    {
        Debug.Log("Escudo ativado");
        yield return new WaitForSeconds(1);
        Debug.Log("Escudo desativado");
    }
}
