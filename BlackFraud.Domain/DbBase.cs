using System;

namespace BlackFraud.Domain
{
    public abstract class DbBase
    {
        protected string Name { get; }

        public DbBase(string name)
        {
            Name = name;
        }
    }
}
