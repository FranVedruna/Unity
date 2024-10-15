using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugadorMejorado : MonoBehaviour
{
    public float velocidad = 5f;
    public float velocidadGiro = 100f;

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");


        Vector3 movimiento = new Vector3(movimientoHorizontal, 0, movimientoVertical).normalized;

        float giro = 0f;
        if (Input.GetKey(KeyCode.Q))
        {
            giro = -1f;  // Girar a la izquierda
        }
        else if (Input.GetKey(KeyCode.E))
        {
            giro = 1f;   // Girar a la derecha
        }

        if (movimiento.magnitude >= 0.1f)
        {
            transform.Translate(movimiento * velocidad * Time.deltaTime, Space.Self);
        }

        if (giro != 0)
        {
            // Rotar en el eje Y (giro horizontal)
            transform.Rotate(Vector3.up, giro * velocidadGiro * Time.deltaTime);
        }
    }
}
