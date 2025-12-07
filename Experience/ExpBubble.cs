using UnityEngine;

public class ExpBubble : MonoBehaviour
{
    public int expAmount;
    private bool isReadyToMove;
    public bool isMagnetActivated;
    [SerializeField] private float coinSpeed;
    private Transform player;

    private void Update() 
    {
        Physics2D.IgnoreLayerCollision(8, 17);
        Physics2D.IgnoreLayerCollision(10, 17);
        Physics2D.IgnoreLayerCollision(11, 17);
        Physics2D.IgnoreLayerCollision(15, 17);
        Physics2D.IgnoreLayerCollision(16, 17);

        if(isMagnetActivated)
        {
            if(isReadyToMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, coinSpeed * Time.deltaTime);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(isMagnetActivated)
        {
            if(other.CompareTag("Player"))
            {
                isReadyToMove = true;
                player = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }
    }
}
