using System;
using Pattern.Factory;

public class NormalGoblin : Monster
{
    private void Awake()
    {
        Initialize("Normal Goblin", 30, 30);
    }
}
