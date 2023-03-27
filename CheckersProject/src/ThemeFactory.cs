using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        Board changeColor();
    }

    public interface SquareFactory
    {
        ISquare GetSquare();
    }

    public class Factory : SquareFactory
    {
        public ISquare GetSquare()
        {
            ISquare Red = new Red();
            return Red;
        }
    }

    public class Red : ISquare
    {
        public Board changeColor()
        {
            Board b = new Board();
            b.Background = new SolidColorBrush(Colors.Red);
            return b;
        }
    }
}
