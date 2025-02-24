using System.Security.Cryptography;

namespace HotelRoomManagement
{
    internal class Program
    {
        #region Verification methods
        // Methods to verify inputs
        public static bool StringVerifyNull(string variable)
        {

            // variable is the input to be verified
            if (string.IsNullOrWhiteSpace(variable))
            {
                Console.WriteLine("\n***************************");
                Console.WriteLine("Input must not be Null or Whitespace.");
                Console.WriteLine("***************************\n");
                return false;
            }
            return true;
        }
        // Example: 
        // if (!IntVerify(out a_int))
        // { continue; }

        public static bool IntVerify(out int variable)
        {
            // variable is the input to be verified
            if (!int.TryParse(Console.ReadLine(), out variable))
            {
                Console.WriteLine("\n***************************");
                Console.WriteLine("Choice must be a valid integer.");
                Console.WriteLine("***************************\n");
                return false;
            }
            return true;
        }
        // Example: 
        // StringVerifyNull(a_string);
        #endregion

        // 
        //public static string[] rooms = {"A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3" };

        static void Main(string[] args)
        {
        }
    }
}
