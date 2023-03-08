using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class birds : MonoBehaviour
{
    Vector2 startPosition;
    public float force;  // Rigidbody'nin uygulayacaðý kuvvet
    Rigidbody2D rb2d;

    /*Rigidbody2D rb2d;                  GetComponent<Rigidbody2D>()            Componentleri karþýlarýndaki þekilde de tanýmlayabiliriz.
    SpriteRenderer sprite;               GetComponent<SpriteRenderer>()*/

    void Start()
    {
        startPosition = GetComponent<Rigidbody2D>().position; // Bu kod ile kuþumuzun baþlangýç konumunu ayarladýk.
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void OnMouseDown()
    {  // Týklanýnca kýrmýzý renk olmasýný saðladýk
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    void OnMouseUp()
    {
        Vector2 currentPosition = GetComponent<Rigidbody2D>().position;  // Fareyi býraktýðýmýzda olacak son konumu ayarlardýk.
        Vector2 direction = startPosition - currentPosition;   // Gittiði yolu tanýmlamak için yazdýk.
        direction.Normalize();  // Bu kod ile çapraz giderken hem y hem de x ekseninin kuvvetini almadan normal hýzý ile gitmesi için yazdýk.

        GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Rigidbody2D>().AddForce(direction * force);
       
        GetComponent<SpriteRenderer>().color = Color.white;  // Týklama kaldýrýldýðý zaman eski rengine dönmesini saðladýk.
    }

    void OnMouseDrag()
    {  // Mouse týklanarak seçilince faremizi takip etmesini saðladýk.
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        transform.position = new Vector2(mousePosition.x, mousePosition.y);
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)  // Çarpýnca gerçekleþecek olanlarý yazdým
    {
        GetComponent<Rigidbody2D>().position = startPosition;   // Çarptýktan sonra baþlangýç konumuna getirdim. Inspector'den Freeze Rotation ile dönmeyi durdurdum.
        GetComponent<Rigidbody2D>().isKinematic = true;         // En baþa dönünce düþmemesi için yazdým.
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;    // Tekrar tekrar baþa gelip ayný hareketleri yapmamasý için yazdým. Hýzýný sýfýrladým. 
    }


}