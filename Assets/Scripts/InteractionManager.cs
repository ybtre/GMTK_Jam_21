using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InteractionManager : MonoBehaviour
{
    public struct Interactable
    {
        public Interaction Interaction;
        public float TimeUntilActivation { get; set; }
    }

    public float PlayerInteractionDistance = 5f;
    public GameObject PlayerObject;
    private Interactable[] _interactables;

    // Start is called before the first frame update
    void Start()
    {
        Interaction[] Interactions = FindObjectsOfType<Interaction>();
        _interactables = new Interactable[Interactions.Length];

        for(int i = 0; i < Interactions.Length; i++)
        {
            _interactables[i] = (new Interactable
            {
                Interaction = Interactions[i],
                TimeUntilActivation = Random.Range(0f, 5f),
            });

            Interactions[i].EndInteractionCountdown();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _interactables.Length; i++)
        {
            if (!_interactables[i].Interaction.IsActive)
            {
                _interactables[i].TimeUntilActivation -= Time.deltaTime;

                if (_interactables[i].TimeUntilActivation < 0f)
                {
                    _interactables[i].Interaction.StartInteractionCountdown();
                    _interactables[i].TimeUntilActivation = Random.Range(5f, 25f);
                }
            }
        }

        if (Input.GetAxis("Interact") > 0)
        {
            foreach (var item in _interactables)
            {
                if (IsWithinDistance(PlayerObject, item.Interaction.gameObject))
                {
                    item.Interaction.Interact();
                }
            }
        }
    }

    bool IsWithinDistance(GameObject gameObjA, GameObject gameObjB)
    {
        return (Vector3.Distance(gameObjA.transform.position, gameObjB.transform.position) < PlayerInteractionDistance);
    }
}
