using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class monster : MonoBehaviour
{

    [SerializeField] Sprite deadSprite;           // Oyunda monster ölünce gözünün kapanmasý için yazdýk. Ölen monsterin sprite'ýný Inspector panelinden buna atacaðýz.
    [SerializeField] ParticleSystem particleSys;  // Ölünce gelen efekt þeysi.
    bool hasDie;                                  // Ölünce bazý þeyleri tekrarlamamasý için.
    
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
        birds bird = collision.gameObject.GetComponent<birds>();           // birds scriptine ulaþtýk.
        if(bird != null)        
            return true;

        if (collision.contacts[0].normal.y <= -0.5)       // En alttaki kutu hariç diðer kutularýn temasýnda canavarý yok etme kodu.
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
