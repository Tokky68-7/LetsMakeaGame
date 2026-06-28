using UnityEngine;

public class Entity : MonoBehaviour {

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    }