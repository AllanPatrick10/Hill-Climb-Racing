using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOver;
    public Player player;

    public Text coinTxt;
    public int totalCoin;

    public Transform playerPosition;
    public Vector2 initialDistance;
    public Text distanceTxt;

     void Start()
    {
        ValueConvert();
        initialDistance = playerPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        GameOverActive();
        ValueConvert();
        DistanceCalculation();
    }

    // FIM DO JOGO
    void GameOverActive()
    {
        if(player.gasoline <= 0) // se a gasolina do player acabar <= 0
        {
            StartCoroutine(TimeGameOverActive());
        }
    }

    IEnumerator TimeGameOverActive()
    {
        yield return new WaitForSeconds(2.0f); // tempo de espera ate o game over aparecer
        gameOver.SetActive(true);
    }

    // reiniciar o game
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    // sair do game
    public void Quit()
    {
        Application.Quit();
    }

    // pontuação de moedas
    void ValueConvert()
    {
        coinTxt.text = totalCoin.ToString();
    }

    // calculo da posição atual do player coma posição inicial.
    void DistanceCalculation()
    {
        Vector2 distance = (Vector2)playerPosition.position - initialDistance;
        
        if(distance.x < 0) // dsitanciado x menor que 0
        {
            distance.x = 0; // distancia recebe o valor 
        }
        distanceTxt.text = distance.x.ToString("F0") + "M";
    }
}
