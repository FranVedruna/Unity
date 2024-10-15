using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;

    void Update()
    {
        // Capturar la entrada del jugador
        float movimientoHorizontal = Input.GetAxis("Horizontal");  // A/D o Flechas Izq/Der
        float movimientoVertical = Input.GetAxis("Vertical");      // W/S o Flechas Arr/Abajo

        // Crear un vector de movimiento
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0, movimientoVertical);

        // Aplicar movimiento relativo al espacio local del objeto
        transform.Translate(movimiento * velocidad * Time.deltaTime, Space.Self);
    }
}