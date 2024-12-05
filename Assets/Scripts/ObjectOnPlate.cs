using UnityEngine;

public class PlateController : MonoBehaviour
{
    [Header("Trigger Collider for Food Detection")]
    public Collider triggerCollider;
    bool has_enter = false;

    private void FixedUpdate()
    {
        // Encuentra todos los alimentos dentro del trigger
        Collider[] foods = Physics.OverlapBox(triggerCollider.bounds.center, triggerCollider.bounds.extents, triggerCollider.transform.rotation, LayerMask.GetMask("Food"));
        if (foods.Length == 2 && !has_enter)
        {
            SceneTransitionManager.singleton.GoToSceneAsync(0);
            has_enter = true;
        }
    }

    private void OnDrawGizmos()
    {
        if (triggerCollider != null)
        {
            Gizmos.color = Color.green; // Cambia el color si necesitas distinguirlo
            Gizmos.DrawWireCube(triggerCollider.bounds.center, triggerCollider.bounds.size);
        }
    }
}
