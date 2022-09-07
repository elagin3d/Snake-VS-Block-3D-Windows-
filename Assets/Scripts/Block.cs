using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class Block : MonoBehaviour
{
    [Range(0, 50)] public int BlockLife;
    public TMP_Text TextLife;
    private Material _material;
    //
    [SerializeField] private ParticleSystem _destroyBlockPref;
    //
    public static UnityEvent BlockDestroy = new UnityEvent();

    void Start()
    {
        _material = gameObject.GetComponent<Renderer>().material;
        _material.SetFloat("_Gradient", BlockLife * 0.02f);
        SetBlockText();
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        collider.gameObject.GetComponentInParent<SnakeManager>().RemoveBody();
        BlockLife--;
        SetBlockText();
        _material.SetFloat("_Gradient", BlockLife * 0.02f);
        if (BlockLife == 0)
        {
            BlockDestroy?.Invoke();
            Instantiate(_destroyBlockPref, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void SetBlockText()
    {
        TextLife.text = BlockLife.ToString();
    }

    private void OnValidate()
    {
        SetBlockText();
    }
}
