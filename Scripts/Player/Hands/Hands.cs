using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour,IAttackable
{

    public GameObject BladePref;
    public GameObject BladeObj;
    public Blade blade;
    public Animator BladeAnim;

    public void attack(float vec)
    {
        if (vec != 0)
        {
            if (!BladeObj)
            {
                BladeObj = Instantiate(BladePref, this.transform);
                BladeAnim = BladeObj.GetComponent<Animator>();
                blade = BladeObj.GetComponent<Blade>();
            }


            if(blade.curBladeStatus==Blade.bladeStatus.idle)
                BladeAnim.SetBool("StartBlade",true);

            else if(blade.curBladeStatus==Blade.bladeStatus.blading)
                BladeAnim.SetBool("StartBlade", true);

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
