using UnityEngine.Audio;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject player;
    public GameObject muzzleEffect;

    public GameObject shootFX;


    private Quaternion rotation;
    public float shootDelay;
    public float DelaySet;
    public float bulletForce = 20f;

    [SerializeField] private AudioSource shot;

    public AudioSource shotting;


    void Start()
    {
        player = GameObject.Find("player");
        DelaySet = 0.2f;
        shootDelay = DelaySet;

    }


    // Update is called once per frame
    void Update()
    {
       
        if(shootDelay< DelaySet)
        {
            shootDelay += Time.deltaTime; 
        }
        
        if (Input.GetButton("Fire1") && Time.timeScale != 0f)
        {

           /* foreach(Sound s in  sounds){
                s.source = gameObject.GetComponent<AudioSource>();
            }*/

            if(shootDelay >= DelaySet)
            {
                if(player.GetComponent<Inventario>().ammo > 0)
                {
                    shootDelay = 0;
                    player.GetComponent<Inventario>().ammo = player.GetComponent<Inventario>().ammo - 1;
                    Shoot();
                    
                }
                else
                {
                    //Debug.Log("Munizioni finite.");
                }
            } 
            else
            {
                //Debug.Log("shootDelay.");
            }
        }
    }

    void Shoot()
    {
        //shot.Play();
       // shot.source = gameObject.AddComponent<AudioSource>();
        //rotation = Quaternion.Inverse(firePoint.rotation);
        //rotation.z = -rotation.z;
        GameObject effect = Instantiate(muzzleEffect, firePoint.position, firePoint.rotation);
        GameObject FX = Instantiate(shootFX, firePoint.position, firePoint.rotation);

        Destroy(effect, 0.10f);
        Destroy(FX, 1.5f);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(-firePoint.right * bulletForce, ForceMode2D.Impulse);

    }
}
