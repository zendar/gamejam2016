using UnityEngine;
using System.Collections;

public class Message {

    public readonly GameObject from;
    public readonly GameManager.EventTypes eventType;
    public readonly GameObject causedBy;



    public Message(GameObject from_, GameManager.EventTypes eventType_, GameObject causedBy_)
    {
        from = from_;
        eventType = eventType_;
        causedBy = causedBy_;
    }


}
