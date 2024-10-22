using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //necesario para manejar la UI
using UnityEngine.EventSystems;// Necesario para usar IPointerUpHandler y IPointerDownHandler

public class MOVIMIENTOCARRO : MonoBehaviour  ,IPointerUpHandler
{   
    // Colliders de las ruedas
    public WheelCollider frontLeftCollider, frontRightCollider;
    public WheelCollider rearLeftCollider, rearRightCollider;

    // Mallas visuales de las ruedas
    public Transform frontLeftTransform, frontRightTransform;
    public Transform rearLeftTransform, rearRightTransform;

    // Configuración del coche
    public float maxMotorTorque = 1500f; // Potencia del motor
    public float maxSteeringAngle = 30f; // Ángulo máximo de dirección
    public float brakeTorque = 3000f;    // Fuerza de frenado


     // Botones de UI
    public Button avanzarButton;
    public Button retrocederButton;
    public Button izquierdaButton;  // Botón de flecha izquierda
    public Button derechaButton;    // Botón de flecha derecha


    private bool avanzar;    // Variable para detectar si está avanzando
    private bool retroceder; // Variable para detectar si está retrocediendo
    private bool girarIzquierda;
    private bool girarDerecha;
    private float steeringInput, motorInput;

    // Start is called before the first frame update
    void Start()
    {
    // Asignar eventos a los botones usando EventTrigger para detectar cuando se presionan y cuando se sueltan
        SetButtonListeners();
    }
    

    // Update is called once per frame
    void Update()
    {
        // Control de dirección (giro)
        if (girarIzquierda) {
            steeringInput = -maxSteeringAngle; // Girar a la izquierda
        } else if (girarDerecha) {
            steeringInput = maxSteeringAngle;  // Girar a la derecha
        } else {
            steeringInput = 0; // Si no hay giro, dirección en 0
        }

        frontLeftCollider.steerAngle = steeringInput;
        frontRightCollider.steerAngle = steeringInput;

        // Aceleración o retroceso según el botón presionado
        if (avanzar) {
            motorInput = maxMotorTorque;
            ApplyBrakes(false);  // Desactiva los frenos si estamos avanzando
        } else if (retroceder) {
            motorInput = -maxMotorTorque;
            ApplyBrakes(false);  // Desactiva los frenos si estamos retrocediendo
        } else {
            motorInput = 0;
            ApplyBrakes(true);  // Activa los frenos si no se presiona ningún botón
        }

        // Aplicar el torque a las ruedas traseras
        rearLeftCollider.motorTorque = motorInput;
        rearRightCollider.motorTorque = motorInput;

        // Actualizar la rotación visual de las ruedas
        UpdateWheelPose(frontLeftCollider, frontLeftTransform);
        UpdateWheelPose(frontRightCollider, frontRightTransform);
        UpdateWheelPose(rearLeftCollider, rearLeftTransform);
        UpdateWheelPose(rearRightCollider, rearRightTransform);
    }

      // Métodos para avanzar y retroceder
    public void Avanzar(bool state) {
        avanzar = state;
    }

    public void Retroceder(bool state) {
        retroceder = state;
    }

    // Métodos para girar izquierda y derecha
    public void GirarIzquierda(bool state) {
        girarIzquierda = state;
    }

    public void GirarDerecha(bool state) {
        girarDerecha = state;
    }
       // Método para detenerse cuando se suelta el botón
    public void OnPointerUp(PointerEventData eventData) {
        Detener();
    }
    // Método para detenerse (cuando no se está presionando un botón)
    public void Detener() {
        avanzar = false;
        retroceder = false;
        girarIzquierda = false;
        girarDerecha = false;
        motorInput = 0; // Para que deje de aplicar torque
    }

     // Aplicar frenos según el estado actual
    void ApplyBrakes(bool isBraking) {
        float brakeForce = isBraking ? brakeTorque : 0f;
        rearLeftCollider.brakeTorque = brakeForce;
        rearRightCollider.brakeTorque = brakeForce;
    }
    // Método para actualizar la posición y rotación de las ruedas visuales
    private void UpdateWheelPose(WheelCollider collider, Transform transform) {
        Vector3 pos;
        Quaternion quat;
        collider.GetWorldPose(out pos, out quat);
        transform.position = pos;
        transform.rotation = quat;}
    void SetButtonListeners() {
        AddEventTrigger(avanzarButton, EventTriggerType.PointerDown, (eventData) => Avanzar(true));
        AddEventTrigger(avanzarButton, EventTriggerType.PointerUp, (eventData) => Avanzar(false));

        AddEventTrigger(retrocederButton, EventTriggerType.PointerDown, (eventData) => Retroceder(true));
        AddEventTrigger(retrocederButton, EventTriggerType.PointerUp, (eventData) => Retroceder(false));

        AddEventTrigger(izquierdaButton, EventTriggerType.PointerDown, (eventData) => GirarIzquierda(true));
        AddEventTrigger(izquierdaButton, EventTriggerType.PointerUp, (eventData) => GirarIzquierda(false));

        AddEventTrigger(derechaButton, EventTriggerType.PointerDown, (eventData) => GirarDerecha(true));
        AddEventTrigger(derechaButton, EventTriggerType.PointerUp, (eventData) => GirarDerecha(false));
    }

    // Método auxiliar para agregar eventos de los botones
    private void AddEventTrigger(Button button, EventTriggerType eventType, System.Action<BaseEventData> action) {
        EventTrigger trigger = button.gameObject.GetComponent<EventTrigger>();
        if (trigger == null) {
            trigger = button.gameObject.AddComponent<EventTrigger>();
        }

        EventTrigger.Entry entry = new EventTrigger.Entry { eventID = eventType };
        entry.callback.AddListener((eventData) => action(eventData));
        trigger.triggers.Add(entry);
    }
}


