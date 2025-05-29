using System.Collections;
using UnityEngine;

public class SistemaVida : MonoBehaviour
{
    [SerializeField] private int vida = 100;
    private bool estaVivo = true;
    private bool levarDano = true;
    private PlayerMovement pMover;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pMover = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool EstaVivo()
    {
        return estaVivo;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fatal") && estaVivo && levarDano)
        {
            levarDano = false;
            StartCoroutine(LevarDano(10));
        }
    }

   IEnumerator LevarDano(int dano)
    {
        if ( vida > 0)
        {
            pMover.Hit();
            vida -= dano;
            yield return new WaitForSeconds(0.5f);
            levarDano = true;
        }
    }

    private void VerificarVida()
    {
        if (vida <= 0)
        {
            vida = 0;
            estaVivo = false;
        }
    }


}
