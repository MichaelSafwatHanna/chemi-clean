namespace ChemiClean.Util
{
    public static class Util
    {
        public static bool CompareBytes(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length) return false;
            var i = 0;
            while (i < array1.Length && (array1[i] == array2[i]))
            {
                i++;
            }
            return i == array1.Length;
        }
    }
}
