using UnityEngine;
using System;
using NPC.Enemy;
using NPC.Ally;
using UnityEngine.UI;
public class MyHero : MonoBehaviour
{
    static System.Random r = new System.Random(); // VARIABLE AUXILIAR PARA ASIGNACION NATIVA DEL READONLY
    public readonly float velHeroe = (float)r.NextDouble()*8.0f + 1.5f; // VELOCIDAD ALEATORIA DEL HEROE

    VillagerStruct datosAldeano;
    ZombieStruct datosZombie;
    bool contactoZombi;
    bool contactoAldeano;
    public Text mensajito;
    
    private void Start()
    {
        var mensajitos = FindObjectsOfType<Text>(); // LISTA PARA DETECTAR EL GAME OVER
        foreach (var item in mensajitos)
        {
            if (item.name == "GAME OVER")
            {
                mensajito = item; // ASIGNA EL TEXTO EN EL CANVAS CON EL GAME OVER
                mensajito.text = ""; // DESACTIVA EL TEXTO CAMVAS DEL GAME OVER
            }
        }
    }

    void Update() // CONDICIONES PARA MENSAJES POR CONTACTO
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Zombie")
        {
            Debug.Log("Game Over");
            mensajito.text = "GAME OVER";
            // aqui saca el game over cuando lo tocan
            Time.timeScale = 0; // EL TIMESCALE LO VUELVE CERO PARA DETENER EL JUEGO CUANDO UN ZOMBIE TOQUE AL HEROE

        }
    }
}