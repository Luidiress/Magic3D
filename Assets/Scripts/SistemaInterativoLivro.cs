using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SistemaInterativoLivro : MonoBehaviour
{
    [Header("Objeto do Canvas que o Icone")]
    [SerializeField] private Image spriteInterfaceLivro;
    [Header("Objeto do Canvas que o texto")]
    [SerializeField] private float tempoExibir;
    [SerializeField] private TextMeshProUGUI textoAvisoLivro;

    private void Start()
    {
        
        spriteInterfaceLivro.enabled = false;
        
        textoAvisoLivro.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Aviso>(out Aviso a))
        {
           StartCoroutine(ExibirAviso(a.SpriteAviso() , a.AvisoTexto() , a.CorAviso()));
            if (a.AvisoTemporario())
            {
                StartCoroutine(TimerAvisoTemporario(other.gameObject));
            }
        }
    }

    IEnumerator TimerAvisoTemporario(GameObject g)
    {
        yield return new WaitForSeconds(tempoExibir);
        Destroy(g);
    }

    IEnumerator ExibirAviso(Sprite s, string t, Color c)
    {
        
        spriteInterfaceLivro.enabled = true;
        
        textoAvisoLivro.enabled = true;
       
        spriteInterfaceLivro.sprite = s;
      
        spriteInterfaceLivro.color = c;
       
        textoAvisoLivro.text = t;
       
        textoAvisoLivro.color = c;
        yield return new WaitForSeconds(tempoExibir);
       
        spriteInterfaceLivro.enabled = false;
        
        textoAvisoLivro.enabled = false;
    }
}
