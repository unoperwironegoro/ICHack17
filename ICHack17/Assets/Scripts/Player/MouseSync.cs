using UnityEngine;
using UnityEngine.Networking;

public class MouseSync : NetworkBehaviour {
    // Fields are for convenience
    public bool LMB { get { return xmb[0]; } }
    public bool RMB { get { return xmb[1]; } }
    public bool MMB { get { return xmb[2]; } }
    public bool LMBDown { get { return xmb[0] && !xmbLastFrame[0]; } }
    public bool RMBDown { get { return xmb[1] && !xmbLastFrame[1]; } }
    public bool MMBDown { get { return xmb[2] && !xmbLastFrame[2]; } }
    public bool LMBUp { get { return !xmb[0] && xmbLastFrame[0]; } }
    public bool RMBUp { get { return !xmb[1] && xmbLastFrame[1]; } }
    public bool MMBUp { get { return !xmb[2] && xmbLastFrame[2]; } }

    private SyncListBool xmb = new SyncListBool();
    private SyncListBool xmbLastFrame = new SyncListBool();

    void Start() {
        for(int i = 0; i < 3; i++) {
            xmb.Add(false);
            xmbLastFrame.Add(false);
        }
    }

    private void Update() {
        if(isLocalPlayer) {
            for (int i = 0; i < xmb.Count; i++) {
                ProcessButtonInput(i);
            }
        } else if(isServer) {
            for(int i = 0; i < xmb.Count; i++) {
                xmbLastFrame[i] = xmb[i];
            }
        }
    }

    [Client]
    private void ProcessButtonInput(int buttonID) {
        bool before = xmbLastFrame[buttonID];
        bool after = Input.GetMouseButton(buttonID);
        xmbLastFrame[buttonID] = after;

        if(before != after) {
            CmdUpdateButtonInput(buttonID, after);
        }
    }

    [Command]
    private void CmdUpdateButtonInput(int buttonID, bool newStatus) {
        xmb[buttonID] = newStatus;
    }
}
