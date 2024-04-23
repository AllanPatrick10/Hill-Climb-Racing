using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int direction;
    public float gasoline; // gasolina
    public float gastoGasoline; // gasto de gasolina

    public Image fill;

    public float speed;
    public float carSpeed; 
    public float inputMove;
    public Rigidbody2D tireFront; // roda da frente
    public Rigidbody2D tireBack; // roda de tras
    public Rigidbody2D carRig; // corpo carro


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        fill.fillAmount = gasoline;
    }

     void FixedUpdate()
    {
        if(gasoline > 0)
        {
            MoveLogic();
            MoveMobile();
        }
        comsumoLogic();

    }

    // gasto de gasolina no jogo
    void comsumoLogic()
    {
        gasoline -= gastoGasoline * Mathf.Abs(inputMove) * Time.fixedDeltaTime;
        gasoline -= gastoGasoline * Mathf.Abs(direction) * Time.deltaTime;
    }

    // movimentação 
    void GetInput()
    {
        inputMove = Input.GetAxis("Horizontal");
    }

    void MoveLogic()
    {
        tireFront.AddTorque(-inputMove * speed * Time.fixedDeltaTime);
        tireBack.AddTorque(-inputMove * speed * Time.fixedDeltaTime);
        carRig.AddTorque(-inputMove * carSpeed * Time.fixedDeltaTime);
    }


    // movimentação mobile
    void MoveMobile()
    {
        tireFront.AddTorque(direction * speed * Time.deltaTime);
        tireBack.AddTorque(direction * speed * Time.deltaTime);
        carRig.AddTorque(direction * carSpeed * Time.deltaTime);
    }

    // direção mobile
    public void CarInputMobile(int dir)
    {
        direction = dir;
    }
}
