using UnityEngine;
using System.Collections;

public class movimentP2 : MonoBehaviour {

    private float direx, direy;
    public float speed;
    private SkinnedMeshRenderer render;
    public Material[] mat;
    public Camera cam;
    private bool Bonita;
    private bool Nataq = true;
    int controle;
    Animator anim;
    float timer;
    Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        render = GetComponentInChildren<SkinnedMeshRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        moviment();
        click();
        textura();

    }
    private void moviment()
    {

        direx = Input.GetAxis("Horizontal");
        direy = Input.GetAxis("Vertical");

        if (direx == -1)
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
            rb.velocity = new Vector3(speed , 0, 0);

        }
        if (direx == 1)
        {
            transform.eulerAngles = new Vector3(0, 270, 0);
            rb.velocity = new Vector3(speed*-1, 0, 0);
        }
        if (direy == -1)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            rb.velocity = new Vector3(0, 0, -1 * speed);
        }
        if (direy == 1)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.velocity = new Vector3(0, 0, speed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Nataq)
        {
            anim.Play("attack");
            Nataq = false;

        }
        else if (direx == 0 && direy == 0 && Nataq)
            anim.Play("idle");
        
        else if (Nataq)
        {
            anim.Play("walk");
        }
        if (!Nataq)
            timer += Time.deltaTime;
       
        if (timer > 1 && !Nataq)
        {
            Nataq = true;
            timer = 0;
           
        }
        
    }

    private void textura()
    {
        if (Bonita)
        {
            render.material = mat[controle];
            controle++;

            if (controle == 6)
            {
                controle = 0;
            }
            Bonita = false;

        }
    }

    private void click()
    {
        if (Input.GetMouseButtonDown(0))
        {

            var ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
               if(hit.transform.tag == "p2")
                   {
                       Bonita = true;
                   }

            }
        }

    }
}
