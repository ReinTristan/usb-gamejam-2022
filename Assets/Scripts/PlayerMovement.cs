using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D Controller;

    public Animator animator;

    public float RunSpeed = 40f;

    public float ActualDamage = 10f;

    float HorizontalMove = 0f;
    bool bJump = false;

    public float tiempoEntreAtaques = 1f;
    public float tiempoSiguienteAtaque;

    //-----------------------------------------------

    public Transform ControladorGolpe;

    public float radioGolpe = 20f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * RunSpeed;

        if(Input.GetButtonDown("Jump"))
        {
            bJump = true;
        }

        if(tiempoSiguienteAtaque > 0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }

        if(Input.GetButtonDown("Fire1") && tiempoSiguienteAtaque <= 0)
        {
            Atacar();
            tiempoSiguienteAtaque = tiempoEntreAtaques;
        }

    }

    void FixedUpdate()
    {
        Controller.Move(HorizontalMove * Time.fixedDeltaTime, false, bJump);
        bJump = false;
    }

    void Atacar()
    {
        animator.SetTrigger("Golpe");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(ControladorGolpe.position, radioGolpe);

        foreach(Collider2D colisionador in objetos)
        {
            if(colisionador.CompareTag("Enemy"))
            {
                colisionador.transform.GetComponent<Enemy>().TakeDamage(ActualDamage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ControladorGolpe.position, radioGolpe);
    }
}
