using System.Text;

namespace Do_An.Utilities
{
    public class Function
    {
        public static string? TittleGenerationAlias(string tittle)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(tittle);
        }
    }
}
