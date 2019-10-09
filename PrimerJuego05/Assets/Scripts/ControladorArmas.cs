using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorArmas : MonoBehaviour
{
    public ComportamientoArma[] armas;
    int indiceArmaActual = 0;
    GameObject camaraHeroe;

    GameObject hombroDerechoP;
    GameObject hombroDerechoR;

    void Start()
    {
        camaraHeroe = GameObject.Find("Camara Heroe");
        hombroDerechoP = GameObject.Find("Hombro Derecho P");
        hombroDerechoP.transform.rotation = Quaternion.Euler(new Vector3(143f, 32f, -51.7f));
        hombroDerechoR = GameObject.Find("Hombro Derecho R");
        armas[1].gameObject.SetActive(false);

    }

    void Update()
    {
        RevisarCambioDeArma();
    }

    void CambiarArmaActual()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        armas[indiceArmaActual].gameObject.SetActive(true);
    }

    void RevisarCambioDeArma()
    {
        float ruedaMouse = Input.GetAxis("Mouse ScrollWheel");
        if(ruedaMouse > 0f)
        {
            SeleccionarArmaAnterior();
        }else if(ruedaMouse < 0f)
        {
            SeleccionarArmaSiguiente();
        }

    }

    void SeleccionarArmaAnterior()
    {
        if(indiceArmaActual == 0)
        {
            indiceArmaActual = armas.Length - 1;
        }
        else
        {
            indiceArmaActual--;
        }
        CambiarArmaActual();
    }

    void SeleccionarArmaSiguiente()
    {
        if (indiceArmaActual >= (armas.Length - 1))
        {
            indiceArmaActual = 0;
        }
        else
        {
            indiceArmaActual++;
        }
        CambiarArmaActual();
    }
}
