using UnityEngine;

public class DissableObject : MonoBehaviour
{
    public Camera mainCamera;
    public Renderer[] objectsToCull; // можно заполнять вручную или через FindObjectsOfType<Renderer>()

    void Update()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);

        foreach (var rend in objectsToCull)
        {
            if (!rend) continue;
            bool visible = GeometryUtility.TestPlanesAABB(planes, rend.bounds);
            if (rend.gameObject.activeSelf != visible)
                rend.gameObject.SetActive(visible);
        }
    }
}
