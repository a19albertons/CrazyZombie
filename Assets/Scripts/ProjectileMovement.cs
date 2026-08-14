using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    //Velocidad de la bala

    [SerializeField]
    float speed = 20f;

    [SerializeField]
    AudioClip golpeEnemigo; // Componente de audio para reproducir el sonido del golpe al enemigo

    //Referencia ao RigidBody
    Rigidbody rb;

    Vector3 direction;

    //Se ejecuta cuando se crea el objecto

    void Awake()
    {
        // Se guarda el RigidBody del mismo objecto
        rb = GetComponent<Rigidbody>();
    }

    //Llamado desde FireProjectiles al instanciar
    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    //Se ejecuta el primer frame
    void Start()
    {
        //Se le dice a la física que la bala se mueve hacia delante a X velocidad
        rb.linearVelocity = transform.forward * speed;
    }

    // Se ejecuta cuando colisiona con algo
    void OnCollisionEnter(Collision collision)
    {
        //Se destruye el projectil completo
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Entramos en un trigger con: " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Golpe al enemigo");
            // Reproducir el sonido del golpe al enemigo
            AudioSource.PlayClipAtPoint(golpeEnemigo, transform.position);
        }
    }
}
