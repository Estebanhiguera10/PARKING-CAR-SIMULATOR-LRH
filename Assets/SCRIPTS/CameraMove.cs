using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public Transform target; // El objeto que queremos seguir (el auto)
    public float distance = 10.0f; // Distancia desde el auto
    public float height = 5.0f; // Altura de la cámara por encima del auto
    public int cameraSpeed = 5; // Velocidad de interpolación de la cámara

    public float xSpeed = 175.0f; // Sensibilidad de rotación en el eje X
    public float ySpeed = 75.0f; // Sensibilidad de rotación en el eje Y
    public float pinchSpeed; // Velocidad del gesto de pellizco
    private float lastDist = 0; // Última distancia para el gesto de pellizco
    private float curDist = 0; // Distancia actual del gesto de pellizco

    public int yMinLimit = 10; // Límite inferior de ángulo vertical respecto al objetivo
    public int yMaxLimit = 80; // Límite superior de ángulo vertical respecto al objetivo
    public int xLimMin = -90, xLimMax = 140; // Límites de rotación en el eje X
    public float minDistance = 1.0f; // Distancia mínima de la cámara del objetivo
    public float maxDistance = 15.0f; // Distancia máxima de la cámara del objetivo

    private float x = 0.0f; // Rotación actual en el eje X
    private float y = 0.0f; // Rotación actual en el eje Y
    private Touch touch; // Para manejar el toque en dispositivos móviles

    public bool canDrag, isGarage; // Para habilitar el arrastre de la cámara
    public float newXValue = -15f; // Valor inicial de rotación en X

    IEnumerator Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // Hacer que el rigidbody no cambie de rotación
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;

        yield return new WaitForSeconds(0.3f);
        if (!isGarage)
            target = GameObject.FindGameObjectWithTag("Player").transform;

        x = newXValue;
    }

    public float yOffset; // Desplazamiento vertical adicional

    void Update()
    {
        if (canDrag && target && GetComponent<Camera>())
        {
            // Zooming with mouse
            distance += Input.GetAxis("Mouse ScrollWheel") * distance;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);

            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                // One finger touch does orbit
                touch = Input.GetTouch(0);
                x += touch.deltaPosition.x * xSpeed * 0.02f; // Giro en X
                y -= touch.deltaPosition.y * ySpeed * 0.02f; // Giro en Y
            }

            if (Input.touchCount > 1 && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved))
            {
                // Two finger touch does pinch to zoom
                var touch1 = Input.GetTouch(0);
                var touch2 = Input.GetTouch(1);
                curDist = Vector2.Distance(touch1.position, touch2.position);

                if (curDist > lastDist)
                {
                    distance += Vector2.Distance(touch1.deltaPosition, touch2.deltaPosition) * pinchSpeed / 10;
                }
                else
                {
                    distance -= Vector2.Distance(touch1.deltaPosition, touch2.deltaPosition) * pinchSpeed / 10;
                }

                lastDist = curDist;
            }

            // Detect mouse drag
            #if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f; // Giro en X
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f; // Giro en Y
            }
            #else
            if (Input.touchCount == 2)
            {
                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f; // Giro en X
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f; // Giro en Y
            }
            #endif

            y = ClampAngle(y, yMinLimit, yMaxLimit);
            x = ClampAngle(x, xLimMin, xLimMax);

            // Calcular la rotación de la cámara
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 vTemp = new Vector3(0.0f, 0.0f, -distance);

            // Calcular la posición de la cámara con altura
            Vector3 position = rotation * vTemp + new Vector3(target.position.x, target.position.y + height + yOffset, target.position.z);

            // Establecer la posición y rotación de la cámara
            transform.position = Vector3.Lerp(transform.position, position, cameraSpeed * Time.deltaTime);
            transform.rotation = rotation;
        }
    }

    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;

        if (angle > 360)
            angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}