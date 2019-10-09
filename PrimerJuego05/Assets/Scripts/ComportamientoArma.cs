using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModoDeDisparo
{
    FullAuto,
    SemiAuto
}

public class ComportamientoArma : MonoBehaviour
{
    public ModoDeDisparo modoDeDisparo = ModoDeDisparo.FullAuto;
    public float daño = 20f;
    public float ritmoDeDisparo = 0.3f;
    public int balasRestantes;
    public int balasEnCartucho;
    public int tamañoDeCartucho;
    public int maximoDeBalas = 100;
    bool tiempoNoDisparo;

    void Start()
    {
        balasEnCartucho = tamañoDeCartucho;
        balasRestantes = maximoDeBalas;
    }

void Update()
    {
        AccionDeDisparo();
    }

    void AccionDeDisparo()
    {
        if (!tiempoNoDisparo)
        {
            if (modoDeDisparo == ModoDeDisparo.FullAuto && Input.GetButton("Fire1"))
            {
                Disparar();
            }
            if (modoDeDisparo == ModoDeDisparo.SemiAuto && Input.GetButtonDown("Fire1"))
            {
                Disparar();
            }
            if (Input.GetKeyDown(KeyCode.R) && balasEnCartucho < tamañoDeCartucho && balasRestantes > 0)
            {
                balasRestantes -= tamañoDeCartucho - balasEnCartucho;
                balasEnCartucho = tamañoDeCartucho;

            }
        }
    }

    void Disparar()
    {
        tiempoNoDisparo = true;
        balasEnCartucho--;
        StartCoroutine(ReiniciarTiempoNoDisparo());
    }

    IEnumerator ReiniciarTiempoNoDisparo()
    {
        yield return new WaitForSeconds(ritmoDeDisparo);
        tiempoNoDisparo = false;
    }
}
