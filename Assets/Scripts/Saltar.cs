using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltar : MonoBehaviour
{
    [SerializeField] private float fuerzaSalto = 5f;
    [SerializeField] private float gravedadExtra = 15f;
    private bool enSuelo;
    private Rigidbody rb;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Si toca el suelo y se pulsa la tecla "Space" recibe una fuerza positiva sobre el eje Y
        if (Input.GetKey(KeyCode.Space) && enSuelo)
        {
            Vector3 movimientoVertical = Vector3.up * fuerzaSalto;
            rb.AddForce(movimientoVertical, ForceMode.Impulse);
            enSuelo = false;
        }

        //Como volaba demasiado el objeto le he añadido una gravedad extra que solo se aplica
        //cuando el collider 'Trigger' no está tocando el suelo
        if (!enSuelo)
        {
            rb.AddForce(Vector3.down * gravedadExtra, ForceMode.Acceleration); // Aplicar gravedad adicional
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Para que funcione el plano tiene le tag 'Suelo'
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }
}