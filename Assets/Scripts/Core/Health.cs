using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float health = 100;

    public void TakeDamage(float damage)
    {
        health -= damage;
        
        Debug.Log(gameObject.name + " has " + health + " HP");

        if(health <= 0)
        {
            Debug.Log(gameObject.name + " died!");
        }
    }   



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
