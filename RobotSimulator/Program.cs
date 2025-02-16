namespace RobotSimulator
{
    public class Program
    {
        static void Main(string[] args)
        {
            IRobot robot = new Robot();
            string command;

            Console.WriteLine("============================>Toy Robot Simulator<============================");
            Console.WriteLine("*Command Format: <PLACE> <X>,<Y>,<DIRECTION>");
            Console.WriteLine("\t");
            Console.WriteLine("*Sample command: PLACE 0,0,NORTH");
            Console.WriteLine("\t");

            Console.WriteLine("Input Commands:");
            Console.WriteLine("1. PLACE X,Y,F");
            Console.WriteLine("2. MOVE");
            Console.WriteLine("3. LEFT");
            Console.WriteLine("4. RIGHT");
            Console.WriteLine("5. REPORT");
            Console.WriteLine("\t");

            while (true)
            {
                Console.Write(">> ");
                command = Console.ReadLine().ToUpper().Trim();

                if (command.StartsWith("PLACE"))
                {
                    robot.ProcessPlaceCommand(command);
                }
                else if (command == "MOVE")
                {
                    robot.Move();
                }
                else if (command == "LEFT")
                {
                    robot.TurnLeft();
                }
                else if (command == "RIGHT")
                {
                    robot.TurnRight();
                }
                else if (command == "REPORT")
                {
                    robot.Report();
                }
                else
                {
                    Console.WriteLine("INVALID COMMAND...");
                }
            }
        }
    }   
}   
