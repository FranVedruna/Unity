using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoLateral : MonoBehaviour
{
    [SerializeField] private float velocidad = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        Vector3 movimiento = new Vector3(0, 0, -movimientoHorizontal);
        rb.AddForce(movimiento * velocidad, ForceMode.Force);
    }
}