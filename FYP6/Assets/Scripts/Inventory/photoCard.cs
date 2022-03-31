using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class photoCard : MonoBehaviour, ICollectible 
{
    public static event Action OnphotoCollected; 
    
    public void collect()
    {
        Destroy(gameObject);
        OnphotoCollected?.Invoke();
    }
}
