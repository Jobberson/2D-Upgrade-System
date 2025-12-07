using UnityEngine;

public class ExpMagnet : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    private ExpBubble expBubble;

    private void Start() 
    {
        expBubble = GetComponentInParent<ExpBubble>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            ExperienceManager.Instance.AddExperience(expBubble.expAmount);
            Destroy(parent);
        }
    }
}
