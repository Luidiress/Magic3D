using UnityEngine;

public class Machado : MonoBehaviour
{
    [SerializeField] private int dano;
    [SerializeField] private GameObject destroyMachadoProFab;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(destroyMachadoProFab, gameObject.transform.position, gameObject.transform.rotation);
        GetComponent<ParticleSystem>().Stop();
        Destroy (this.gameObject);
    }

    private void Joga()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(JogarMachada());
            animator.SetTrigger("JogarMachado");
        }
    }

    IEnumerator JogarMachado()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject magia = Instantiate(machadoPreFab, miraMachado.transform.position, miraMachado.transform.rotation);
        Rigidbody rb = magia.GetComponent<Rigidbody>();
        rbMachado.AddForce(miraMachado.transform.forward * forceArrmeco, ForceMode.Impulse);
        sVida.UsarMana();
    }
}