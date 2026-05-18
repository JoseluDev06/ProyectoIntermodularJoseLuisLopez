using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_Movimiento : MonoBehaviour
{
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float velocidadMovimientoTrasero;
    [SerializeField] private float modificadorDeGravedad;
    [SerializeField] private Transform comprobadorSuelo;
    [SerializeField] private LayerMask playerMask;

    private bool estaMirandoDerecha = true;
    private bool estaMirandoHaciaDelante = true;

    private Animator animator;
    private Rigidbody2D rb;
    private Transform player2;
    private GameObject hitboxAtaqueLigero1;
    private GameObject hitboxAtaqueLigero2;
    private GameObject hitboxAtaquePesado1;

    private bool enAire;
    private bool getSalto;
    private float inputHorizontal;
    private bool enAtaque;
    private bool enBloqueo = false;


    float ventanaTiempoDoblePulsacion = 0.25f;
    float ultimaPulsacionA = 0f;
    float ultimaPulsacionD = 0f;
    bool estaCorriendoIzquierda = false;
    bool estaCorriendoDerecha = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player2 = GameObject.Find("Player2").transform;
        hitboxAtaqueLigero1 = transform.Find("CollidersAtaques/HitboxAtaqueLigero1").gameObject;
        hitboxAtaqueLigero2 = transform.Find("CollidersAtaques/HitboxAtaqueLigero2").gameObject;
        hitboxAtaquePesado1 = transform.Find("CollidersAtaques/HitboxAtaquePesado1").gameObject;
    }

    void Update()
    {
        RelacionarAnimator();
        ComprobarDireccion();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            getSalto = true;
        }

        ComprobarAtaque();
        ComprobarMovimiento();
    }

    private void FixedUpdate()
    {
        if (!Physics2D.OverlapCircle(comprobadorSuelo.position, 0.1f, playerMask))
        {
            enAire = true;
            return;
        }

        enAire = false;

        if (getSalto)
        {
            if (!enBloqueo) { 
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            }
            getSalto = false;
        }

        RealizarMovimiento();
    }

    private void RealizarMovimiento()
    {
        float velocidadAUsar;

        if (estaMirandoHaciaDelante)
        {
            velocidadAUsar = velocidadMovimiento;
        }
        else
        {
            velocidadAUsar = velocidadMovimientoTrasero;
        }

        if (estaCorriendoDerecha && estaMirandoDerecha)
        {
            rb.velocity = new Vector2(
                inputHorizontal * (velocidadAUsar * 1.5f),
                rb.velocity.y
            );
        }
        else if (estaCorriendoIzquierda && !estaMirandoDerecha)
        {
            rb.velocity = new Vector2(
                inputHorizontal * (velocidadAUsar * 1.5f),
                rb.velocity.y
            );
        }
        else
        {
            rb.velocity = new Vector2(
                inputHorizontal * velocidadAUsar,
                rb.velocity.y
            );
        }
    }

    private void ComprobarDireccion()
    {
        if (player2.position.x > transform.position.x && !enAire)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            estaMirandoDerecha = true;
        }
        else
        {
            if (!enAire)
            {
                estaMirandoDerecha = false;
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }

    private void ComprobarAtaque()
    {
        if (Input.GetKeyDown(KeyCode.J) && !enAire && !enAtaque && !enBloqueo)
        {
            animator.SetTrigger("Attack1");
            enAtaque = true;
            hitboxAtaqueLigero1.SetActive(true);
            Invoke("FinAtaque", 0.5f);
        }

        if (Input.GetKey(KeyCode.H) && !enAire && !enAtaque)
        {
            animator.SetBool("IsBlock", true);
            enBloqueo = true;
        }
        else
        {
            animator.SetBool("IsBlock", false);
            enBloqueo = false;
        }

        if (Input.GetKeyDown(KeyCode.K) && !enAire && !enAtaque && !enBloqueo)
        {
            animator.SetTrigger("Attack2");
            enAtaque = true;
            hitboxAtaqueLigero2.SetActive(true);
            Invoke("FinAtaque", 0.33f);
        }

        if (Input.GetKeyDown(KeyCode.L) && !enAire && !enAtaque && !enBloqueo)
        {
            animator.SetTrigger("Attack3");
            enAtaque = true;
            hitboxAtaquePesado1.SetActive(true);
            Invoke("FinAtaque", 1f);
        }
    }

    private void ComprobarMovimiento()
    {
        if (enAtaque || enBloqueo)
        {
            inputHorizontal = 0;
            return;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputHorizontal = -1f;
            estaMirandoHaciaDelante = player2.position.x < transform.position.x;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Time.time - ultimaPulsacionA < ventanaTiempoDoblePulsacion)
            {
                estaCorriendoIzquierda = true;
            }

            ultimaPulsacionA = Time.time;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputHorizontal = 1f;
            estaMirandoHaciaDelante = player2.position.x > transform.position.x;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (Time.time - ultimaPulsacionD < ventanaTiempoDoblePulsacion)
            {
                estaCorriendoDerecha = true;
            }

            ultimaPulsacionD = Time.time;
        }

        if (!Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            estaCorriendoIzquierda = false;
        }

        if (!Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            estaCorriendoDerecha = false;
        }

        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            inputHorizontal = 0f;
        }
    }

    private void RelacionarAnimator()
    {
        float velocidadRelativa;

        if (estaMirandoDerecha)
        {
            velocidadRelativa = inputHorizontal;
        }
        else
        {
            velocidadRelativa = -inputHorizontal;
        }

        if (estaCorriendoIzquierda || estaCorriendoDerecha)
        {
            velocidadRelativa *= 2;
        }

        animator.SetFloat("Speed", velocidadRelativa);
        animator.SetBool("IsJumping", enAire);
        animator.SetBool("isFordward", estaMirandoHaciaDelante);
    }

    private void FinAtaque()
    {
        enAtaque = false;
        DesactivarAtaques();
    }

    private void DesactivarAtaques()
    {

        hitboxAtaqueLigero1.SetActive(false);
        hitboxAtaqueLigero2.SetActive(false);
        hitboxAtaquePesado1.SetActive(false);
    }

}
