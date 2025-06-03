using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float inputH;
    private float inputV;
    private Animator animator;
    private bool estaNoChao = true;
    private float velocidadeAtual;
    private bool contato = false;
    private bool morrer = true;
    private bool temChave = false;
    private int numeroChave;
    private SistemaVida sVida;
    private Vector3 anguloRotacao = new Vector3(0, 90, 0);
    [SerializeField] private float velocidadeCorrer;
    [SerializeField] private float velocidadeAndar;
    [SerializeField] private float forcaPulo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        sVida = GetComponent<SistemaVida>();
        velocidadeAtual = velocidadeAndar;
    }

    // Update is called once per frame
    void Update()
    {
        if(sVida.EstaVivo())
        {
            Andar();
            Girar();
            Pular();
            Correr();
            Atacar();
            Magia();
        }
        else if (!sVida.EstaVivo() & morrer)
        {
            Morrer();
        }
       
    }

    private void Andar()
    {
        inputV = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.forward * inputV;
        Vector3 moveForward = rb.position + moveDirection * velocidadeAtual * Time.deltaTime;
        rb.MovePosition(moveForward);

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Andar", true);
            animator.SetBool("AndarTras", false);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            animator.SetBool("AndarTras", true);
            animator.SetBool("Andar", false);
        }
        else
        {
            animator.SetBool("AndarTras", false);
            animator.SetBool("Andar", false);
        }
    }

    private void Girar()
    {
        inputH = Input.GetAxis("Horizontal");
        Quaternion deltaRotation =
            Quaternion.Euler(anguloRotacao * inputH * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);

        if(Input.GetKey(KeyCode.A) ||
                    Input.GetKey(KeyCode.D) ||
                        Input.GetKey(KeyCode.LeftArrow) ||
                            Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("Andar", true);
        }
    }

    private void Pular()
    {
        if(Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
            animator.SetTrigger("Pular");
          
        }
    }

    private void Correr()
    {
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            velocidadeAtual = velocidadeCorrer;
            animator.SetBool("Correr", true);
        }
        else
        {
            velocidadeAtual = velocidadeAndar;
            animator.SetBool("Correr" , false);
        }

    }

    private void Morrer()
    {
        animator.SetBool("EstaVivo" , false);
        animator.SetTrigger("Morrer");
        rb.Sleep();
    }

    private void Interagir()
    {
        animator.SetTrigger("Interagir");
    }

    private void Pegar()
    {
        animator.SetTrigger("Pegar");
    }

    private void Atacar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Atacar");
        }
    }

    private void Magia()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Magia");
        }
    }

    public void Hit()
    {
        animator.SetTrigger("Hit");
    }


    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            estaNoChao = true;
            animator.SetBool("EstaNoChao", true);
        }
    }
    */
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            estaNoChao = true;
            animator.SetBool("EstaNoChao", true);
        }

        if (collision.gameObject.CompareTag("Quebrar") && Input.GetMouseButtonDown(0))
        {
            Atacar();
            Destroy(collision.gameObject);
        }

      
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            estaNoChao = false;
            animator.SetBool("EstaNoChao", false);
        }
        if (collision.gameObject.CompareTag("Quebrar"))
        {
            contato = false;
        }
    }

    private void OnTriggerStay(Collider Other)
    {
        if (Other.CompareTag("Item") && Input.GetKey(KeyCode.E))
        {
            Pegar();
            Destroy(Other.gameObject);
        }
        else if (Other.CompareTag("Porta") && Input.GetKey(KeyCode.E))
        {
            if (!Other.gameObject.GetComponent<Porta>().EstaTrancada())
            {
                Interagir();
                Other.gameObject.GetComponent<Porta>().AbrirPorta(numeroChave);
            }
            Interagir();
            Other.gameObject.GetComponent<Porta>().AbrirPorta();
        }
        else if (Other.CompareTag("Chave") && Input.GetKey(KeyCode.E))
        {
            Pegar();
            temChave = true;
            numeroChave = Other.gameObject.GetComponent<Chave>().NumeroPorta();
            Other.gameObject.GetComponent<Chave>().PegarChave();
        }

    }
}
