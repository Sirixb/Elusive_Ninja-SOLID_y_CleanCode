using System.Globalization;
using System.IO;
using System.Linq;

namespace DefaultNamespace
{
    public class FilePersistance : ILoader, ISaver
    {
        private const string path = "Assets/Resources/savedFile.txt";

        public void SaveData(float duration)
        {
            // Culture invariante: el archivo es el mismo en cualquier idioma del sistema
            File.AppendAllText(path, duration.ToString(CultureInfo.InvariantCulture) + "\n");
        }

        public float LoadData()
        {
            if (!File.Exists(path))
            {
                return 0;
            }

            // El archivo guarda una duración por línea: la última es la partida más reciente
            var lastLine = File.ReadAllLines(path).LastOrDefault(line => !string.IsNullOrWhiteSpace(line));
            if (lastLine == null)
            {
                return 0;
            }

            // Las líneas antiguas pueden usar coma decimal (ej. "53,47268")
            var normalized = lastLine.Trim().Replace(',', '.');
            return float.TryParse(normalized, NumberStyles.Float, CultureInfo.InvariantCulture, out var duration)
                ? duration
                : 0;
        }
    }
}
