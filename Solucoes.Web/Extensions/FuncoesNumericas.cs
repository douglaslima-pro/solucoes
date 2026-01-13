namespace Solucoes.Web.Extensions
{
    public static class FuncoesNumericas
    {
        public static int Ceil(this double numero)
        {
            return (int)Math.Ceiling(numero);
        }

        public static int Ceil(this decimal numero)
        {
            return (int)Math.Ceiling(numero);
        }
    }
}
