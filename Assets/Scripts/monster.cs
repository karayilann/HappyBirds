using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class monster : MonoBehaviour
{

    [SerializeField] Sprite deadSprite;           // Oyunda monster �l�nce g�z�n�n kapanmas� i�in yazd�k. �len monsterin sprite'�n� Inspector panelinden buna ataca��z.
    [SerializeField] ParticleSystem particleSys;  // �l�nce gelen efekt �eysi.
    bool hasDie;                                  // �l�nce baz� �eyleri tekrarlamamas� i�in.
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShouldDieFromCoolision(collision))
        {
            StartCoroutine(Hit());           
        }
    }

    private bool ShouldDieFromCoolision(Collision2D collision)
    {
        if (hasDie)
        {
            return false;
        }
        birds bird = collision.gameObject.GetComponent<birds>();           // birds scriptine ula�t�k.
        if(bird != null)        
            return true;

        if (collision.contacts[0].normal.y <= -0.5)       // En alttaki kutu hari� di�er kutular�n temas�nda canavar� yok etme kodu.
        {
            return true;
        }

        return false;    
    } 

    IEnumerator Hit()
    {
        hasDie = true;
        GetComponent<SpriteRenderer>().sprite = deadSprite;
        particleSys.Play();
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
    
   
}
