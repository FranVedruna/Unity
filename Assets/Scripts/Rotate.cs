using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Velocidad de rotaci�n ajustable desde el inspector de Unity
    public float rotationSpeed = 100f;

    // Limites de rotaci�n
    public float minRotation = -20f;
    public float maxRotation = 20f;

    void Update()
    {
        // Obtener los valores de los ejes (Horizontal: A/D o Flechas izquierda/derecha, Vertical: W/S o Flechas arriba/abajo)
        float horizontalInput = Input.GetAxis("Horizontal") * -1;
        float verticalInput = Input.GetAxis("Vertical");

        // Obtener la rotaci�n actual del objeto en ejes X y Z
        Vector3 currentRotation = transform.localEulerAngles;

        // Convierte la rotaci�n al rango [-180, 180] para evitar problemas con �ngulos mayores a 360
        if (currentRotation.x > 180) currentRotation.x -= 360;
        if (currentRotation.z > 180) currentRotation.z -= 360;

        // Aplicar la rotaci�n solo si est� dentro de los l�mites (-20� a 20�)
        float newRotationX = currentRotation.x + verticalInput * rotationSpeed * Time.deltaTime;
        float newRotationZ = currentRotation.z + horizontalInput * rotationSpeed * Time.deltaTime;

        // Limitar la rotaci�n en los ejes X y Z usando Mathf.Clamp
        newRotationX = Mathf.Clamp(newRotationX, minRotation, maxRotation);
        newRotationZ = Mathf.Clamp(newRotationZ, minRotation, maxRotation);

        // Aplicar la nueva rotaci�n limitada al objeto
        transform.localEulerAngles = new Vector3(newRotationX, currentRotation.y, newRotationZ);
    }
}
