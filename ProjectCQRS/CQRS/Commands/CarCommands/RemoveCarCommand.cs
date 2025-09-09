﻿namespace ProjectCQRS.CQRS.Commands.CarCommands
{
    public class RemoveCarCommand
    {
        public int CarID { get; set; }

        public RemoveCarCommand(int carID)
        {
            CarID = carID;
        }
    }
}
