namespace FN.WinForm
{
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public double Value { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
}
