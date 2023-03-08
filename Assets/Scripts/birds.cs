using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class birds : MonoBehaviour
{
    Vector2 startPosition;
    public float force;  // Rigidbody'nin uygulayaca�� kuvvet
    Rigidbody2D rb2d;

    /*Rigidbody2D rb2d;                  GetComponent<Rigidbody2D>()            Componentleri kar��lar�ndaki �ekilde de tan�mlayabiliriz.
    SpriteRenderer sprite;               GetComponent<SpriteRenderer>()*/

    void Start()
    {
        startPosition = GetComponent<Rigidbody2D>().position; // Bu kod ile ku�umuzun ba�lang�� konumunu ayarlad�k.
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void OnMouseDown()
    {  // T�klan�nca k�rm�z� renk olmas�n� sa�lad�k
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    void OnMouseUp()
    {
        Vector2 currentPosition = GetComponent<Rigidbody2D>().position;  // Fareyi b�rakt���m�zda olacak son konumu ayarlard�k.
        Vector2 direction = startPosition - currentPosition;   // Gitti�i yolu tan�mlamak i�in yazd�k.
        direction.Normalize();  // Bu kod ile �apraz giderken hem y hem de x ekseninin kuvvetini almadan normal h�z� ile gitmesi i�in yazd�k.

        GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Rigidbody2D>().AddForce(direction * force);
       
        GetComponent<SpriteRenderer>().color = Color.white;  // T�klama kald�r�ld��� zaman eski rengine d�nmesini sa�lad�k.
    }

    void OnMouseDrag()
    {  // Mouse t�klanarak se�ilince faremizi takip etmesini sa�lad�k.
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        transform.position = new Vector2(mousePosition.x, mousePosition.y);
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)  // �arp�nca ger�ekle�ecek olanlar� yazd�m
    {
        GetComponent<Rigidbody2D>().position = startPosition;   // �arpt�ktan sonra ba�lang�� konumuna getirdim. Inspector'den Freeze Rotation ile d�nmeyi durdurdum.
        GetComponent<Rigidbody2D>().isKinematic = true;         // En ba�a d�n�nce d��memesi i�in yazd�m.
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;    // Tekrar tekrar ba�a gelip ayn� hareketleri yapmamas� i�in yazd�m. H�z�n� s�f�rlad�m. 
    }


}