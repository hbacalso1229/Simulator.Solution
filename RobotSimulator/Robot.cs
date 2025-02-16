namespace RobotSimulator
{
    public class Robot : IRobot
    {
        private const string RobotPlacementErrorMessage = "The robot has not been placed yet. Please submit a placement command first.";
        private const int TotalNumberOfDirections = 4;
        private const int TableSize = 5; // table dimensions 5x5 units

        // robot coordinates -1 the robot has not been placed yet
        private int _x = -1;
        private int _y = -1;

        // robot directions
        private string _direction = "NORTH";
        private readonly string[] Directions = { "NORTH", "EAST", "SOUTH", "WEST" };  

        /// <summary>
        /// The initial position where the robot should be placed
        /// </summary>
        /// <param name="command"></param>
        public void ProcessPlaceCommand(string command)
        {
            string[] parts = command.Split(' ');

            if (parts.Length == 2)
            {
                string[] position = parts[1].Split(',');

                if (position.Length == 3 && int.TryParse(position[0], out int x) && int.TryParse(position[1], out int y) && IsValidDirection(position[2]))
                {
                    if ((x >= 0 && x < TableSize) && (y >= 0 && y < TableSize))
                    {
                        _x = x;
                        _y = y;
                        _direction = position[2].ToUpper();
                    }
                    else
                    {
                        Console.WriteLine("Invalid position. Coordinates must be between 0 and 4");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid PLACE command. Please provide coordinates X,Y,F where X and Y are integers, and F is a valid direction");
                }
            }
            else
            {
                Console.WriteLine("Invalid PLACE command format");
            }
        }

        /// <summary>
        /// Moves the robot forward by one unit in its current facing direction
        /// </summary>
        public void Move()
        {
            if (_x == -1 || _y == -1)
            {
                Console.WriteLine(RobotPlacementErrorMessage);
                return;
            }

            int newX = _x;
            int newY = _y;

            switch (_direction)
            {
                case "NORTH":
                    newY++;
                    break;
                case "EAST":
                    newX++;
                    break;
                case "SOUTH":
                    newY--;
                    break;
                case "WEST":
                    newX--;
                    break;
            }

            // Check if the move is within bounds
            if ((newX >= 0 && newX < TableSize) && (newY >= 0 && newY < TableSize))
            {
                _x = newX;
                _y = newY;
            }
            else
            {
                Console.WriteLine("Move ignored: Robot would fall off the table");
            }
        }

        /// <summary>
        /// Rotates the robot 90 degrees counter-clockwise in the specified direction
        /// </summary>
        public void TurnLeft()
        {
            if (_x == -1 || _y == -1)
            {
                Console.WriteLine(RobotPlacementErrorMessage);
                return;
            }

            int currentDirectionIndex = Array.IndexOf(Directions, _direction);
            _direction = Directions[(currentDirectionIndex + 3) % TotalNumberOfDirections];
        }

        /// <summary>
        /// Rotates the robot 90 degrees clockwise in the specified direction
        /// </summary>
        public void TurnRight()
        {
            if (_x == -1 || _y == -1)
            {
                Console.WriteLine(RobotPlacementErrorMessage);
                return;
            }

            int currentDirectionIndex = Array.IndexOf(Directions, _direction);
            _direction = Directions[(currentDirectionIndex + 1) % TotalNumberOfDirections];
        }

        /// <summary>
        /// Logs the robot's current location and placement status
        /// </summary>
        public void Report()
        {
            if (_x == -1 || _y == -1)
            {
                Console.WriteLine(RobotPlacementErrorMessage);
                return;
            }

            Console.WriteLine($"Robot is at {_x},{_y} facing {_direction}");
        }

        private bool IsValidDirection(string direction)
        {
            return direction == "NORTH" || direction == "EAST" || direction == "SOUTH" || direction == "WEST";
        }
    }
}
