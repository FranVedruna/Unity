using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoConstante : MonoBehaviour
{
    [SerializeField] private float velocidad = 10f;

    void Update()
    {
        Vector3 movimiento = new Vector3(1, 0, 0);
        transform.Translate(movimiento * velocidad * Time.deltaTime);
    }
}
