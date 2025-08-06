using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Points { get; private set; }
        protected bool _completed;

        public bool IsCompleted => _completed;

        protected Goal() { } 

        public Goal(string name, string description, int points)
        {
            Name = name;
            Description = description;
            Points = points;
            _completed = false;
        }

        public virtual int RecordEvent()
        {
            _completed = true;
            return Points;
        }

        public virtual string GetStatus()
        {
            return _completed ? "[X]" : "[ ]";
        }

        public override string ToString()
        {
            return $"{GetStatus()} {Name} ({Description})";
        }
    }
}
