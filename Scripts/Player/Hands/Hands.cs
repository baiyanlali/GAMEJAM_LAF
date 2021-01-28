using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour,IAttackable
{

    public GameObject BladePref;
    public GameObject Blade;
    public Animator BladeAnim;

    public void attack(float vec)
    {
        if (vec != 0)
        {
            if (!Blade)
            {
                Blade = Instantiate(BladePref, this.transform);
                BladeAnim = Blade.GetComponent<Animator>();
            }

            BladeAnim.SetTrigger("StartBlade");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
