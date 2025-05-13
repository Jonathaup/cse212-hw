public class Person
{
    public string Name { get; }
    public int Turns { get; }

    public Person(string name, int turns)
    {
        Name = name;
        Turns = turns;
    }

    public Person DecrementTurn()
    {
        // Solo decrementa si tiene turnos finitos (> 0)
        if (Turns > 1)
            return new Person(Name, Turns - 1);
        else
            return this; // turns == 1 será descartado luego, no reinserta
    }

    public bool HasInfiniteTurns => Turns <= 0;
    public bool HasTurnsLeft => HasInfiniteTurns || Turns > 1;
}