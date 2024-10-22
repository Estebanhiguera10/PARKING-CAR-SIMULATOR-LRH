using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PARKING : MonoBehaviour
{
   public int rows = 4;     // Número de filas
    public int cols = 10;    // Número de columnas
    public float spaceWidth = 2.5f;  // Ancho de cada espacio de parqueo
    public float spaceLength = 5.0f; // Largo de cada espacio de parqueo
    public float gap = 0.5f;  // Espacio entre cada espacio de parqueo
    public GameObject parkingSpacePrefab; // Prefab del espacio de parqueo
    public GameObject handicappedSpacePrefab; // Prefab del espacio para discapacitados
    public GameObject stopSignPrefab;  // Prefab para la señal de "STOP"
    public GameObject fireLaneSignPrefab; // Prefab para la señal de "Fire Lane"

    void Start()
    {
        CreateParkingLot();
    }

    // Método para crear el lote de parqueadero
    void CreateParkingLot()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                // Calcular la posición de cada espacio de parqueo
                float xPos = col * (spaceWidth + gap);
                float zPos = row * (spaceLength + gap);

                // Determinar si es un espacio especial (para discapacitados o visitantes)
                GameObject space;
                if (col == 1 || col == 2)  // Ejemplo: las primeras dos columnas son para discapacitados
                {
                    space = Instantiate(handicappedSpacePrefab, new Vector3(xPos, 0, zPos), Quaternion.identity);
                }
                else if (col == 3)  // Ejemplo: la tercera columna es un carril de seguridad (fire lane)
                {
                    space = Instantiate(fireLaneSignPrefab, new Vector3(xPos, 0, zPos), Quaternion.identity);
                }
                else
                {
                    // Crear un espacio de parqueo normal
                    space = Instantiate(parkingSpacePrefab, new Vector3(xPos, 0, zPos), Quaternion.identity);
                }

                space.transform.localScale = new Vector3(spaceWidth, 0.2f, spaceLength);
            }
        }

        // Crear señales de tráfico (STOP)
        Vector3 stopPosition = new Vector3(cols * (spaceWidth + gap) / 2, 0, (rows + 1) * (spaceLength + gap));
        Instantiate(stopSignPrefab, stopPosition, Quaternion.Euler(90, 0, 0));  // Rotamos la señal para que esté en el suelo
    }
}