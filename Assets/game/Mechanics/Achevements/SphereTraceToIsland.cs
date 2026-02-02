using UnityEngine;

public class SphereTraceToIsland : MonoBehaviour
{
    private float radius = 5f;
    private float distance = 200f;

    void Start()
    {
        PlayerPrefs.SetInt("IsActivateAchPanel", 0);
    }

    void Update()
    {
        if (!IsScreenPressed())
            return;

        // Проверяем каждый тап, что панель ещё не активирована
        if (PlayerPrefs.GetInt("IsActivateAchPanel", 0) != 0)
            return;

        Vector3 screenPos = GetScreenPosition();
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        RaycastHit hit;

        if (Physics.SphereCast(ray, radius, out hit, distance))
        {
            if (hit.collider.CompareTag("Achevements"))
            {
                ActivateDisActivatePanels panel = hit.collider.GetComponent<ActivateDisActivatePanels>();

                if (panel != null)
                {
                    panel.Activate();
                    PlayerPrefs.SetInt("IsActivateAchPanel", 1);
                    Debug.Log("Achievements panel activated");
                }
                else
                {
                    Debug.Log("На объекте с тегом Achevements нет ActivateDisActivatePanels");
                }
            }
        }
    }

    bool IsScreenPressed()
    {
        // ПК
        if (Input.GetMouseButtonDown(0))
            return true;

        // Телефон
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            return true;

        return false;
    }

    Vector3 GetScreenPosition()
    {
        if (Input.touchCount > 0)
            return Input.GetTouch(0).position;

        return Input.mousePosition;
    }
}
