using UnityEngine;
using System.Collections;

public class DisparoFPS : MonoBehaviour {
    public float tiempoDisparo;
    RaycastHit hit;
    public float largo;
    public ParticleSystem particulas;
    Vida vidaEnemigo;
    public int daño;
    ZonaDanio zona;
    public ParticleSystem chispas;
    public AudioSource sonidoDisp;
    public Pool bulletPool;
    public Pool sparkPool;
    public Pool soundPool;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        #region deteccion de tecla de disparo
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            InvokeRepeating("Disparar", 0, tiempoDisparo);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            CancelInvoke("Disparar");
        }
        #endregion
    }

    void Disparar()
    {

        GameObject goSound = soundPool.Get();
        goSound.transform.position = transform.position;
        goSound.transform.rotation = transform.rotation;

       // Instantiate(sonidoDisp, transform.position, transform.rotation);
        bool choco = Physics.Raycast(transform.position, transform.forward, out hit,largo);
        if (choco)
        {
            Debug.Log(hit.collider.gameObject.layer);
            if (hit.collider.gameObject.layer==9)
            {
                zona = hit.collider.gameObject.GetComponent<ZonaDanio>();
                if (zona!=null)
                {
                    zona.RecibirDanio(10);    
                }
                


                //vidaEnemigo = hit.collider.gameObject.GetComponent<Vida>();
                //vidaEnemigo.vida -= daño;

           
            }
            GameObject goSpark = sparkPool.Get();
            goSpark.transform.position = hit.point;
            goSpark.transform.rotation = hit.transform.rotation;
            
            //Instantiate(chispas, hit.point, hit.transform.rotation);
            
        }
       GameObject go = bulletPool.Get();
        go.transform.position = transform.position;
        go.transform.rotation = transform.rotation;
     
        //particulas.Emit(3);
        Debug.Log("Disparo");
    }
}
