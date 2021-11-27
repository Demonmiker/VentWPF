namespace VentWPF.Model
{
    public enum ValveSize
    {

    }

    public static class GetSize
    {
        public static int Size(this SizeType st)
        {
            return st switch
            {
                SizeType.ТипоРазмер1 => (420),
                SizeType.ТипоРазмер2 => (310),
                SizeType.ТипоРазмер3 => (410),
                SizeType.ТипоРазмер4 => (510),
                SizeType.ТипоРазмер5 => (510),
                SizeType.ТипоРазмер6 => (610),
                SizeType.ТипоРазмер8 => (610),
                SizeType.ТипоРазмер10 => (810),
                SizeType.ТипоРазмер12 => (910),
                SizeType.ТипоРазмер16 => (1010),
                SizeType.ТипоРазмер20 => (1110),
                SizeType.ТипоРазмер25 => (1210),
                SizeType.ТипоРазмер30 => (1410),
                SizeType.ТипоРазмер40 => (1610),
                SizeType.ТипоРазмер50 => (1610),
                SizeType.ТипоРазмер60 => (2010),
                SizeType.ТипоРазмер80 => (2010),
                SizeType.ТипоРазмер100 => (2210),
                _ => (0)
            };
        }

    }
}
