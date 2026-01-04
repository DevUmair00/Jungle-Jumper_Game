namespace JungleEscapeGame.Core
{
    public static class SaveSystem
    {
        private static string savePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "save.txt");

        public static void SaveLevel(int level)
        {
            try
            {
                File.WriteAllText(savePath, level.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving progress: {ex.Message}");
            }
        }

        public static int LoadLevel()
        {
            try
            {
                if (File.Exists(savePath))
                {
                    string content = File.ReadAllText(savePath);
                    return int.Parse(content);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading progress: {ex.Message}");
            }
            return 1; // Default to Level 1
        }
    }
}