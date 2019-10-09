using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balahoria : HeroCam
{
    GameObject laBala;
    GameObject pistol;
    GameObject camaraP;
    Vector3 posicionInicial;
    GameObject myHero;
    public bool canShoot = true;
    public float disparoForce = 2000f;
    

    void Start()
    {
        laBala = GameObject.Find("Balahoria");
        pistol = GameObject.Find("Hombro Derecho");
        myHero = GameObject.Find("Heroe");
        camaraP = GameObject.Find("Camara Heroe");
        posicionInicial = new Vector3(0.2462f, 1.5527f, 0.8309f);
        laBala.transform.SetParent(null);

    }

    void Update()
    {
        transform.eulerAngles = new Vector3(camaraP.transform.rotation.x, myHero.transform.rotation.y,0) ;
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            Disparar();
            canShoot = false;
        }
    }

    void RegresoAlArma()
    {
        laBala.transform.SetParent(myHero.transform);
        laBala.transform.position = posicionInicial;
        laBala.transform.SetParent(null);

    }

    void Disparar()
    {
        transform.rotation = myHero.transform.rotation;
        transform.position = myHero.transform.position + posicionInicial;
        if (canShoot)
        {

            laBala.GetComponent<Rigidbody>().AddForce(new Vector3(laBala.transform.rotation.x, laBala.transform.rotation.y, laBala.transform.rotation.z) * disparoForce);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<NPCRegulator>())
        {
            collision.gameObject.GetComponent<NPCRegulator>().vidaMostro -= 1;
            laBala.GetComponent<Rigidbody>().AddForce(Vector3.forward * disparoForce * -1);
            canShoot = true;
            RegresoAlArma();

        }
        else if (collision.gameObject.GetComponent<Transform>())
        {
            laBala.GetComponent<Rigidbody>().AddForce(Vector3.forward * disparoForce * -1);
            canShoot = true;
            RegresoAlArma();

        }
    }
}
