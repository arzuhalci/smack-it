using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
     public Rigidbody rb;
     public GameObject spawnpoint;
    public Camera cam;
    public float maxhiz = 15f;
    Vector3 vektor;
    public Object prefab;
    public Rigidbody ayna;
    

    
    
    // Start is called before the first frame update
    void Start()
    {
        
        GameManager.Instance.klonlar.Add(gameObject);
        Debug.Log(GameManager.Instance.klonlar.Count);
        Debug.Log("started");
        rb = gameObject.GetComponent<Rigidbody>();
         spawnpoint = GameObject.Find("spawnpoint");
        cam = Camera.main;
        prefab = Resources.Load<Object>("Sphere");
        vektor = cam.transform.position - spawnpoint.transform.position;
        Vector3 kurespawn = new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y, spawnpoint.transform.position.z);
        Vector3 cercevepos = new Vector3(cam.transform.position.x + Random.Range(-4,4), cam.transform.position.y + Random.Range(-4,4), cam.transform.position.z);

        StartCoroutine("bekletipdondur");
        
        
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (cam.transform.position.z + 4 < rb.position.z) {
            if (rb.position.x <= -5)
            {
                //Debug.Log("pos aşıldı");
                rb.AddForce(new Vector3(10, 0, 0), ForceMode.Impulse);
            }
            else if (rb.position.x >= 5)
            {
                //Debug.Log("pos aşıldı");
                rb.AddForce(new Vector3(-10, 0, 0), ForceMode.Impulse);

            }
            else if (rb.position.y <= -5)
            {
                //Debug.Log("pos aşıldı");
                rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            }
            else if (rb.position.y >= 5)
            {
                //Debug.Log("pos aşıldı");
                rb.AddForce(new Vector3(0, -10, 0), ForceMode.Impulse);
            }

            if (rb.velocity.magnitude >= maxhiz)
            {
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxhiz);
            }

            if(rb.position.z < -14)
        {
            GameManager.Instance.klonlar.RemoveAt(GameManager.Instance.klonlar.Count - 1);
            Destroy(gameObject);
        }
                

        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ayna")
        {
            GameManager.Instance.klonlar.RemoveAt(GameManager.Instance.klonlar.Count - 1);
            Destroy(gameObject);
            
            
        }
    }

    void dondurerek()
    {
        Vector3 cercevepos = new Vector3(cam.transform.position.x + Random.Range(-4, 4), cam.transform.position.y + Random.Range(-2, 7), cam.transform.position.z);
        rb.AddForce(cercevepos, ForceMode.Impulse);
        
 
    }


    private IEnumerator bekletipdondur()
    {
        Vector3 cercevepos = new Vector3(cam.transform.position.x + Random.Range(-4, 4), cam.transform.position.y + Random.Range(-2, 7), cam.transform.position.z);
        dondurerek();
        yield return new WaitForSeconds(0.5f);
        

            Vector3 donus = new Vector3(cercevepos.x - rb.position.x + Random.Range(-10, 10), cercevepos.y - rb.position.y + Random.Range(-10, 10), cam.transform.position.z);
            rb.AddForce(donus, ForceMode.Impulse);
        
        yield return new WaitForSeconds(4f);
        
        
            rb.AddForce(new Vector3(0, 0, -40), ForceMode.Impulse);


        

    }
    
}
