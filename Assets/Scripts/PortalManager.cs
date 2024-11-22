using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public GameObject closedPortalPrefab;
    public GameObject openPortalPrefab;
    public Transform portalSpawnPoint;
    public KeyCollector keyCollector;
    
    private GameObject currentPortal;

    void Start()
    {
        SpawnClosedPortal();
    }

    void Update()
    {
        if (keyCollector.CollectedKeys >= keyCollector.TotalKeys && currentPortal != null)
        {
            ReplacePortalWithOpen();
        }
    }

    void SpawnClosedPortal()
    {
        if (closedPortalPrefab != null && portalSpawnPoint != null)
        {
            currentPortal = Instantiate(closedPortalPrefab, portalSpawnPoint.position, Quaternion.identity);
        }
    }

    void ReplacePortalWithOpen()
    {
        if (openPortalPrefab != null && portalSpawnPoint != null)
        {
            Destroy(currentPortal);
            currentPortal = Instantiate(openPortalPrefab, portalSpawnPoint.position, Quaternion.identity);
        }
    }
}
