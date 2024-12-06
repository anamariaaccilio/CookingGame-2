using UnityEngine;

public class PlateController : MonoBehaviour
{
    [Header("Trigger Collider for Food Detection")]
    public Collider triggerCollider;
    public bool exit_success = false;
    bool has_enter = false;


    private void FixedUpdate()
    {
        // Encuentra todos los alimentos dentro del trigger
        Collider[] foods = Physics.OverlapBox(triggerCollider.bounds.center, triggerCollider.bounds.extents, triggerCollider.transform.rotation, LayerMask.GetMask("Food"));
        if (foods.Length == 2 && !has_enter)
        {
            exit_success = (foods[0].GetComponent<FoodBehavior>().current_cooking_state == CookingState.acceptable) &&
                 (foods[0].GetComponent<FoodBehavior>().current_cooking_state == CookingState.acceptable);

            if (exit_success )
            {
                SceneTransitionManager.singleton.exitStatus = SceneTransitionManager.Exit.ExitSuccess;
            }
            else
            {
                SceneTransitionManager.singleton.exitStatus = SceneTransitionManager.Exit.ExitWithErrors;
            }

            Debug.Log(exit_success);
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
