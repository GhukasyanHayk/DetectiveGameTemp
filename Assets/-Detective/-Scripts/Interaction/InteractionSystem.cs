using TMPro;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField] private float reach = 2f;
    [SerializeField] private Camera cam;
    [SerializeField] private TextMeshProUGUI _interactText;

    private IInteractable currentInteractable;

    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        IInteractable newInteractable = null;

        if (Physics.Raycast(ray, out hit, reach))
        {
            newInteractable = hit.collider.GetComponent<IInteractable>();
        }

        // Если объект изменился
        if (currentInteractable != newInteractable)
        {
            currentInteractable = newInteractable;

            if (currentInteractable != null)
                _interactText.text = currentInteractable.GetInteractMessage();
            else
                _interactText.text = "";
        }

        // Нажатие
        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();

            // Обновить текст после взаимодействия (например Open → Close)
            _interactText.text = currentInteractable.GetInteractMessage();
        }
    }
}