using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerInteraction : MonoBehaviour
{
    public SphereCollider Collider;
    public float InteractionRadius = 3f;

    [SerializeField]
    private List<Interaction> Interactions;

    // Start is called before the first frame update
    void Start()
    {
        Collider.isTrigger = true;
        Collider.radius = InteractionRadius;

        Interactions = new List<Interaction>();
    }

    private void Update()
    {
        if (Input.GetAxis("Interact") > 0)
        {
            if (Interactions.Any())
            {
                Interaction nearestItem = Interactions.First();
                float nearestDistance = 999f;
                float currentDistance = 0f;
                foreach (var item in Interactions)
                {
                    currentDistance = Mathf.Min(Vector3.Distance(item.transform.position, transform.position), nearestDistance);

                    if (currentDistance < nearestDistance)
                    {
                        nearestItem = item;
                        nearestDistance = currentDistance;
                    }
                }

                nearestItem.Interact();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Interaction interaction))
        {
            Interactions.Add(interaction);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Interaction interaction))
        {
            Interactions.Remove(interaction);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, InteractionRadius);
    }
}
