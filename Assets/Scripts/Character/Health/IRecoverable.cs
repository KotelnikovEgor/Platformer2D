using System;

public interface IRecoverable
{
    event Action Overed;

    void Recover();
}
