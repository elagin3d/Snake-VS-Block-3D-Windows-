using UnityEngine;
using UnityEngine.Events;
using TMPro;


public class Body : MonoBehaviour
{
    public int Life = 1;
    public TMP_Text TextLife;
    //
    public static UnityEvent AddBody = new UnityEvent();

    void Start()
    {
        SetBodyText();
    }

    private void OnTriggerEnter(Collider collider)
    {
        collider.gameObject.GetComponentInParent<SnakeManager>().AddBody(Life);
        AddBody?.Invoke();
        Destroy(gameObject);
    }

    private void SetBodyText()
    {
        TextLife.text = Life.ToString();
    }

    private void OnValidate()
    {
        SetBodyText();
    }
}
