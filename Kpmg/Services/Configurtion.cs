using System;
namespace Kpmg.Services
{
    public class Configurtion
    {
        const string OUTPUT_PATH = "";
        public Configurtion()
        {
        }



        
    }



    public static class Query{

        const string BALANCES = "";

        const string UNREALWINLOST = "";


        static Query()
        {

        }


        public static string Balances
        {
            get { return BALANCES; }
        }

        public static string UnrealWinLost{
            get {
                return UNREALWINLOST;
            }
        }
    }
}
