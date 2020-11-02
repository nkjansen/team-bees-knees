<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
﻿<<<<<<< HEAD
=======
=======
>>>>>>> parent of 2957361... Merge branch 'dev-main' of https://github.com/Nate12503/team-bees-knees into dev-main
﻿using System.Collections;
using UnityEngine;

public class PersonControls : MonoBehaviour
{
    static Animator anim;
    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if(Input.GetButtonDown("Pick"))
        {
            anim.SetTrigger("isPicking");
        }

        if(translation !=0)
        {
            anim.SetBool("isSwimming", true);
        }
        else
        {
            anim.SetBool("isSwimming", false);
        }
    }
}
<<<<<<< HEAD
=======
>>>>>>> parent of 05196d0... eek
﻿using System.Collections;
using UnityEngine;

public class PersonControls : MonoBehaviour
{
    static Animator anim;
    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if(Input.GetButtonDown("Pick"))
        {
            anim.SetTrigger("isPicking");
        }

        if(translation !=0)
        {
            anim.SetBool("isSwimming", true);
        }
        else
        {
            anim.SetBool("isSwimming", false);
        }
    }
}
<<<<<<< HEAD
=======
﻿using System.Collections;
using UnityEngine;

public class PersonControls : MonoBehaviour
{
    static Animator anim;
    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if(Input.GetButtonDown("Pick"))
        {
            anim.SetTrigger("isPicking");
        }

        if(translation !=0)
        {
            anim.SetBool("isSwimming", true);
        }
        else
        {
            anim.SetBool("isSwimming", false);
        }
    }
}
>>>>>>> parent of 2957361... Merge branch 'dev-main' of https://github.com/Nate12503/team-bees-knees into dev-main
=======
>>>>>>> 634096cfe8486f5a2508becd4859a1a4c4644440
>>>>>>> parent of 05196d0... eek
=======
>>>>>>> parent of 2957361... Merge branch 'dev-main' of https://github.com/Nate12503/team-bees-knees into dev-main
