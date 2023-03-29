using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace CheckersProject.src
{
    /**internal class ThemeFactory
    {
    }**/
    //int colorValue = 0;

    //We need to make sure we are generating objects with this factory

    public interface ISquare
    {
        Button changeColor();
    }

    public interface SquareFactory
    {
        ISquare GetBlueSquare();
    }

    public class Factory : SquareFactory
    {
        public ISquare GetBlueSquare()
        {
            ISquare Blue = new Blue();
            return Blue;
        }
    }

    public class Blue : ISquare
    {
        public Button changeColor()
        {
            //Board b = new Board();
            //b.Background = new SolidColorBrush(Colors.Red);
            Button b = new Button { Background = new SolidColorBrush(Colors.Blue) };  
            //Button b2 = new Button { Background}
            return b;
        }
    }
}
