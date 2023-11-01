namespace busca_largura.extensions
{
    public static class IntExtensions
    {
        public static string? ToStringOrEmpty(this int? value)
        {
            return value.HasValue ? value.ToString() : "_";
        }
    }
}
