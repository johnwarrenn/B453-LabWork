using UnityEngine;

public class Barrel : MonoBehaviour, IDamagable
{


    [SerializeField] Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        rb.AddForce(Vector3.up * 1000f);
    }
}
