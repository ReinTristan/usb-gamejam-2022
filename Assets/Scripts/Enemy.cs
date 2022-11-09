using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float Life = 100f;

    public Animator anim; 

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float InDamage)
    {
        Life -= InDamage;

        if(Life > 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        //animacion muerte
    }

}
