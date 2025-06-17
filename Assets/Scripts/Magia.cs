using UnityEngine;

public class Magia : MonoBehaviour
{
    [SerializeField] private int danoMagia;
    [SerializeField] private GameObject destroyMagiaPreFab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Quebrar"))
        {
           var objetoQuebrar = collision.gameObject.GetComponent<ObjetoQuebra>();
            if (objetoQuebrar != null)
            {
                objetoQuebrar.Quebrar(danoMagia);
            }
        }

        Instantiate(destroyMagiaPreFab, gameObject.transform.position, gameObject.transform.rotation);
        GetComponent<ParticleSystem>().Stop();
        Destroy(this.gameObject);
    }

}
