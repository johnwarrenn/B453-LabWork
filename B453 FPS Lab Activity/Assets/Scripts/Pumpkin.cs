using UnityEditor.UI;
using UnityEngine;

public class Pumpkin : MonoBehaviour, ITriggerable
{

    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject light;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Trigger()
    {
        if (light.activeSelf == false)
        {
            light.SetActive(true);
        }
        else
        {
            light.SetActive(false);
        }
        
        
    }
}
