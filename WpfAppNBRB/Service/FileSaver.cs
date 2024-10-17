using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppNBRB.Service
{
    public class FileSaver
    {
        public async Task SaveToJsonFileAsync<T>(string filePath, T data)
        {
            if (data == null) return;

            try
            {
                string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);

                using (StreamWriter writer = new StreamWriter(filePath, append: false)) 
                {
                    await writer.WriteLineAsync(jsonData);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка при сохранении в файл: {ex.Message}");
            }
        }

        public async Task<T> LoadFromJsonFileAsync<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return default;
            }

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string jsonData = await reader.ReadToEndAsync();
                    return JsonConvert.DeserializeObject<T>(jsonData);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка при чтении из файла: {ex.Message}");
                return default;
            }
        }
    }
}
