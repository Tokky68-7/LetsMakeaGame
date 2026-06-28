using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Health playerHealth;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerHealth.TakeDamage(10f);
        }
    }
}
