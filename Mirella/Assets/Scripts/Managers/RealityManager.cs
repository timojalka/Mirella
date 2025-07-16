using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealityManager : MonoBehaviour
{
    public enum EWorld
    {
        World1,
        World2
    }

    [SerializeField] CharacterController TrackedPlayer;
    [SerializeField] Camera TrackedPlayerCamera;

    [SerializeField] Transform World1Anchor;
    [SerializeField] Transform World2Anchor;

    [field: SerializeField] public EWorld CurrentWorld { get; private set; } = EWorld.World1;

    public Vector3 CurrentAnchorPosition => CurrentWorld == EWorld.World1 ? World1Anchor.position : World2Anchor.position;
    public Vector3 OtherAnchorPosition => CurrentWorld == EWorld.World1 ? World2Anchor.position : World1Anchor.position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 playerOffset = TrackedPlayer.transform.position - CurrentAnchorPosition;
        Vector3 newShadowPlayerLocation = playerOffset + OtherAnchorPosition;
        Debug.Log(newShadowPlayerLocation);
    }

}
