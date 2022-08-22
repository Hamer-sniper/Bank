using LogicForBank_ClassLibrary.Data;

namespace LogicForBank_ClassLibrary.Models
{
    public static class Ext
    {
        public static double ToDouble(this string d)
        {
            if (!double.TryParse(d, out double s))
                throw new MyException("В поле \"Сумма\" введено не число!");
            return double.Parse(d);
        }
    }
}
