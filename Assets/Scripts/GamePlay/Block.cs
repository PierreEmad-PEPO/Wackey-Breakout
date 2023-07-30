using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    protected int blockPoints = 5;
    protected event UnityAction<int> onBlockDestroyed;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        EventManager.AddOnBlockDestroyedInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddOnBlockDestroyedEventListener(UnityAction<int> action)
    {
        onBlockDestroyed += action;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        onBlockDestroyed.Invoke(blockPoints);

        Destroy(gameObject);
    }
}
