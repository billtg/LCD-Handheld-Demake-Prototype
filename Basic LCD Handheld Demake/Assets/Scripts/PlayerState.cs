using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    public virtual void EnterState() { }
    public virtual void MoveLeft() { }
    public virtual void MoveUp() { }
    public virtual void MoveRight() { }
    public virtual void MoveDown() { }
    public virtual void Jump() { }
    public virtual void PlayerAction() { }
    public virtual void PlayerUpdate() { }
}
