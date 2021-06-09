using System;
using System.Numerics;

namespace NumberToString
{
    public class Controller
    {
        private PositiveIntegerToString model;
        private View view;

        public Controller(PositiveIntegerToString model, View view)
        {
            this.model = model;
            this.view = view;
        }

        public void Run(string[] args)
        {
            try
            {
                var userNumber = BigInteger.Parse(args[0]);
                model.Number = userNumber;
                
                view.DisplayBigNumber(userNumber);
                view.DisplayMessage(model.ToString());
            }
            catch (IndexOutOfRangeException)
            {
                view.DisplayHelp();
            }
            catch (FormatException)
            {
                view.DisplayMessage("The input string is not a sequence of digits!");
            }
            catch (Exception ex)
            {
                view.DisplayMessage(ex.Message);
            }
        }
    }
}
