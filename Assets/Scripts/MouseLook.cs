using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //Ángulo máximo y mínimo que podemos girar la cabeza ( no peude ser 360º). Determinaremos un ángulo de 45º
    const float CLAMP_MIN = -45;
    const float CLAMP_MAX = 45;
    //Cuanto quiero rotar
    float lookSensitivy = 2; 
    Vector2 smoothRot = Vector2.zero; 
    //Velocidad de rotación 
    Vector2 velRot = Vector2.zero; 
    //Variable "puente" que se mueve suavemente
    float smoothRotationY = 0f;

    Vector2 rotation = Vector2.zero; 

    //En la escena se está girando la cámara pero no se está moviendo el jugador, cuando nos desplacemos nos desplazaremos a donde estamos mirando, por eso necesitamos una referenica al jugador. 
    GameObject player;
    void Start()
    {
        player = transform.parent.gameObject; //Como la cámara es un obj hijo del juegador podemos obtener la referencia a través del padre. 
    }


       void Update()
    {
        //Se lee el desplazamiento horizontal del ratón (Mouse X), se multiplica por la sensibilidad, 
        //El Player rota sobre su eje Y; al rotar el Player, la cámara rota con él
        player.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X")*lookSensitivy);

        //Giro arriba - abajo de la cabeza 
        //Cuanto se desplazó el eje y 
        rotation.y += Input.GetAxis("Mouse Y");  //Desplazamiento del ratón 
        rotation.y = Mathf.Clamp(rotation.y, CLAMP_MIN, CLAMP_MAX); //Con esta función limitamos  el valor
       
        //Suavizado del giro vertical. Desde la posición actual hasta la posición que queremos obtener. El último parámetro es el tiempo que tarda desde el primer parámetro hasta el segundo, el valor objectivo. Cuanto más pequeño sea, más rápido y directo será el movimiento 
        smoothRotationY = Mathf.SmoothDamp(smoothRotationY, rotation.y, ref velRot.y, 0.1f);         //Se aplica el giro suavizado a la cámara
        transform.localEulerAngles = new Vector3(-smoothRotationY, 0, 0);  //La función espera el contrario  

    }
}
