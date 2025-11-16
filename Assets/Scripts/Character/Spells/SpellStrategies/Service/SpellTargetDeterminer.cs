using UnityEngine;
using System.Collections.Generic;

public static class SpellTargetDeterminer {
    private const float DON_KNOW_WHY_AJUST = 1.3f;

    public static Vector3 determineRespectingClosestCollision(Transform transform, Vector3 spawnLocation, float maxRange) {
        return determine(transform, spawnLocation, maxRange, false);
    }

    public static Vector3 determineMaxRangeTarget(Transform transform, Vector3 spawnLocation, float maxRange) {
        return determine(transform, spawnLocation, maxRange, true);
    }

    private static Vector3 determine(Transform transform, Vector3 spawnLocation, float maxRange, bool onlyMaxRange) {
        Camera mainCamera = GameObjectFinder.findMainCamera();

        Ray crosshairRay = determineCrosshairRay(mainCamera);
        if (onlyMaxRange) {
            return determineMaxRangeTarget(mainCamera, maxRange, spawnLocation, crosshairRay);
        }

        RaycastHit[] hits = Physics.RaycastAll(crosshairRay);
        Vector3 closestCollision = determineClosestCollision(transform, hits);

        if (hasHitNothing(closestCollision) || Vector3.Distance(closestCollision, spawnLocation) > maxRange) {
            return determineMaxRangeTarget(mainCamera, maxRange, spawnLocation, crosshairRay);
        }
        //Debug.DrawLine(spawnLocation, closestCollision, Color.red, 5);
        return closestCollision;
    }

    private static Vector3 determineMaxRangeTarget(Camera mainCamera, float maxRange, Vector3 spawnLocation, Ray crosshairRay) {
        float c = Vector3.Distance(spawnLocation, mainCamera.transform.position);
        float beta = Vector3.Angle(crosshairRay.direction, spawnLocation - mainCamera.transform.position);
        float gamma = Mathf.Asin((c / maxRange) * Mathf.Sin(beta * Mathf.Deg2Rad));
        float alpha = 180 - (gamma * Mathf.Rad2Deg) - beta;
        float a = maxRange / Mathf.Sin(beta * Mathf.Deg2Rad) * Mathf.Sin(alpha * Mathf.Deg2Rad);

        Vector3 rangedCursorPos = mainCamera.transform.position + (crosshairRay.direction * a);

        //Debug.DrawLine(spawnLocation, rangedCursorPos, Color.red, 5);
        //Debug.Log(Vector3.Distance(spawnLocation, rangedCursorPos));
        return rangedCursorPos;
    }

    private static Ray determineCrosshairRay(Camera mainCamera) {
        float spread = HUD.instance.getSpreadPixel() / 2 * DON_KNOW_WHY_AJUST;
        float randomSpreadX = Random.Range(-spread, spread);
        float randomSpreadY = Random.Range(-spread, spread);
        Vector3 randomizedCrosshairPosition = new Vector3(randomSpreadX + Screen.width / 2, randomSpreadY + Screen.height / 2, 0);
        return mainCamera.ScreenPointToRay(randomizedCrosshairPosition);
    }

    private static Vector3 determineClosestCollision(Transform player, RaycastHit[] hits) {
        List<RaycastHit> hitsWithoutSelf = filterRays(player, hits);

        if (hitsWithoutSelf.Count == 0) {
            return Vector3.zero;
        }
        return findClosestHitByDistance(hitsWithoutSelf);
    }

    private static List<RaycastHit> filterRays(Transform player, RaycastHit[] hits) {
        List<RaycastHit> hitsWithoutSelf = new List<RaycastHit>();
        //LayerMask not working on RaycastAll ??
        foreach (RaycastHit hit in hits) {
            if (hit.transform.root == player) {
                continue;
            }
            if (hit.transform.gameObject.layer == Layers.SPELL_HITBOX || hit.transform.gameObject.layer == Layers.SPELL_COLLIDER || hit.transform.gameObject.layer == Layers.GRAVITY) {
                continue;
            }
            hitsWithoutSelf.Add(hit);
        }
        return hitsWithoutSelf;
    }

    private static Vector3 findClosestHitByDistance(List<RaycastHit> hitsWithoutSelf) {
        RaycastHit closestHit = hitsWithoutSelf[0];
        for (int i = 1; i < hitsWithoutSelf.Count; i++) {
            if (hitsWithoutSelf[i].distance < closestHit.distance) {
                closestHit = hitsWithoutSelf[i];
            }
        }
        return closestHit.point;
    }

    private static bool hasHitNothing(Vector3 closestCollision) {
        return closestCollision == Vector3.zero;
    }

    private static Vector3 extendClosestCollision(Vector3 spawnLocation, Vector3 closestCollision) {
        return spawnLocation + (closestCollision - spawnLocation).normalized * 99999F;
    }
}
