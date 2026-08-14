using UnityEngine;

[RequireComponent(typeof(AudioSource))] // Obliga a tener un componente Audio Source al tener este script para reproducir los clips de audio correspondientes
public class FireProjectiles : MonoBehaviour
{
    [SerializeField]
    GameObject projectile; // Objeto del proyectil

    [SerializeField]
    Transform firePoint; // Punto desde donde sale la bala

    [SerializeField]
    float delay; // Retardo antes de destruir el proyectil

    [SerializeField]
    AudioClip disparar; // Componente de audio para reproducir el sonido del disparo

    AudioSource AudioSource; // Componente de audio para reproducir los sonidos

    void Start()
    {
        // Obtenemos el componente AudioSource para su posterior uso
        AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Fire1 = click izquierdo
        if (Input.GetButtonDown("Fire1"))
        {
            // Se crea la bala en el FirePoint
            GameObject clone = Instantiate(projectile, firePoint.position, firePoint.rotation);

            // Reproducir el sonido del disparo
            AudioSource.PlayOneShot(disparar);

            // Se le dá la dirección correcta (del FirePoint)
            clone.GetComponent<ProjectileMovement>().SetDirection(firePoint.forward);
            // Destruir la bala sino colisiona
            Destroy(clone, delay);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Destrúese o proxectil completo
        Destroy(gameObject);
    }
}
