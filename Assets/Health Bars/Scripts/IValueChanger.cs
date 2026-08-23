using System;

public interface IValueChanger 
{
    event Action<float, float> Changed;
}
