﻿namespace DefiningClasses
{
    public class Engine
    {
        private int engineSpeed;
        private int enginePower;

        public Engine(int engineSpeed, int enginePower)
        {
            this.engineSpeed = engineSpeed;
            this.enginePower = enginePower;
        }

        public int EngineSpeed
        {
            get { return engineSpeed; }
            set { engineSpeed = value; }
        }
        public int EnginePower
        {
            get { return enginePower; }
            set { enginePower = value; }
        }

    }
}
