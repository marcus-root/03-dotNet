namespace dotNet_05_Collections_01_Stacks_tac_Klammersetzung
{
    internal static class klammerPrüfer<T> where T : IComparable
    {
        static Stack<IComparable> stack = new Stack<IComparable>();

        public static bool Prüfen(String ausdruck)
        {
            stack.Clear();
            foreach (char c in ausdruck)
            {
                switch (c)
                {
                    case '(': stack.Push(true); break;
                    case ')': if (stack.Count() != 0) stack.Pop(); else return false; break;
                    default: break;
                }
            }
            if (stack.Count == 0) return true;
            else return false;
        }
    }
}
